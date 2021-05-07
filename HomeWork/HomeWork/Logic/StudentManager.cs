using HomeWork.DAL;
using HomeWork.DAL.Model;
using HomeWork.Logic.Interfaces;
using HomeWork.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Logic
{
    

    public sealed class StudentManager : IManager, IStudentManager
    {
        private readonly DbContextFactory _dbContextFactory;

        public StudentManager()
        {
            _dbContextFactory = new DbContextFactory();
        }

        public void AddStudent(StudentViewModel student)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            dbContext.Students.Add(student.ToStudent());

            dbContext.SaveChanges();
        }

        public void EditStudent(StudentViewModel student)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var studentDb = dbContext.Students.Find(student.Id);

            if (studentDb != null)
            {
                studentDb.GroupId = student.GroupId;
                studentDb.LastName = student.LastName;
                studentDb.FirstName = student.FirstName;
                studentDb.MarkId = student.MarkId;

                dbContext.Students.Update(studentDb);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var studentDb = dbContext.Students.Find(id);

            if (studentDb != null)
            {
                dbContext.Students.Remove(studentDb);
                dbContext.SaveChanges();
            }
            
        }

        public List<StudentViewModel> GetStudentsByGroupId(int groupId)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var studentsDb = dbContext.Students.Where(s => s.GroupId == groupId).ToList();

            var studentsViewModel = new List<StudentViewModel>();

            foreach(var groupsId in studentsDb)
            {
                var item = ToStudentViewModel(groupsId);
                studentsViewModel.Add(item);
            }

            return studentsViewModel;
        }

        private StudentViewModel ToStudentViewModel(Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId,
                MarkId = student.MarkId,
            };
        }            
    }
}
