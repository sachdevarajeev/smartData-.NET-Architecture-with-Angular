using SmartData.Sample.DataContract.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartData.Sample.RepositoryContract.Payroll
{
    /// <summary>
    ///  Repository Contract to work with PayrollRepository.
    /// </summary>
    public interface IPayrollRepository : IBaseRepository
    {
        /// <summary>
        /// IPayrollRepository is hiding(using keyword "new") the IBaseRepository's Healthcheck to enable call to PayrollRepository's HealthCheck.
        /// </summary>
        /// <returns>HealthCheck Information</returns>
        new Task<object> HealthCheckAsync();

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserModel>> GetUserListAsync();
    }
}
