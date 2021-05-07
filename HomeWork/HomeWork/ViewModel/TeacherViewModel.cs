using HomeWork.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.ViewModel
{
    public sealed class TeacherViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SubjectId { get; set; }

        public Teacher ToTeacher()
        {
            return new Teacher
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                SubjectId = this.SubjectId,
            };
        }
    }
}
