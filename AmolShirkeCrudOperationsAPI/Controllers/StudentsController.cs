﻿using AmolShirkeCrudOperationsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AmolShirkeCrudOperationsAPI.Repositories.StudentRepository;

namespace AmolShirkeCrudOperationsAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();

            if (students == null)
            {
                return NotFound("There is no students in database yet!");
            }
            return Ok(students);
        }
    }
}
