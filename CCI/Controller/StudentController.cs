﻿using CCI.Data;
using CCI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpPost]
        public async Task CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();

            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();
        }
    }
}
