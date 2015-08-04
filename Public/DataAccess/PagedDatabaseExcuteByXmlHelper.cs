using MB.RuleBase.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Public.DataAccess
{
    public class PagedDatabaseExcuteByXmlHelper
    {
        private static PagedDatabaseExcuteByXmlHelper _NewInstance = new PagedDatabaseExcuteByXmlHelper();

        public static PagedDatabaseExcuteByXmlHelper NewInstance
        {
            get
            {
                if (_NewInstance == null)
                {
                    _NewInstance = new PagedDatabaseExcuteByXmlHelper();
                }

                return _NewInstance;
            }
        }

        public List<T> GetPagedObjectsByXml<T>(string xmlFileName, string sqlName, int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            // 取得数据
            pageIndex = pageIndex - 1;
            List<T> data = new DatabaseExcuteByXmlHelper(new MB.Util.Model.QueryBehavior() { PageIndex = pageIndex, PageSize = pageSize }).GetObjectsByXml<T>(xmlFileName, sqlName, parValues);

            // 取得sql执行Count
            string responseInfo = System.ServiceModel.OperationContext.Current.OutgoingMessageHeaders.GetHeader<string>(MB.BaseFrame.SOD.QUERY_RESPONSE_INFO, MB.BaseFrame.SOD.MESSAGE_HEADER_NAME_SPACE);
            MB.Util.Serializer.EntityXmlSerializer<MB.Util.Model.ResponseHeaderInfo> se = new MB.Util.Serializer.EntityXmlSerializer<MB.Util.Model.ResponseHeaderInfo>();
            MB.Util.Model.ResponseHeaderInfo responseHeaderInfo = se.SingleDeSerializer(responseInfo, string.Empty);
            total = responseHeaderInfo.TotalRecordCount;

            // 返回
            return data;
        }

        public List<T> GetPagedObjectsByXml2<T>(string xmlFileName, string sqlName, int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            // 取得xml中的sql语句
            MB.Orm.DbSql.SqlString[] sqls = MB.Orm.Mapping.Xml.SqlConfigHelper.Instance.GetSqlString(xmlFileName, sqlName);
            if (sqls == null || sqls.Length == 0)
                throw new Exception(string.Format("请检查sql语句{0}是否配置", sqlName));

            // 设置参数value
            for (int i = 0; i < sqls[0].ParamFields.Count; i++)
            {
                sqls[0].ParamFields[i].Value = parValues[i];
            }

            // 拼接分页sql
            string[] sqlStrings = ExtendSqlString(sqls[0].SqlStr, pageIndex, pageSize);

            // 取得分页数据和数据总行数
            List<T> pagedData = DatabaseExecuteHelper.NewInstance.GetObjects<T>(null, typeof(T), sqlStrings[0], sqls[0].ParamFields);
            System.Data.DataSet ds = DatabaseExecuteHelper.NewInstance.ExecuteDataSet(sqlStrings[1], sqls[0].ParamFields);
            total = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            // 返回
            return pagedData;
        }

        public List<T> GetPagedObjectsByXml3<T>(string xmlFileName, string sqlName, int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            // 取得xml中的sql语句
            MB.Orm.DbSql.SqlString[] sqls = MB.Orm.Mapping.Xml.SqlConfigHelper.Instance.GetSqlString(xmlFileName, sqlName);
            if (sqls == null || sqls.Length == 0)
                throw new Exception(string.Format("请检查sql语句{0}是否配置", sqlName));

            // 设置参数追加参数where条件
            sqls[0].SqlStr = sqls[0].SqlStr + parValues[0];

            // 拼接分页sql
            string[] sqlStrings = ExtendSqlString(sqls[0].SqlStr, pageIndex, pageSize);

            // 取得分页数据和数据总行数
            List<T> pagedData = DatabaseExecuteHelper.NewInstance.GetObjects<T>(null, typeof(T), sqlStrings[0], null);
            System.Data.DataSet ds = DatabaseExecuteHelper.NewInstance.ExecuteDataSet(sqlStrings[1], null);
            total = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            // 返回
            return pagedData;
        }



        // 扩展sql语句为分页SQL语句
        private string[] ExtendSqlString(string sql, int pageIndex, int pageSize)
        {
            sql.Replace(';', ' ');
            string[] pagedSqls = new string[2];

            // 分页sql
            int startIndex = (pageIndex - 1) * pageSize;
            int endIndex = (pageIndex - 1) * pageSize + pageSize;
            string head = "SELECT * FROM (SELECT ROWNUM RN ,T.* FROM (";
            string footer = string.Format(") T WHERE ROWNUM <= {0}) S WHERE RN > {1} ;", endIndex, startIndex);
            pagedSqls[0] = head + sql + footer;

            // 取得数据行数sql=
            head = "SELECT COUNT(*) FROM ( ";
            footer = ") ";
            pagedSqls[1] = head + sql + footer;

            // 返回
            return pagedSqls;
        }

    }
}
