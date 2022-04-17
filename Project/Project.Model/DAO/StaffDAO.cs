using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.DAO
{
    public class StaffDAO
    {
        ZaSaStored db = null;
        public StaffDAO()
        {
            db = new ZaSaStored();
        }
        public IEnumerable<NHAN_VIEN> ListAll(/*int page, int pageSize*/)
        {
            //return db.Users.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
            return db.NHAN_VIEN.OrderByDescending(x => x.NGAY_TAO).ToList();
            //return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //// sử dụng khi phân trang
        }
        public NHAN_VIEN ViewDetail(int id)//TRY XUẤT DỮ LIỆU THEO ID
        {
            return db.NHAN_VIEN.Find(id);
        }
        public long Insert(NHAN_VIEN Entity)// phương thức thêm dữ liệu
        {
            Entity.NGAY_TAO = DateTime.Now;
            db.NHAN_VIEN.Add(Entity);
            db.SaveChanges();
            return Entity.MANV;
        }
        public bool Update(NHAN_VIEN Entity)
        {
            try
            {
                var staff = db.NHAN_VIEN.Find(Entity.MANV);
                //customer.MAKH = Entity.MAKH;
                staff.HO_TEN = Entity.HO_TEN;
                staff.GT = Entity.GT;
                staff.NGAY_SINH = Entity.NGAY_SINH;
                staff.SDT = Entity.SDT;
                staff.LUONG = Entity.LUONG;
                staff.NGAY_TAO = DateTime.Now;
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
                var staff = db.NHAN_VIEN.SingleOrDefault(m => m.MANV == id);
                db.NHAN_VIEN.Remove(staff);
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
