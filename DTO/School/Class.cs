using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.School
{
    public class Class
    {
        public int ClassId { get; set; }
        public int AcademicYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastmodifiedDate { get; set; }

    }

    public class Course {
        public int CourseId { get; set; }
        public string CourseDescription { get; set; }
        public int Status { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastmodifiedDate { get; set; }

    }

    public class Student {
        public int StudentId { get; set; }
        public int EntityId { get; set; }
        public int EnrolmentNo { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastmodifiedDate { get; set; }
    }
}
