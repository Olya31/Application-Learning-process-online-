using HomeWork.Logic;
using HomeWork.ViewModel;
using System;


namespace HomeWork
{
    class Program
    {
        private static readonly SubjectManager subjectManager = new SubjectManager();
        private static readonly TeacherManager teacherManager = new TeacherManager();
        private static readonly StudentManager studentManager = new StudentManager();
        private static readonly GroupManager groupManager = new GroupManager();
        private static readonly MarkManager markManager = new MarkManager();


        static void Start()
        {
            Console.WriteLine("\nWelcome to our application 'Learning process online'");
            Console.WriteLine("\nEnter the number desired function. " +
                "\n1.Show for list of groups" +
                "\n2.Show for list of subject" +
                "\n3.Show for list of teacher");

            var result = int.Parse(Console.ReadLine());

            if (result == 1)
            {
                ChoiseOne();
            }
            else if (result == 2)
            {
                ChoiceTwo();
                SubjectChanges();
            }
            else if (result == 3)
            {
                ChoiceTree();
                TeacherChanges();
            }
            else
            {
                Console.WriteLine("You are wrong.");
                Start();
            }

        }

        static void ChoiseOne()
        {
            var groups = groupManager.GetAllGroup();

            Console.WriteLine("\nList all groups");

            foreach (var group in groups)
            {
                Console.WriteLine($"Id - {group.Id}, Name - {group.Name}");
            }

            Console.WriteLine("\nWant to change this group:" +
                "\nYes or No");

            var choiceStr = Console.ReadLine();
            if (choiceStr == "Yes")
            {
                GroupChanges();
            }
            else if (choiceStr == "No")
            {
                ChoiceStudent();
            }
            else
            {
                Console.WriteLine("\nYou are wrong.");
            }
        }

        static void ChoiceTwo()
        {
            var subjects = subjectManager.GetAllSubject();

            Console.WriteLine("\nList all subject");

            foreach (var subject in subjects)
            {
                Console.WriteLine($"Id - {subject.Id}, Name - {subject.Name}");
            }
        }

        static void ChoiceTree()
        {
            var teachers = teacherManager.GetAllTeacher();

            Console.WriteLine("\nList all teacher");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Id - {teacher.Id}, Fist Name - {teacher.FirstName}, Last Name - {teacher.LastName}, SubjectId - {teacher.SubjectId}");
            }
        }

        static void ChoiceStudent()
        {
            Console.WriteLine("\nWant you see students from some group?" +
                "\nYes or No");

            var changeStr = Console.ReadLine();
            if (changeStr == "Yes")
            {
                ShowStudentsByGroupId();
                StudentsChanges();
            }
            else if (changeStr == "No")
            {
                Start();
            }
            else
            {
                Console.WriteLine("\nYou are wrong.");
                ChoiceStudent();
            }
        }

        static void ShowStudentsByGroupId()
        {
            Console.WriteLine("\nEnter the groupId for get students from this group.");

            var groupIdStr = Console.ReadLine();

            if (int.TryParse(groupIdStr, out var groupId))
            {
                var studentManager = new StudentManager();

                var students = studentManager.GetStudentsByGroupId(groupId);

                Console.WriteLine($"\nList students from {groupId} groupId");

                foreach (var student in students)
                {
                    Console.WriteLine($"First Name - {student.FirstName}, Last Name - {student.LastName}, MarkId - {student.MarkId}");
                }
            }

            else
            {
                Console.WriteLine("You are wrong.");
                ShowStudentsByGroupId();
            }
        }

