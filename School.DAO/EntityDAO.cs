using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace School.DAO
{
    public abstract class EntityDAO<T> : IEntityDAO<T> where T : DTO.EntityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        public abstract int Add(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        public abstract void Update(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        public abstract void Delete(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        public void SaveChanges()
        {
            ContextDAO.Instance.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator<T> GetEnumerator();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
