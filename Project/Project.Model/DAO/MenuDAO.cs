using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.DAO
{
    public class MenuDAO
    {
        ZaSaStored db = null;
        public MenuDAO()
        {
            db = new ZaSaStored();
        }
        public IEnumerable<Menus> ListAll(/*int page, int pageSize*/)
        {
            //return db.Users.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
            return db.Menus.OrderByDescending(x => x.OrderNumber).ToList();
            //return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //// sử dụng khi phân trang
        }
    }
}