        static void StudentsChanges()
        {
            Console.WriteLine("\nWant you: " +
                "\n1.Add new student," +
                "\n2.Delete student," +
                "\n3.Edit student" +
                "\n4.Add mark" +
                "\n5.Exit");
            var change = int.Parse(Console.ReadLine());
            if (change == 1)
            {
                AddStudent();
            }
            else if (change == 2)
            {
                DeleteStudent();
            }
            else if (change == 3)
            {
                EditStudent();
            }
            else if (change == 4)
            {
                AddMark();
            }
            else if (change == 5)
            {
                ReturnStart();
            }
            else
            {
                Console.WriteLine("\nYou are wrong.");
                StudentsChanges();
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\nEnter the First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nEnter the Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("\nEnter the groupId");
            var groupId = int.Parse(Console.ReadLine());

            var studentViewModel = new StudentViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                GroupId = groupId
            };

            studentManager.AddStudent(studentViewModel);

            Console.WriteLine("\nStudent added successfully");
            ReturnStart();
        }

        static void DeleteStudent()
        {
            Console.WriteLine("\nEnter studentId");

            var studentIdStr = Console.ReadLine();

            if (int.TryParse(studentIdStr, out var studentId))
            {
                studentManager.Delete(studentId);
            }

            Console.WriteLine("\nStudent deleted successfully");
            ReturnStart();

        }

        static void EditStudent()
        {
            Console.WriteLine("\nEnter studentId for edit this line");
            var studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter new First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nEnter new Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("\nEnter new groupId");
            var groupId = int.Parse(Console.ReadLine());

            var studentViewModel = new StudentViewModel
            {
                Id = studentId,
                FirstName = firstName,
                LastName = lastName,
                GroupId = groupId
            };

            studentManager.EditStudent(studentViewModel);
            Console.WriteLine("\nStudent edited successfully");
            ReturnStart();

        }

        static void GroupChanges()
        {
            Console.WriteLine("\nWant you: " +
                "\n1.Add new group," +
                "\n2.Delete group," +
                "\n3.Edit group" +
                "\n4.Exit");
            var change = int.Parse(Console.ReadLine());
            if (change == 1)
            {
                AddGroup();
            }
            else if (change == 2)
            {
                DeleteGroup();
            }
            else if (change == 3)
            {
                EditGroup();
            }
            else if (change == 4)
            {
                ReturnStart();
            }
            else
            {
                Console.WriteLine("You are wrong.");
                StudentsChanges();
            }

        }

        static void AddGroup()
        {
            Console.WriteLine("\nEnter the name of the group");
            var name = Console.ReadLine();

            var groupViewModel = new GroupViewModel
            {
                Name = name,
            };

            groupManager.AddGroup(groupViewModel);

            Console.WriteLine("\nGroup added successfully");
            ReturnStart();
        }

        static void DeleteGroup()
        {
            Console.WriteLine("\nEnter groupId");

            var groupIdStr = Console.ReadLine();

            if (int.TryParse(groupIdStr, out var groupId))
            {
                groupManager.Delete(groupId);
            }

            Console.WriteLine("\nGroup deleted successfully");
            ReturnStart();
        }

        static void EditGroup()
        {
            Console.WriteLine("\nEnter groupId for edit this line");
            var groupId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter new Name group");
            var name = Console.ReadLine();

            var groupViewModel = new GroupViewModel
            {
                Id = groupId,
                Name = name
            };

            groupManager.EditGroup(groupViewModel);

            Console.WriteLine("\nGroup edited successfully");
            ReturnStart();
        }

        static void SubjectChanges()
        {
            Console.WriteLine("\nWant you: " +
                "\n1.Add new subject," +
                "\n2.Delete subject," +
                "\n3.Edit subject" +
                "\n4.Exit");
            var change = int.Parse(Console.ReadLine());
            if (change == 1)
            {
                AddSubject();
            }
            else if (change == 2)
            {
                DeleteSubject();
            }
            else if (change == 3)
            {
                EditSubject();
            }
            else if (change == 4)
            {
                ReturnStart();
            }
            else
            {
                Console.WriteLine("\nYou are wrong.");
                StudentsChanges();
            }

        }

