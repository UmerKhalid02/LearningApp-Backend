using LearningApp.Application.DataTransferObjects.ClassroomDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Classrooms
{
    [Route("api/v1/classrooms")]
    public class ClassroomController : BaseController
    {
        private readonly IClassroomService _classroomService;
        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [Authorize(Roles = "AD")]
        [HttpGet]
        public async Task<IActionResult> GetAllClassrooms()
        {
            var response = await _classroomService.GetAllClassrooms();
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR, ST")]
        [HttpGet("{classroomId}")]
        public async Task<IActionResult> GetClassroomById(Guid classroomId)
        {
            var userRole = GetUserRole();
            var userId = GetUserId();

            var response = await _classroomService.GetClassroomById(classroomId);
            return Ok(response);
        }


        [Authorize(Roles = "AD, TR")]
        [HttpPost]
        public async Task<IActionResult> CreateClassroom(AddClassroomRequestDTO request)
        {
            var userId = this.GetUserId();
            var response = await _classroomService.AddClassroom(userId, request);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpPut("{classroomId}")]
        public async Task<IActionResult> UpdateClassroom(Guid classroomId, AddClassroomRequestDTO request)
        {
            var userId = this.GetUserId();
            var response = await _classroomService.UpdateClassroom(userId, classroomId, request);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpDelete("{classroomId}")]
        public async Task<IActionResult> DeleteClassroom(Guid classroomId)
        {
            var userId = this.GetUserId();
            var response = await _classroomService.DeleteClassroom(userId, classroomId);
            return Ok(response);
        }

        // show all classrooms of specific user (teacher/student)
        [Authorize(Roles = "AD, TR, ST")]
        [HttpGet("user")]
        public async Task<IActionResult> GetAllUserClassrooms()
        {
            var userId = GetUserId();
            var userRole = GetUserRole();
            var response = await _classroomService.GetAllUserClassrooms(userId, userRole);
            return Ok(response);
        }




    }
}
