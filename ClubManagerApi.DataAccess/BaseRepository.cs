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
            _connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Members
                (
                    ID                                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                                VARCHAR(100) NOT NULL,
                    Mail                                VARCHAR(100) NOT NULL,
                    Password                            VARCHAR(32) NOT NULL,
                    Active                              BIT NOT NULL,
                    DateOfBirth                         DATETIME NOT NULL,
                    FirstRegistered                     DATETIME NOT NULL,
                    Created                             DATETIME NOT NULL,
                    Deleted                             DATETIME NULL
                );
                CREATE TABLE IF NOT EXISTS Users
                (
                    ID                                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                                VARCHAR(100) NOT NULL,
                    Mail                                VARCHAR(100) NOT NULL,
                    Password                            VARCHAR(32) NOT NULL,
                    Created                             DATETIME NOT NULL,
                    Deleted                             DATETIME NULL
                );");
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}