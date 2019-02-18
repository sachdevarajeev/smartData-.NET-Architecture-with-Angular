using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartData.Sample.DataContract.Authentication;
using SmartData.Sample.RepositoryContract;
using SmartData.Sample.ServiceContract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartData.Sample.Service
{
    /// <summary>
    /// Service for getting the Base services functionality .
    /// </summary>
    public class BaseService : IBaseService
    {
        IBaseRepository _baseRepository;
        IBaseService _baseService;
        public IConfiguration Configuration;

        private LoginUser _loginUser;

        public BaseService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public BaseService(IBaseRepository baseRepository, IConfiguration configuration)
        {
            _baseRepository = baseRepository;
            Configuration = configuration;
        }

        public BaseService(IBaseRepository baseRepository, IBaseService baseService, IConfiguration configuration)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
            Configuration = configuration;
        }

        /// <summary>
        /// A pass through for the other services inheriting from Base Service to implement.
        /// </summary>
        public virtual Task<object> HealthCheckAsync()
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Interval in minutes by which the token should be refreshed.
        /// </summary>
        public int TokenRefreshIntervalInMinutes
        {
            get
            {
                return Convert.ToInt32(
                            Configuration
                            .GetSection("TokenRefreshIntervalInMinutes")
                            .GetSection("Value").Value);
            }
        }

        /// <summary>
        /// Login user information
        /// </summary>
        public LoginUser LoginUser
        {
            get
            {
                if (_loginUser == null)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return _loginUser;
                }
            }

            set { _loginUser = value; }
        }

        /// <summary>
        /// Used to check for access
        /// </summary>
        public bool CheckForAccess { get; set; }

        /// <summary>
        /// Url for SmartData Sample
        /// </summary>
        public string SmartDataSampleUrl
        {
            get
            {
                return Configuration
                        .GetSection("SmartDataSampleUrl")
                        .GetSection("Url").Value;
            }
        }

        /// <summary>
        /// Service For Formatting PhoneNumber
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public string FormatPhoneNumber(string phoneNumber)
        {
            Regex regexPhoneNumber = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            if (regexPhoneNumber.IsMatch(phoneNumber))
            {
                return regexPhoneNumber.Replace(phoneNumber, "($1) $2-$3");
            }
            else
                return phoneNumber;
        }

        /// <summary>
        /// Validates the token for expiration time.
        /// Returns false if the token has expired
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool IsTokenValid(JwtSecurityToken token)
        {
            var valid = false;

            // get user info from token
            var actor = token
                            .Claims
                            .Where(item => item.Type.Contains("actor"))
                            .First()
                            .Value;

            if (!string.IsNullOrEmpty(actor))
            {
                var user = JsonConvert.DeserializeObject<LoginUser>(actor);

                valid = (DateTime.UtcNow < token.ValidTo);
            }

            return valid;
        }

        /// <summary>
        /// Maintains the token generated against the user when they login in.
        /// TODO: Modifiy to use caching, whenever caching is implemented.
        /// </summary>
        public static Dictionary<string, string> UserTokens { get; set; }

        /// <summary>
        /// Service Account User Id
        /// </summary>
        public int ServiceAccountUserId
        {
            get
            {
                return Convert.ToInt32(Configuration
                        .GetSection("Keys:ServiceAccountUserId")
                        .GetSection("Value").Value);
            }
        }
    }
}
