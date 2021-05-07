using System.Collections.Generic;

namespace HomeWork.DAL.Model
{
    public sealed class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Group> Groups = new List<Group>();
    }
}
