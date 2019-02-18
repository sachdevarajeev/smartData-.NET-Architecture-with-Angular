using Microsoft.Extensions.Configuration;
using SmartData.Sample.DataContract.User;
using SmartData.Sample.RepositoryContract.Payroll;
using SmartData.Sample.ServiceContract.Payroll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartData.Sample.Service.Payroll
{
    public class PayrollService : BaseService, IPayrollService
    {
        private readonly IPayrollRepository _payrollRepository;
        public PayrollService(IPayrollRepository payrollRepository
            , IConfiguration configuration) : base(payrollRepository, configuration)
        {
            _payrollRepository = payrollRepository;
        }

        /// <summary>
        /// PayrollService for Healthcheck
        /// </summary>
        /// <returns>HealthCheck Information</returns>
        public async Task<object> HealthCheckAsync()
        {
            return await _payrollRepository.HealthCheckAsync();
        }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetUserListAsync()
        {
            return await _payrollRepository.GetUserListAsync();
        }
    }
}
