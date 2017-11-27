using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.DTO
{
    public class CourseDTO : EntityDTO
    {
        public string Wording { get; set; }

        public int NumberOfDays { get; set; }

        public IEnumerable<TraineeDTO> Trainees { get; set; }
    }
}
