using System.Collections.Generic;
using ContosoUniversity.Models;

namespace ContosoUniversity.ViewModels
{
    public class CourseWithHelp
    {
        public IEnumerable<ContextHelp> ContextHelps { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public Course Course { get; set; }
    }
}