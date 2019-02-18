using SmartData.Sample.DataContract.User;
using System.Collections.Generic;

namespace SmartData.Sample.DataContract.Authentication
{
    /// <summary>
    /// Login user information including the token
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Security token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// List of directory roles the use has access to
        /// </summary>
        public IEnumerable<DirectoryRole> DirectoryRoles { get; set; }

        /// <summary>
        /// Organization Id to which the user belongs to.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Url to the home page. This will be based on the default role of the user profile.
        /// </summary>
        public string HomePageUrl { get; set; }

        /// <summary>
        /// Url to the user onboarding page
        /// </summary>
        public string UserOnboardingUrl { get; set; }

        /// <summary>
        /// List of functional roles the use has access to
        /// </summary>
        public IEnumerable<FunctionalRole> FunctionalRoles { get; set; }

        /// <summary>
        /// List of directory role ids, the user has access to
        /// </summary>
        public IEnumerable<int> DirectoryRoleIds { get; set; }

        /// <summary>
        /// List of functional role ids the use has access to
        /// </summary>
        public IEnumerable<int> FunctionalRoleIds { get; set; }

        /// <summary>
        /// Default Role of the user.
        /// This will be later used to define the default home page of the user.
        /// </summary>
        public string DefaultRole { get; set; }

        /// <summary>
        /// Is the password temporary. 
        /// It will be true for new users untill they complete their onboarding process.
        /// </summary>
        public bool IsTemporaryPassword { get; set; }

        /// <summary>
        /// Interval in minutes by which the token should be refreshed.
        /// </summary>
        public int TokenRefreshIntervalInMinutes { get; set; }
    }
}
