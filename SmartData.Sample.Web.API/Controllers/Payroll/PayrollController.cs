using Microsoft.AspNetCore.Mvc;
using SmartData.Sample.DataContract.User;
using SmartData.Sample.ServiceContract.Payroll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartData.Sample.Web.API.Controllers.Payroll
{
    /// <summary>
    /// Controller to work with Payroll related APIs
    /// </summary>    
    [Produces("application/json")]
    public class PayrollController : BaseController
    {
        protected readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService) : base(payrollService)
        {
            _payrollService = payrollService;
        }

        /// <summary>
        /// This API is used to do a healthcheck on the Payroll Controller.
        /// </summary>
        /// <returns>HealthCheck Information</returns>
        // GET: api/payroll/healthcheck/
        [HttpGet]
        [Route("/api/payroll/healthcheck")]
        public async Task<IActionResult> HealthCheckAsync()
        {
            var result = await _payrollService.HealthCheckAsync();

            var response = Ok(result);

            return response;
        }

        [HttpGet]
        [Route("/api/payroll/users")]
        public async Task<IActionResult> GetUserListAsync()
        {
            IActionResult response = null;

            IEnumerable<UserModel> userList = await _payrollService.GetUserListAsync();

            response = Ok(userList);

            return response;
        }
    }
}