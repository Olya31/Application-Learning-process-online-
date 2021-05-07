using System.Collections.Generic;

namespace HomeWork.DAL.Model
{
    public sealed class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> Students = new List<Student>();

        public List<Subject> Subjects = new List<Subject>();
    }
}
