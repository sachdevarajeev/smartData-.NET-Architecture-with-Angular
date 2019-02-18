using SmartData.Sample.DataContract.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SmartData.Sample.ServiceContract
{
    /// <summary>
    /// Service Contract for getting the Base Service Functionality which forces its concrete implementation to implement the base behaviours like HealthCheck
    /// </summary>
    public interface IBaseService
    {
        // <summary>
        /// Declares HealthCheck to be implemeted by the deriving services .
        /// </summary>
        /// <returns>HealthCheck Information</returns>
        Task<object> HealthCheckAsync();

        /// <summary>
        /// Login user information
        /// </summary>
        LoginUser LoginUser { get; set; }

        /// <summary>
        /// Used to check for access
        /// </summary>
        bool CheckForAccess { get; set; }

        /// <summary>
        /// SmartData Sample url
        /// </summary>
        string SmartDataSampleUrl { get; }

        /// <summary>
        /// Validates the token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool IsTokenValid(JwtSecurityToken token);
    }
}
