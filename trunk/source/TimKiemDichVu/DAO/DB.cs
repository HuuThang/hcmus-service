using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccessLayer;
namespace DAO
{
   public class DB
    {
        protected DBManager _dbmanager;

        public DBManager Dbmanager
        {
            get { return _dbmanager; }
            set { _dbmanager = value; }
        }

        public DB()
        {
            _dbmanager = new DBManager(DataProvider.OleDb, Comm.ConnectionString);
        }
        protected  void openConnect()
        {
            Dbmanager.Open();
        }
        protected void closeConnect()
        {
            if (Dbmanager != null && Dbmanager.Connection.State == ConnectionState.Open)
                Dbmanager.Close();
        }
        
    }
}
