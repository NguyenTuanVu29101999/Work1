using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.DAO
{
    public class CustomerDAO
    {
        ZaSaStored db = null;
        public CustomerDAO()
        {
            db = new ZaSaStored();
        }
        public KHACH_HANG GetByID(string name)
        {
            return db.KHACH_HANG.SingleOrDefault(x => x.TENKH == name);
        }
        public KHACH_HANG ViewDetail(int id)//TRY XUẤT DỮ LIỆU THEO ID
        {
            return db.KHACH_HANG.Find(id);
        }
        public List<KHACH_HANG> GetSelectNickName()
        {
            return db.KHACH_HANG.ToList();
        }
        public IEnumerable<KHACH_HANG> ListAll(/*int page, int pageSize*/)
        {
            //return db.Users.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
            return db.KHACH_HANG.OrderByDescending(x => x.NGAY_TAO).ToList();
            //return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //// sử dụng khi phân trang
        }
        public List<KHACH_HANG> GetListCustomer()
        {
            var model = from a in db.KHACH_HANG
                        select a;

            var rslt = model.OrderByDescending(x => x.NGAY_TAO).ToList();

            return rslt;
        }
        public List<string> AutocompleteSearch(string search)
        {
            return db.KHACH_HANG.Where(x => x.NICK_NAME.Contains(search)).Select(x => x.NICK_NAME).ToList();
        }
        public long Insert(KHACH_HANG Entity)// phương thức thêm dữ liệu
        {
            Entity.NGAY_TAO = DateTime.Now;
            db.KHACH_HANG.Add(Entity);
            db.SaveChanges();
            return Entity.MAKH;
        } 
        public bool Update(KHACH_HANG Entity)
        {
            try
            {
                var customer = db.KHACH_HANG.Find(Entity.MAKH);
                //customer.MAKH = Entity.MAKH;
                customer.TENKH = Entity.TENKH;
                customer.NICK_NAME = Entity.NICK_NAME;
                customer.GT = Entity.GT;
                customer.NGAY_SINH = Entity.NGAY_SINH;
                customer.DT_KH = Entity.DT_KH;
                customer.NGAY_TAO = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Deletes(int id)
        {
            try
            {
                var customer = db.KHACH_HANG.SingleOrDefault(m => m.MAKH == id);
                db.KHACH_HANG.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
