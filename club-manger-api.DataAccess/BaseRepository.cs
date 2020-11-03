using Dapper;
using Microsoft.Data.Sqlite;
using System;

namespace club_manger_api.DataAccess
{
    internal class BaseRepository
    {
        protected static string DbFile
            => Environment.CurrentDirectory + "\\App_Data\\club-manager.sqlite";

        protected static SqliteConnection Connection
            => new SqliteConnection("Data Source=" + DbFile);

        protected static void InitDatabase()
        {
            using (var cnn = Connection)
            {
                cnn.Open();
                cnn.Execute(
                    @"create table if not exists Members
                    (
                        ID                                  integer primary key AUTOINCREMENT,
                        Name                                varchar(100) not null,
                        Mail                                varchar(100) not null,
                        Active                              bit not null,
                        DateOfBirth                         datetime not null,
                        FirstRegistered                     datetime not null
                    )");
            }
        }
    }
}