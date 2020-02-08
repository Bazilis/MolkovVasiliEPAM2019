using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.ReportsDataModels
{
    /// <summary>
    /// Data model for session group grades report
    /// </summary>
    public class GroupGradesResults
    {
        public string GroupName { get; set; }
        public double MinGradeOfStudents { get; set; }
        public double MaxGradeOfStudents { get; set; }
        public double AverageGradeOfStudents { get; set; }
    }
}
