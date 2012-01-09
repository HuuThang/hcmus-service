using System;
using System.Collections.Generic;

using System.Text;

namespace DAO
{
    public  class Comm
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            set
            {
                
                _connectionString = value;
            }
            get
            {
                return _connectionString;
            }
        }
        private static int _pageSize;

        public static int PageSize
        {
            get { return Comm._pageSize; }
            set { Comm._pageSize = value; }
        }

    }
}
