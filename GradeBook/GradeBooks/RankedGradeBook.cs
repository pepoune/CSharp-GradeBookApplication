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
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }
            return res;
        }
    }
}
