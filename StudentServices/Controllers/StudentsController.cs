using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Shared;
using StudentServices.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentsServices studentsServices;
        public StudentsController(StudentsServices _studentServices)
        {
            studentsServices = _studentServices;
        }

        [HttpGet]
        public async Task<Students[]> StudentList()
        {
            var lst = await studentsServices.StudentsList();

            return lst.ToArray();
        }

        [HttpGet("data")]
        public async Task<Students[]> StudentSearch(string data)
        {
            var lst = await studentsServices.StudentsSearch(data);

            return lst.ToArray();
        }

        [HttpPost]
        public async Task<int> StudentSave(Students s)
        {
            var lst = await studentsServices.StudentsSave(s);

            return lst;
        }

        [HttpGet]
        public async Task<int> StudentDelete(string id)
        {
            var lst = await studentsServices.StudentsDelete(id);

            return lst;
        }

    }
}
