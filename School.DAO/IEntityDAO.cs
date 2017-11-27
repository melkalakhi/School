using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.DAO
{
    public interface IEntityDAO<T> : IEnumerable<T> where T : DTO.EntityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        int Add(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        void Update(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        void Delete(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();
    }
}
