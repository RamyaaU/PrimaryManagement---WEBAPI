using PrimarySchoolManagement.DAL.Exceptions;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrimarySchoolManagement.DAL
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher {Id = 1, Name = "Teacher-A", Subject = "Science", Age= 25, Email= "abc@gmail.com"},
            new Teacher {Id = 2, Name = "Teacher-B", Subject = "Maths", Age= 35, Email= "def@gmail.com"},
            new Teacher {Id = 3, Name = "Teacher-C", Subject = "English", Age= 26, Email= "def@gmail.com"},
        };
        public async Task<List<Teacher>> GetAllAsync()
        {
            return await Task.FromResult(_teachers);
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await Task.FromResult(_teachers.FirstOrDefault(s => s.Id == id));
        }

        public async Task AddAsync(Teacher teacher)
        {
            _teachers.Add(teacher);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            var existingTeacher = _teachers.FirstOrDefault(t => t.Id == teacher.Id);

            if (existingTeacher != null)
            {
                existingTeacher.Name = teacher.Name;
                existingTeacher.Subject = teacher.Subject;
                existingTeacher.Age = teacher.Age;
                existingTeacher.Email = teacher.Email;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);

            if (teacher != null)
            {
                teacher.IsDeleted = true;
            }
            else
            {
                throw new TeacherNotFound("Teacher not found.");
            }
            await Task.CompletedTask;
        }

        //public async Task<List<Teacher>> GetFilterTeacherAsync(Func<Teacher, bool> filter)
        //{
        //    return await Task.FromResult(_teachers.Where(filter).ToList());
        //}

        public async Task<List<Teacher>> FilterTeacherByName(string name)
        {
            return await Task.FromResult(_teachers.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}
