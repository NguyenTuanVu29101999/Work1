using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.DAO
{
    public class ProductDAO
    {
        ZaSaStored db = null;
        public ProductDAO()
        {
            db = new ZaSaStored();
        }
        public SAN_PHAM GetByName(string name)
        {
            return db.SAN_PHAM.SingleOrDefault(x => x.TEN_SP == name);
        }

        public SAN_PHAM ViewDetail(int id)//TRY XUẤT DỮ LIỆU THEO ID
        {
            return db.SAN_PHAM.Find(id);
        }

        public List<SAN_PHAM> GetSelectSanPham()
        {
            return db.SAN_PHAM.ToList();
        }
        #region "get all list"
        public IEnumerable<SAN_PHAM> ListAll(/*int page, int pageSize*/)
        {
            //return db.Users.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
            return db.SAN_PHAM.OrderByDescending(x => x.NGAY_TAO).ToList();
            //return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //// sử dụng khi phân trang
        }
        #endregion

        #region "Method Insert"
        public long Insert(SAN_PHAM Entity)// phương thức thêm dữ liệu
        {
            Entity.NGAY_TAO = DateTime.Now;
            db.SAN_PHAM.Add(Entity);
            db.SaveChanges();
            return Entity.MASP;
        }
        #endregion

        #region "Method Upate"
        public bool Update(SAN_PHAM Entity)
        {
            try
            {
                var product = db.SAN_PHAM.Find(Entity.MASP);
                product.TEN_SP = Entity.TEN_SP;
                product.DVT = Entity.DVT;
                product.DON_GIA = Entity.DON_GIA;
                product.MO_TA = Entity.MO_TA;
                //user.GroupID = Entity.GroupID;
                product.NGAY_TAO = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region "Method Delete"
        public bool Deletes(int id)
        {
            try
            {
                var product = db.SAN_PHAM.SingleOrDefault(m => m.MASP == id);
                db.SAN_PHAM.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public List<SAN_PHAM> GetListProduct()
        {
            return (from a in db.SAN_PHAM
                         select new SAN_PHAM()
                         {
                             MASP = a.MASP,
                             TEN_SP = a.TEN_SP
                         }).OrderByDescending(x => x.NGAY_TAO).ToList();

           

        }
    }
}
