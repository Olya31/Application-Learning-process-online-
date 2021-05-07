using HomeWork.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.ViewModel
{
    public sealed class GroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Group ToGroup()
        {
            return new Group
            {
                Id = this.Id,
                Name = this.Name,               
            };
        }
    }
}
