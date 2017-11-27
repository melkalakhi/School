using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace School.Test
{
    public class Course
    {
        [TestCase("MVC4", 7, "MVC5", 10)]
        [TestCase("EF", 4, "EF code first", 6)]
        public void TestCourse(string oldWording, int oldNumberOfDays, string newWording, int newNumberOfDays)
        {
            // Nombre de cours présents dans la base de données
            int count = DAO.CourseDAO.Instance.Count();

            // Liste des cours et des stagiaires qui sont afféctés
            IList<DTO.CourseDTO> courseDTOs = DAO.CourseDAO.Instance.ToList();
            if (courseDTOs != null)
            {
                IList<DTO.TraineeDTO> traineeDTOs = null;
                foreach (DTO.CourseDTO _courseDTO in courseDTOs)
                {
                    traineeDTOs = _courseDTO.Trainees.ToList();
                }
            }

            // Ajouter un cours
            DTO.CourseDTO courseDTO = new DTO.CourseDTO() { Wording = oldWording, NumberOfDays = oldNumberOfDays };
            courseDTO.ID = DAO.CourseDAO.Instance.Add(courseDTO);

            Assert.AreEqual(DAO.CourseDAO.Instance.Count(), count + 1);

            // Modification du cours
            courseDTO.Wording = newWording;
            courseDTO.NumberOfDays = newNumberOfDays;
            DAO.CourseDAO.Instance.Update(courseDTO);

            // Supprimer le cours
            DAO.CourseDAO.Instance.Delete(courseDTO);

            Assert.AreEqual(DAO.CourseDAO.Instance.Count(), count);
        }
    }
}
