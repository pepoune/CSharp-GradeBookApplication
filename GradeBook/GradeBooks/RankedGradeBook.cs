using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char res = 'F';
            int numberOfStudents = Students.Count;
            if (numberOfStudents < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int numberOfStudentsAbove = 0;
            foreach(var Student in Students)
            {
                if(Student.AverageGrade > averageGrade)
                {
                    numberOfStudentsAbove++;
                }
            }

            double percentageOfStudentsAbove = 100.0 * numberOfStudentsAbove / numberOfStudents;

            if(percentageOfStudentsAbove < 20)
            {
                res = 'A';
            }
            else if(percentageOfStudentsAbove < 40)
            {
                res = 'B';
            }
            else if(percentageOfStudentsAbove < 60)
            {
                res = 'C';
            }
            else if(percentageOfStudentsAbove < 80)
            {
                res = 'D';
            }

            return res;
        }

        public override void CalculateStatistics()
        {
            int numberOfStudents = Students.Count;
            if(numberOfStudents < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            int numberOfStudentsWithGrade = 0;
            
            foreach(var student in Students)
            {
                if (student.Grades.Count > 0)
                {
                    numberOfStudentsWithGrade++;
                }
            }

            if(numberOfStudentsWithGrade < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
