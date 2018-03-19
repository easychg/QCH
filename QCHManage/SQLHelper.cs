using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace QCHManage
{
    public class SQLHelper
    {
        // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <remarks>
        /// 使用示例：
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText,  params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = ConnectionManger.GetConnection())
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();

                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        ///执行一条不返回结果的SqlCommand，通过一个已经存在的数据库连接 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个现有的数据库连接</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        //public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        //{

        //    SqlCommand cmd = new SqlCommand();
        //    using (SqlConnection conn = ConnectionManger.GetConnection())
        //    {
        //        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

        //        int val = cmd.ExecuteNonQuery();
        //        cmd.Parameters.Clear();
        //        return val;
        //    }
        //}

        /// <summary>
        /// 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库事物处理 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例： 
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个存在的 sql 事物处理</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果的SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText,  params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = ConnectionManger.GetConnection();

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                throw;
            }
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = ConnectionManger.GetConnection())
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static DataSet DataSetBind(CommandType cmdType, string cmdText,  params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();


            using (SqlConnection connection = ConnectionManger.GetConnection())
            {
                DataSet ds = new DataSet();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                //object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例： 
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个已经存在的数据库连接</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 缓存参数数组
        /// </summary>
        /// <param name="cacheKey">参数缓存的键值</param>
        /// <param name="cmdParms">被缓存的参数列表</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 获取被缓存的参数
        /// </summary>
        /// <param name="cacheKey">用于查找参数的KEY值</param>
        /// <returns>返回缓存的参数数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            //新建一个参数的克隆列表
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            //通过循环为克隆参数列表赋值
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                //使用clone方法复制参数列表中的参数
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }


        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        /// <summary>
        /// 通过数据集来绑定数据
        /// </summary>
        /// <param name="str">SQL语句/存储过程CommandType.Text/CommandType.StoredProcedure </param>
        /// <returns></returns>
        public static DataSet GetDataSet(string str, CommandType cmdtype)
        {
            SqlConnection conn = ConnectionManger.GetConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.CommandType = cmdtype;
                SqlDataAdapter da = new SqlDataAdapter(str, conn);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                conn.Close();
                throw;

            }
        }

        /// <summary>
        /// 带参数绑定数据
        /// </summary>
        /// <param name="str">存储过程</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string str, CommandType cmdtype,  SqlParameter[] cmdParm)
        {
            SqlConnection conn = ConnectionManger.GetConnection();
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.CommandText = str;
                cmd.CommandType = cmdtype;
                //PrepareCommand(cmd, conn, null, cmdtype, str, parm);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                foreach (SqlParameter parm in cmdParm)
                {
                    cmd.Parameters.Add(parm);
                }
                da.Fill(ds);
                return ds;
            }
            catch
            {
                conn.Close();
                throw;

            }
        }

        /// <summary>
        /// 通过分页存储过程绑定数据
        /// </summary>
        /// <param name="tablename">表、视图名</param>
        /// <param name="fieldkey">关键字</param>
        /// <param name="currentpage">当前页数</param>
        /// <param name="pagesize">每页的数量</param>
        /// <param name="fieldshow">显示的字段</param>
        /// <param name="fieldorder">排序方式</param>
        /// <param name="where">条件</param>
        /// <param name="recordcount">总计页数</param>
        /// <returns></returns>
        public static DataSet GetGriview(string tablename, string fieldkey, int currentpage, int pagesize, string fieldshow, string fieldorder, string where, ref int recordcount)
        {

            SqlConnection conn = ConnectionManger.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("pageination", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tbname", SqlDbType.NVarChar, 50).Value = tablename;
            cmd.Parameters.Add("@FieldKey", SqlDbType.NVarChar, 50).Value = fieldkey;
            cmd.Parameters.Add("@PageCurrent", SqlDbType.Int).Value = currentpage;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pagesize;
            cmd.Parameters.Add("@FieldShow", SqlDbType.NVarChar, 1000).Value = fieldshow;
            cmd.Parameters.Add("@FieldOrder", SqlDbType.NVarChar, 50).Value = fieldorder;
            cmd.Parameters.Add("@Where", SqlDbType.NVarChar, 1000).Value = where;
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PageCount", SqlDbType.Int).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            recordcount = (int)cmd.Parameters["@RecordCount"].Value;
            //pagecount = cmd.Parameters["@PageCount"].Value.ToString();

            conn.Close();
            return ds;
        }

        //查询操作，判断是否存在
        public static bool IsPriExist(string str)
        {
            SqlConnection conn = ConnectionManger.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
            }

        }
    }
}
