using Dapper;
using System;
using System.Data;

namespace ClubManagerApi.DataAccess
{
    internal class BaseRepository : IDisposable
    {
        private readonly IDbConnection _connection;

        public BaseRepository(IDbConnection connection)
        {
            this._connection = connection;
            InitDatabase();
        }

        private void InitDatabase()
        {
            _connection.Execute(
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

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}