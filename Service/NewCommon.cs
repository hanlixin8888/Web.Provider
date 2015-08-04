using Model;
using Business.IFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Orm.DB;
using Public.DataAccess;
using MB.RuleBase.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Business
{
    public class NewCommon : IFaceCommon
    {
        public VenderUser LogOn(string userCode, string psw)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
            //Microsoft.Practices.EnterpriseLibrary.Data.Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase("NewWeb");
                try
                {
                    VenderUser userInfo = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<VenderUser>("NewWebCommon", "GetUserInfo", userCode, EncryptHelper.EncryptDES(psw)).FirstOrDefault();
                    if (userInfo != null)
                    {

                    }
                    else
                    {
                        userInfo = new VenderUser() { ErrorMsg = "登录户名或密码不正确" };
                    }
                    return userInfo;
                }
                catch (Exception ex)
                {
                    MB.Util.TraceEx.Write(ex.Message);

                }

                return null;
            }
        }

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public List<Vender> GetVenderList()
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<Vender> Venderlist = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<Vender>("NewWebCommon", "GetVenderInfo", "");
                Vender v=new Vender ();
                v.VENDERCODE="";
                v.VENDERNAME="--全部--";
                v.VENDERID=0;
                Venderlist.Add(v);
                return Venderlist;
            }
        }

        /// <summary>
        /// 根据usercode获取用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public VenderUser CheckVenderUser(string userCode)
        {
            VenderUser userInfo = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<VenderUser>("NewWebCommon", "CheckVenderUser", userCode).FirstOrDefault();
            return userInfo;
        }


        //查询供应商用户列表
        public List<VenderUserInfo> GetVenderUserList(int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<VenderUserInfo> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<VenderUserInfo>
                                                ("NewWebCommon", "GetVenderUserInfo", pageIndex, pageSize, out total, parValues);
                return list;
            }
        }

        /// <summary>
        /// 新增供应商用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddVenderUser(VenderUser user)
        {
            user.PASSWORD = EncryptHelper.EncryptDES(user.PASSWORD);
            return DatabaseExcuteByXmlHelper.NewInstance.ExecuteNonQueryByEntity<VenderUser>
                            ("NewWebCommon", "AddVenderUser", user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int DeleteVenderUser(string code)
        {
            return DatabaseExcuteByXmlHelper.NewInstance.ExecuteNonQuery("NewWebCommon", "DeleteVenderUser", code);
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="VUSERCODE"></param>
        /// <param name="PASSWORD"></param>
        /// <returns></returns>
        public int ChangePwd(string VUSERCODE, string PASSWORD)
        {
            return DatabaseExcuteByXmlHelper.NewInstance.ExecuteNonQuery("NewWebCommon", "ChangePwd", VUSERCODE, PASSWORD);
        }
    }
}
