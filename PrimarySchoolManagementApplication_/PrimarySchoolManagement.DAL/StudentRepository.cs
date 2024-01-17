using PrimarySchoolManagement.DAL.Exceptions;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _student = new List<Student>
        {
            new Student {Id = 1, Name = "Ryan", Age=5, Grade="1B", Subject="English"},
            new Student {Id = 2, Name = "Alex", Age=5, Grade="1A", Subject="Kannada"},
            new Student {Id = 3, Name = "Syed", Age=7, Grade="2C", Subject="Sanskrit"},
        };

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await Task.FromResult(_student);
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await Task.FromResult(_student.FirstOrDefault(s => s.Id == id));
        }

        public async Task AddStudentAsync(Student student)
        {
            _student.Add(student);
            await Task.CompletedTask;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            var existingStudent = _student.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Subject = student.Subject;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = _student.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                student.IsDeleted = true;
            }
            else
            {
                throw new StudentNotFound("Student not found.");
            }
            await Task.CompletedTask;
        }
        
        public async Task<List<Student>> FilterStudentAsyncByName(string name)
        {
            return await Task.FromResult(_student.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}
