namespace HomeWork.DAL.Model
{
    public sealed class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int? MarkId { get; set; }

        public Mark Mark { get; set; }
    }
}