        static void AddSubject()
        {
            Console.WriteLine("\nEnter the name of the discipline");
            var name = Console.ReadLine();

            var subjectViewModel = new SubjectViewModel
            {
                Name = name,
            };

            subjectManager.AddSubject(subjectViewModel);

            Console.WriteLine("\nSubject added successfully");
            ReturnStart();
        }

        static void DeleteSubject()
        {
            Console.WriteLine("\nEnter subjectId");

            var subjectIdStr = Console.ReadLine();

            if (int.TryParse(subjectIdStr, out var subjectId))
            {
                subjectManager.Delete(subjectId);
            }

            Console.WriteLine("\nSubject deleted successfully");
            ReturnStart();
        }

        static void EditSubject()
        {
            Console.WriteLine("\nEnter subjectId for edit this line");
            var subjectId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter new Name subject");
            var subjectName = Console.ReadLine();

            var subjectViewModel = new SubjectViewModel
            {
                Id = subjectId,
                Name = subjectName
            };

            subjectManager.EditSubject(subjectViewModel);

            Console.WriteLine("\nSubject edited successfully");
            ReturnStart();
        }

        static void TeacherChanges()
        {
            Console.WriteLine("\nWant you: " +
                "\n1.Add new teacher," +
                "\n2.Delete teacher," +
                "\n3.Edit teacher" +
                "\n4.Exit");
            var change = int.Parse(Console.ReadLine());
            if (change == 1)
            {
                AddTeacher();
            }
            else if (change == 2)
            {
                DeleteTeacher();
            }
            else if (change == 3)
            {
                EditTeacher();
            }
            else if (change == 4)
            {
                ReturnStart();
            }
            else
            {
                Console.WriteLine("\nYou are wrong.");
                StudentsChanges();
            }
        }

        static void AddMark()
        {
            Console.WriteLine("\nEnter a mark from 1 to 10");
            var score = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter a subjectId");
            var subjectId = int.Parse(Console.ReadLine());


            if (score == 1 & score <= 10)
            {
                var markViewModel = new MarkViewModel
                {
                    Score = score,
                    SubjectId = subjectId
                };

                markManager.AddMark(markViewModel);

                Console.WriteLine("\nMark added successfully");
                ReturnStart();
            }
            else
            {
                Console.WriteLine("\nYou are wrong.");
                AddMark();
            }
        }

        static void AddTeacher()
        {
            Console.WriteLine("\nEnter the First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nEnter the Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("\nEnter the subjectId");
            var subjectId = int.Parse(Console.ReadLine());

            var teacherViewModel = new TeacherViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                SubjectId = subjectId
            };

            teacherManager.AddTeacher(teacherViewModel);

            Console.WriteLine("\nTeacher added successfully");
            ReturnStart();
        }

        static void DeleteTeacher()
        {
            Console.WriteLine("\nEnter subjectId");

            var teacherIdStr = Console.ReadLine();

            if (int.TryParse(teacherIdStr, out var teacherId))
            {
                teacherManager.Delete(teacherId);
            }

            Console.WriteLine("\nTeacher deleted successfully");

            ReturnStart();
        }

        static void EditTeacher()
        {
            Console.WriteLine("\nEnter teacherId for edit this line");
            var teacherId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter new First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nEnter new Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("\nEnter new subjectId");
            var subjectId = int.Parse(Console.ReadLine());

            var teacherViewModel = new TeacherViewModel
            {
                Id = teacherId,
                FirstName = firstName,
                LastName = lastName,
                SubjectId = subjectId
            };

            teacherManager.EditTeacher(teacherViewModel);

            Console.WriteLine("\nTeacher edited successfully");

            ReturnStart();
        }

        static void ReturnStart()
        {
            Console.WriteLine("\nWant to return to the main menu?" +
                "\nYes or No");

            var returnStart = Console.ReadLine();
            {
                if (returnStart == "Yes")
                {
                    Start();
                }
                else
                {
                    Console.WriteLine("\nThanks for using our application");
                }
            }

        }

        static void Main(string[] args)
        {
            Start();
            Console.ReadLine();
        }
    }
}
