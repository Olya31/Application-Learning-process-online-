using HomeWork.DAL.Model;

namespace HomeWork.ViewModel
{
    public sealed class StudentViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GroupId { get; set; }

        public int? MarkId { get; set; }

        public Student ToStudent()
        {
            return new Student
            {
                FirstName = this.FirstName,
                GroupId = this.GroupId,
                Id = this.Id,
                LastName = this.LastName,
                MarkId = this.MarkId,
            };
        }
    }
}
