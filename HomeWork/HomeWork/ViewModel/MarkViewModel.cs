using HomeWork.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.ViewModel
{
    public sealed class MarkViewModel
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int SubjectId { get; set; }

        public Mark ToMark()
        {
            return new Mark
            {
                Id = this.Id,
                Score = this.Score,
                SubjectId = this.SubjectId,
            };
        }
    }
}
