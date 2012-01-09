using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
namespace DAO
{
    public abstract  class DAO:DB// Class DAO không được new trực tiếp
    {
        public DAO():base()
        {
        }
        protected string _tableName;
        
        public bool FieldExists(IDataReader reader, string FieldName)
        {
            reader.GetSchemaTable().DefaultView.RowFilter = String.Format("ColumnName='{0}'", FieldName);
            return reader.GetSchemaTable().DefaultView.Count > 0;
        }
        
        protected string[] _fileds;
        
        protected  string getSQL()
        {
            return String.Format("Select {0} from {1} Where {2}=@{2}", String.Join(",", _fileds), _tableName, _fileds[0]);
        }
        protected string getListSQL()
        {
            return String.Format("Select {0} from {1}", String.Join(",", _fileds), _tableName);
        }
        protected string insertSQL()
        {
            return String.Format("insert into {0}({1}) values(@{2})", _tableName, String.Join(",", _fileds, 1, _fileds.Length - 1), String.Join(",@", _fileds, 1, _fileds.Length -1));
        }
        protected string updateSQL()
        {
            StringBuilder rs = new StringBuilder();
            if (_fileds.Length > 1)
                rs.AppendFormat("{0}=@{0}", _fileds[1]);
            for (int i = 2; i < _fileds.Length; i++)
            {
                rs.AppendFormat(",{0}=@{0}", _fileds[i]);
            }
            return String.Format("update {0} set {1} where {2} = @{2}", _tableName, rs, _fileds[0]);
        }
        protected string deleteSQL()
        {
            return String.Format("delete from {0} where {1}=@{1}", _tableName, _fileds[0]);
        }
        
        /// <summary>
        /// Các tham số truyền vào theo thứ tự các filed trong database không cần truyền mã số.
        /// Giá trị trả về khác 0 là thành công.
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public int add(params object[] objs)
        {
            try
            {
                Dbmanager.Open();
                Dbmanager.CreateParameters(_fileds.Length - 1);
                // Id auto
                for (int i = 1; i < _fileds.Length; i++)
                {
                    Dbmanager.AddParameters(i - 1, "@" + _fileds[i], objs[i-1]);
                }
                return Dbmanager.ExecuteNonQuery(CommandType.Text, this.insertSQL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                closeConnect();
            }
        }
        /// <summary>
        /// Các tham số truyền vào theo thứ tự các filed trong database(Phải truyền mã số dòng cần sửa).
        /// Giá trị trả về true là thành công. 
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public bool update(params object[] objs)
        {
            try
            {
                Dbmanager.Open();
                Dbmanager.CreateParameters(_fileds.Length);
                for (int i = 0; i < _fileds.Length; i++)
                {
                    Dbmanager.AddParameters(i, "@" + _fileds[i], objs[i]);
                }
                return Dbmanager.ExecuteNonQuery(CommandType.Text, this.updateSQL()) != 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                closeConnect(); 
            }
        }
        /// <summary>
        /// Truyền vào mã số dòng cần xóa
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool delete(object obj)
        {
            try
            {

                Dbmanager.Open();
                Dbmanager.CreateParameters(1);
                Dbmanager.AddParameters(0, "@" + _fileds[0], obj);
                return Dbmanager.ExecuteNonQuery(CommandType.Text, this.deleteSQL()) != 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                closeConnect();
            }
        }
        protected IDataReader get(object id)
        {
            try
            {
                _dbmanager.CreateParameters(1);
                _dbmanager.AddParameters(0, "@" + _fileds[0], id);
                return _dbmanager.ExecuteReader(CommandType.Text, this.getSQL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected IDataReader getList()
        {
            try
            {
                return _dbmanager.ExecuteReader(CommandType.Text, this.getListSQL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected IDataReader getList(string _sql, string _strChuoiDieuKien)
        {
            try
            {
                Dbmanager.CreateParameters(1);
                Dbmanager.AddParameters(0, "@dk", _strChuoiDieuKien);
                return Dbmanager.ExecuteReader(CommandType.Text, _sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected IDataReader getList(string _sql)
        {
            try
            {
                return Dbmanager.ExecuteReader(CommandType.Text, _sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected DataTable getTable(string _sql)
        {
            try
            {
                return Dbmanager.ExecuteDataSet(CommandType.Text, _sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
