using SmartData.Sample.DataContract.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartData.Sample.ServiceContract.Payroll
{
    public interface IPayrollService : IBaseService
    {
        /// <summary>
        /// IPayrollService is hiding(using keyword "new") the IBaseService's Healthcheck to enable call to PayrollService's HealthCheck.
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
