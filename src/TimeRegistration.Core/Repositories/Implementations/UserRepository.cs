using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperExtensions;
using TimeRegistration.Core.Dtos;
using TimeRegistration.Core.Repositories.Abstructions;

namespace TimeRegistration.Core.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public int Insert(string userName)
        {
            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                string commandInsert = "INSERT INTO [user_account] (Name)"
                                       + "VALUES(@UserName); SELECT CAST(SCOPE_IDENTITY() as int";
                var command = new CommandDefinition(commandInsert, new { UserName = userName }, transaction);

                return connection.ExecuteScalar<int>(command);
            }
        }

        public User GetUser(int userId)
        {
            using (var connection = OpenConnection())
            {
                var commandText = @"SELECT * FROM [user_account]"
                                  + "WHERE Id = @UserId;";
                var command = new CommandDefinition(commandText, new { UserId = userId });

                return connection.QueryFirstOrDefault<User>(command);
            }
        }

        public void DeleteUser(int userId)
        {
            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                // make it inactive?
                var commandText = @"DELETE FROM [user_account]"
                                  + "WHERE Id = @UserId;";
                var command = new CommandDefinition(commandText, new { UserId = userId }, transaction);

                connection.Execute(command);
            }
        }

        public PagedList<User> GetUserList(int page, int pageSize)
        {
            using (var connection = OpenConnection())
            {
                var orderBy = new List<ISort>()
                {
                    Predicates.Sort<User>(r => r.Name, true)
                };

                var total = connection.Count<User>(new Predicate<User>(u=> true));
                var users = connection.GetPage<User>(null, orderBy, page - 1, pageSize, buffered: true);

                return new PagedList<User>(users, total);
            }
        }

        private static IDbConnection OpenConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

            connection.Open();

            return connection;
        }
    }
}
