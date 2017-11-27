using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace School.DAO
{
    public class ContextDAO : Model.SchoolModelContainer
    {
        /// <summary>
        /// 
        /// </summary>
        private ContextDAO(string connectionString) : base(connectionString) { this.ContextOptions.LazyLoadingEnabled = true; }

        /// <summary>
        /// 
        /// </summary>
        public static ContextDAO Instance
        {
            get
            {
                _Instance = _Instance ?? new ContextDAO(ConfigurationManager.ConnectionStrings["SchoolModelContainer"].ConnectionString);
                return _Instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static ContextDAO _Instance;

    }
}
