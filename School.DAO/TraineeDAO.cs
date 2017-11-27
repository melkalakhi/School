using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.DAO
{
    public class TraineeDAO : EntityDAO<DTO.TraineeDTO>
    {

        private static TraineeDAO _Instance;
        public static TraineeDAO Instance
        {
            get 
            {
                _Instance = _Instance ?? new TraineeDAO();
                return _Instance; 
            }
        }

        private TraineeDAO() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeDto"></param>
        /// <returns></returns>
        public override int Add(DTO.TraineeDTO traineeDto)
        {
            try
            {
                POCO.Trainee trainee = new POCO.Trainee();
                trainee.Name = traineeDto.Name ?? string.Empty;
                trainee.FirstName = traineeDto.FirstName ?? string.Empty;

                if (traineeDto.Courses != null)
                {
                    POCO.Course course = null;
                    foreach (DTO.CourseDTO courseDto in traineeDto.Courses)
                    {
                        course = ContextDAO.Instance.Course.FirstOrDefault(_course => _course.ID == courseDto.ID);
                        if (course != null)
                        {
                           trainee.Course.Add(course); 
                        }
                    }
                }

                ContextDAO.Instance.Trainee.AddObject(trainee);
                SaveChanges();
                return trainee.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeDto"></param>
        public override void Update(DTO.TraineeDTO traineeDto)
        {
            try
            {
                // Modification du nom et prènom du stagiaire
                POCO.Trainee trainee = ContextDAO.Instance.Trainee.FirstOrDefault(_trainee => _trainee.ID == traineeDto.ID);
                trainee.Name = traineeDto.Name ?? string.Empty;
                trainee.FirstName = traineeDto.FirstName ?? string.Empty;

                // Cours à supprimés
                if (trainee.Course != null)
                {
                    IList<POCO.Course> coursesToDelete = trainee.Course.Where(course => traineeDto.Courses.FirstOrDefault(_courseDto => _courseDto.ID == course.ID) == null).ToList();
                    if (coursesToDelete != null && coursesToDelete.Count > 0)
                    {
                        foreach (POCO.Course course in coursesToDelete)
                        {
                            trainee.Course.Remove(course);
                        }
                    }
                }

                // Cours à ajoutés
                if (traineeDto.Courses != null)
                {
                    IList<DTO.CourseDTO> coursesToAdd = traineeDto.Courses.Where(courseDto => trainee.Course.FirstOrDefault(_course => _course.ID == courseDto.ID) == null).ToList();
                    if (coursesToAdd != null && coursesToAdd.Count > 0)
                    {
                        POCO.Course course = null;
                        foreach (DTO.CourseDTO courseDto in coursesToAdd)
                        {
                            course = ContextDAO.Instance.Course.FirstOrDefault(_course => _course.ID == courseDto.ID);
                            if (course != null)
                            {
                                trainee.Course.Add(course);
                            }
                        }
                    }
                }

                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeDto"></param>
        public override void Delete(DTO.TraineeDTO traineeDto)
        {
            try
            {
                POCO.Trainee trainee = ContextDAO.Instance.Trainee.FirstOrDefault(_trainee => _trainee.ID == traineeDto.ID);
                if (trainee.Course.Count() > 0)
                {
                    trainee.Course.Clear();
                }

                ContextDAO.Instance.Trainee.DeleteObject(trainee);

                SaveChanges();
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
        public override IEnumerator<DTO.TraineeDTO> GetEnumerator()
        {
            DTO.TraineeDTO traineeDto = null;
            foreach (POCO.Trainee trainee in ContextDAO.Instance.Trainee)
            {
                traineeDto = new DTO.TraineeDTO();
                traineeDto.ID = trainee.ID;
                traineeDto.Name = trainee.Name ?? string.Empty;
                traineeDto.FirstName = trainee.FirstName ?? string.Empty;
                traineeDto.Courses = trainee.Course.Select(course => new DTO.CourseDTO() { ID = course.ID, NumberOfDays = course.NumberOfDays, Wording = course.Wording });
                yield return traineeDto;
            }
        }
    }
}
