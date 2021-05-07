namespace HomeWork.DAL.Model
{
    public sealed class Mark
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public Student Student { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
