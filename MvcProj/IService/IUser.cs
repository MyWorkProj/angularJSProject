using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MvcProj.IService
{
    public interface IUser
    {
        void Add(MvcProj.Models.userinfotb model);

        List<MvcProj.Models.UserModel> GetAllUserModel();

        List<MvcProj.Models.userinfotb> GetAllUser();

        void Edit(Models.userinfotb model);
        void Delete(Models.userinfotb model);
    }
}
