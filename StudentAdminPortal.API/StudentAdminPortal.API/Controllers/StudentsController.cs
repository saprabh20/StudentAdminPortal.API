using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Domain_Models;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{

    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();
            
            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //fetch single student details
            var student = await studentRepository.GetStudentAsync(studentId);

            //return student
            if(student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<Student>(student));    
            }
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if(await studentRepository.Exists(studentId))
            {
                //Update details
                var updatedStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<Data_Models.Student>(request));
                if(updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }
            return NotFound();            
        }
    }
}
