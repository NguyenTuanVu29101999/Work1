using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.DAO
{
    public class PromotionDAO
    {
        ZaSaStored db = null;
        public PromotionDAO()
        {
            db = new ZaSaStored();
        }
        public IEnumerable<KHUYEN_MAI> ListAll(/*int page, int pageSize*/)
        {
            //return db.Users.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
            return db.KHUYEN_MAI.OrderByDescending(x => x.NGAY_TAO).ToList();
            //return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //// sử dụng khi phân trang
        }
        public KHUYEN_MAI ViewDetail(int id)//TRY XUẤT DỮ LIỆU THEO ID
        {
            return db.KHUYEN_MAI.Find(id);
        }
        public long Insert(KHUYEN_MAI Entity)// phương thức thêm dữ liệu
        {
            Entity.NGAY_TAO = DateTime.Now;
            db.KHUYEN_MAI.Add(Entity);
            db.SaveChanges();
            return Entity.IDKM;
        }
        public bool Update(KHUYEN_MAI Entity)
        {
            try
            {
                var promotion = db.KHUYEN_MAI.Find(Entity.IDKM);
                promotion.MAKM = Entity.MAKM;
                promotion.TEN_CH_TRINH = Entity.TEN_CH_TRINH;
                promotion.NGAY_BD = Entity.NGAY_BD;
                promotion.NGAY_KT = Entity.NGAY_KT;
                promotion.NGAY_TAO = DateTime.Now;
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
                var promotion = db.KHUYEN_MAI.SingleOrDefault(m => m.IDKM == id);
                db.KHUYEN_MAI.Remove(promotion);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
