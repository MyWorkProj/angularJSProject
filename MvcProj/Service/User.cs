using MvcProj.DB;
using MvcProj.IService;
using MvcProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace MvcProj.Service
{
    public class User : IUser
    {
        private readonly BaseDAL dal;
        LDBContext db = new LDBContext();
        //private static readonly Func<LinkContext, string, wx_userinfo> getUserByOpenId = (db, openId) => db.Users.FirstOrDefault(u => u.OpenId == openId);
        //private static readonly Func<LinkContext, int, wx_userinfo> getUserById = (db, Id) => db.Users.FirstOrDefault(u => u.ID == Id);
        //private static readonly Func<LinkContext, string, chatclient> getClientById = (db, clientId) => db.Clients.FirstOrDefault(c => c.Id == clientId);
        public User()
        {
            string chatdbstr = LinkConfiguration.ChatConnectionString;
            dal = new BaseDAL(chatdbstr);
        }
        public void Add(Models.userinfotb model)
        {
            userinfotb user = new userinfotb
            {
                adress = model.adress,
                age = model.age,
                name = model.name,
                phone = model.phone
            };
            dal.Add(user);
        }

        public List<MvcProj.Models.UserModel> GetAllUserModel()
        {
            //return (PagedList<MvcProj.Models.UserModel>)db.userinfotb.ToList();

            //return (List<MvcProj.Models.UserModel>)dal.GetAll<MvcProj.Models.UserModel>();

            ///////////报错
            return (List<MvcProj.Models.UserModel>)db.userinfotb.ToList();
        }

        public List<MvcProj.Models.userinfotb> GetAllUser()
        {
            //return (List<MvcProj.Models.userinfotb>)db.userinfotb.ToList();

            return dal.GetAll<MvcProj.Models.userinfotb>();
        }

        public void Edit(Models.userinfotb model)
        {
            //userinfotb user = new userinfotb
            //{
            //    id = model.id,
            //    adress = model.adress,
            //    age = model.age,
            //    name = model.name,
            //    phone = model.phone
            //};
            dal.Update(model);
        }

        public void Delete(Models.userinfotb model)
        {
            userinfotb user = new userinfotb
            {
                id = model.id
            };
            dal.Delete(user);
        }

        public UserModel GetUser(int id)
        {
            //return _db.TB_Store.Where(a => a.Status == true).ToList();
            int? idd =(int?) id;
            return db.userinfotb.Where(u => u.id.Equals(id)).FirstOrDefault();
            //userinfotb u = new userinfotb
            //{
            //    id = id
            //};
            //return new UserModel();
            //return dal.GetSingleById(u.id);
        }

        public UserModel GetUser2(int id)
        {
            return db.userinfotb.Where(u => u.id == id).FirstOrDefault();
        }
    }
}