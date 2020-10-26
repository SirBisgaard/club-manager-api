using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using club_manger_api.Domain;

namespace club_manger_api.DataAccess
{
    public class JsonMemberRepository : IMemberRepository
    {
        private readonly string _directoryPath;
        private readonly string _filePath;
        private readonly ILogger<JsonMemberRepository> _logger;

        public JsonMemberRepository(ILogger<JsonMemberRepository> logger)
        {
            _logger = logger;

            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _directoryPath = Path.Combine(path, "club-manager");
            _filePath = Path.Combine(_directoryPath, "members.json");

            InitFile();
        }

        private void InitFile()
        {
            var directory = new DirectoryInfo(_directoryPath);
            if (!directory.Exists)
                directory.Create();

            var file = new FileInfo(_filePath);
            if (file.Exists)
                return;

            using (var writer = file.CreateText())
            {
                writer.WriteLine("[]");
            }
        }

        public async Task<Member> CreateMember(Member member)
        {
            _logger.LogDebug("Creating a new member.");

            var members = (await GetAllMembers()).ToList();
            member.Id = members.Max(m => m.Id) + 1;

            _logger.LogDebug($"Next Id: {member.Id}.");

            members.Add(member);

            SaveMembers(members);

            return member;
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            await Task.Delay(0);

            _logger.LogDebug("Getting all members.");

            using (StreamReader file = File.OpenText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (IEnumerable<Member>)serializer.Deserialize(file, typeof(IEnumerable<Member>));
            }
        }

        public async Task<Member> GetMember(int id)
        {
            _logger.LogDebug($"Getting member with Id: {id}.");

            return (await GetAllMembers()).SingleOrDefault(m => m.Id == id);
        }

        public async Task<Member> UpdateMember(Member member)
        {
            var members = (await GetAllMembers()).ToList();

            var index = members.FindIndex(m => m.Id == member.Id);
            if (index == -1)
            {
                _logger.LogDebug($"Did not find member Id: {member.Id}.");
                return null;
            }
            members[index] = member;

            _logger.LogDebug($"Member is updated.");

            SaveMembers(members);

            return member;
        }

        public async Task<bool> DeleteMember(int id)
        {
            var members = await GetAllMembers();

            SaveMembers(members.Where(m => m.Id != id));

            _logger.LogDebug($"Member is deleted.");

            return true;
        }

        private void SaveMembers(IEnumerable<Member> members)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, members);
            }

            _logger.LogDebug($"JSON is saved.");
        }
    }
}