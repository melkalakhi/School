using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.DAO
{
    public class CourseDAO : EntityDAO<DTO.CourseDTO>
    {

        private static CourseDAO _Instance;
        public static CourseDAO Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new CourseDAO();
                }
                return _Instance;
            }
        }

        private CourseDAO() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseDto"></param>
        /// <returns></returns>
        public override int Add(DTO.CourseDTO courseDto)
        {
            try
            {
                POCO.Course course = new POCO.Course();
                course.NumberOfDays = courseDto.NumberOfDays;
                course.Wording = courseDto.Wording;
                DAO.ContextDAO.Instance.Course.AddObject(course);
                SaveChanges();
                return course.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseDto"></param>
        public override void Update(DTO.CourseDTO courseDto)
        {
            try
            {
                if (courseDto != null)
                {
                    POCO.Course course = DAO.ContextDAO.Instance.Course.FirstOrDefault(_course => _course.ID == courseDto.ID);
                    if (course != null)
                    {
                        course.NumberOfDays = courseDto.NumberOfDays;
                        course.Wording = courseDto.Wording;
                        SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseDto"></param>
        public override void Delete(DTO.CourseDTO courseDto)
        {
            try
            {
                POCO.Course course = DAO.ContextDAO.Instance.Course.FirstOrDefault(_course => _course.ID == courseDto.ID);
                if (course != null && course.Trainee.Count <= 0)
                {
                    DAO.ContextDAO.Instance.Course.DeleteObject(course);
                    SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<DTO.CourseDTO> GetEnumerator()
        {
            DTO.CourseDTO courseDto = null;
            foreach (POCO.Course course in DAO.ContextDAO.Instance.Course)
            {
                courseDto = new DTO.CourseDTO();
                courseDto.ID = course.ID;
                courseDto.NumberOfDays = course.NumberOfDays;
                courseDto.Wording = course.Wording;
                courseDto.Trainees = course.Trainee.Select(trainee => new DTO.TraineeDTO() { ID = trainee.ID, Name = trainee.Name, FirstName = trainee.FirstName });
                yield return courseDto;
            }
        }
    }
}
