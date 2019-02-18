using Dapper;
using Microsoft.Extensions.Configuration;
using SmartData.Sample.DataContract.User;
using SmartData.Sample.RepositoryContract.Payroll;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SmartData.Sample.Repository.Payroll
{
    public class PayrollRepository : BaseRepository, IPayrollRepository
    {
        public PayrollRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetUserListAsync()
        {
            #region With Stubbed Data.
            List<UserModel> userList = new List<UserModel>()
            {
                new UserModel(){UserId = 101, FirstName = "Test", LastName = "User 1", MobileNumber = "9876543210"},
                new UserModel(){UserId = 102, FirstName = "Test", LastName = "User 2", MobileNumber = "9876543210"},
                new UserModel(){UserId = 103, FirstName = "Test", LastName = "User 3", MobileNumber = "9876543210"},
                new UserModel(){UserId = 104, FirstName = "Test", LastName = "User 4", MobileNumber = "9876543210"},
                new UserModel(){UserId = 105, FirstName = "Test", LastName = "User 5", MobileNumber = "9876543210"},
            };

            return userList;
            #endregion

            #region With Stored procedure
            //var query = "sp_name";

            //DynamicParameters parameter = new DynamicParameters();
            //parameter.Add("@ProjectId", 101, DbType.Int32, ParameterDirection.Input);

            //var result = await GetAsync<UserModel>(query, parameter, commandType: CommandType.StoredProcedure);

            //return result;
            #endregion
        }
    }
}
