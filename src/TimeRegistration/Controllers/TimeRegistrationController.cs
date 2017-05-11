using System.Web.Http;
using TimeRegistration.Core.Dtos;

namespace TimeRegistration.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1")]
    public class TimeRegistrationController : ApiController
    {
        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <returns>Paginated list of users.</returns>
        [HttpGet]
        [Route("users")]
        public PagedList<User> GetUserList()
        {
            return new PagedList<User>(null, 1, 20, 0);
        }

        /// <summary>
        /// Create user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Id of newly created user.</returns>
        [HttpPost]
        [Route("users")]
        public int CreateUser(string userName)
        {
            return 100;
        }

        /// <summary>
        /// Create project for defined user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="projectName">Name of project.</param>
        /// <returns>Id of newly created project.</returns>
        [HttpPost]
        [Route("users/{userId}/projects")]
        public int CreateProject(int userId, string projectName)
        {
            return 100;
        }

        /// <summary>
        /// Get list of project for the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{userId}/projects")]
        public PagedList<User> GetProjectList(int userId)
        {
            return null;
        }

        /// <summary>
        /// Get a list of registered times for the project.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{userId}/projects/{projectId}/time")]
        public PagedList<object> GetTimeReport(int userId, int projectId)
        {
            return null;
        }

        /// <summary>
        /// Add new time for the user's project.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("users/{userId}/projects/{projectId}/time")]
        public IHttpActionResult RegisterTime(int userId, int projectId)
        {
            return Ok();
        }

    }
}