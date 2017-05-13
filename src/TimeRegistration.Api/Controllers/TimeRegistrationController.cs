using System;
using System.Collections.Generic;
using System.Web.Http;
using TimeRegistration.Core.Dtos;
using TimeRegistration.Core.Managers.Abstructions;

namespace TimeRegistration.Api.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1")]
    public class TimeRegistrationController : ApiController
    {
        private readonly IUserManager _userManager;
        public TimeRegistrationController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <returns>Paginated list of users.</returns>
        [HttpGet]
        [Route("users")]
        public PagedList<User> GetUserList(int page = 1, int pageSize = 20)
        {
            return _userManager.GetUserList(page, pageSize);
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
            return _userManager.CreateUser(userName);
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
        /// <param name="page">Default value = 1.</param>
        /// <param name="pageSize">Default value = 20.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{userId}/projects")]
        public PagedList<User> GetProjectList(int userId, int page = 1, int pageSize = 20)
        {
            return null;
        }

        /// <summary>
        /// Get a list of registered times for the project.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projectId">Project Id for which report should be generated.</param>
        /// <param name="year">Report year.</param>
        /// <param name="month">Month of the year. If not specified report will be for the whole year.</param>
        /// <param name="day">Day of the month. If not specified report will be for the whole month.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{userId}/projects/{projectId}/report/{year}")]
        [Route("users/{userId}/projects/{projectId}/report/{year}/{month}")]
        [Route("users/{userId}/projects/{projectId}/report/{year}/{month}/{day}")]
        public string GetTimeReport(int userId, int projectId, int year, int month = 0, int day = 0)
        {
            return $"{year}/{month}/{day}";
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