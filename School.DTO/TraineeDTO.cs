using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.DTO
{
    public class TraineeDTO : EntityDTO
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
