using HomeWork.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.ViewModel
{
    public sealed class SubjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Subject ToSubject()
        {
            return new Subject
            {
                Id = this.Id,
                Name = this.Name,
            };
        }

    }
}
