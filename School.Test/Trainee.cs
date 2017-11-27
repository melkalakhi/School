using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace School.Test
{
    public class Trainee
    {
        [TestCase("ELKAHI", "Mohad", "ELKALAKHI", "Mohammed", "MVC4", 7)]
        [TestCase("ELKAI", "Me", "ELKALAKHI", "Mehdi", "EF", 4)]
        [TestCase("ZAI", "dil", "ZAOUI", "Adil", "MVC5", 10)]
        public void TestTrainee(string WrongName, string WrongFirstName, string RightName, string RightFirstName, string Wording, int NumberOfDays)
        {

            // Nombre de stagiaires presents dans la base de données
            int count = DAO.TraineeDAO.Instance.Count();

            // Affichage des stagiaires et leurs cours
            IList<DTO.TraineeDTO> traineeDTOs = DAO.TraineeDAO.Instance.ToList();
            IList<DTO.CourseDTO> courseDTOs = null;
            foreach (DTO.TraineeDTO trainee in traineeDTOs)
            {
                courseDTOs = trainee.Courses.ToList();
            }

            // Ajout d'un stagiaire
            DTO.TraineeDTO traineeDto = new DTO.TraineeDTO();
            traineeDto.Name = WrongName;
            traineeDto.FirstName = WrongFirstName;

            // Ajouter un cours
            //DTO.CourseDTO courseDTO = new DTO.CourseDTO() { Wording = Wording, NumberOfDays = NumberOfDays };
            //courseDTO.ID = DAO.CourseDAO.Instance.Add(courseDTO);

            // Affecter un cours au stagiaire
            traineeDto.Courses = LoadCourseEnumerable();

            traineeDto.ID = DAO.TraineeDAO.Instance.Add(traineeDto);

            Assert.AreEqual(DAO.TraineeDAO.Instance.Count(), count + 1);
            
            // Modification du stagiaire
            traineeDto.Name = RightName;
            traineeDto.FirstName = RightFirstName;
            traineeDto.Courses = LoadCourseEnumerable2();
            DAO.TraineeDAO.Instance.Update(traineeDto);

            // Suppression du stagiaire
            DAO.TraineeDAO.Instance.Delete(traineeDto);

            Assert.AreEqual(DAO.TraineeDAO.Instance.Count(), count);
        }

        private IEnumerable<DTO.CourseDTO> LoadCourseEnumerable()
        {
            yield return new DTO.CourseDTO() { ID = 3 };
            yield return new DTO.CourseDTO() { ID = 1 };
        }

        private IEnumerable<DTO.CourseDTO> LoadCourseEnumerable2()
        {
            yield return new DTO.CourseDTO() { ID = 1 };
            yield return new DTO.CourseDTO() { ID = 2 };
        }
    }
}
