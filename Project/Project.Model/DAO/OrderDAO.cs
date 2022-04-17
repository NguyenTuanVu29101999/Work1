using Project.Model.EF;
using Project.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.DAO
{
    public class OrderDAO
    {
        ZaSaStored db = null;
        public OrderDAO()
        {
            db = new ZaSaStored();
        }
        public DON_HANG GetById(int id)
        {
            return db.DON_HANG.Find(id);
        }
      
        public List<ViewOrderModel> LisAlltOrder()
        {

            //var model = from a in db.DON_HANG
            //            join b in db.KHACH_HANG
            //            on a.MAKH equals b.MAKH
            //            orderby a.NGAY_TAO, a.TRANG_THAI descending
            //            select new ViewOrderModel()
            //            {
            //                IDDH = a.IDDH,
            //                MAKH = b.MAKH,
            //                NICK_NAME = b.NICK_NAME,
            //                NGAY_TAO = a.NGAY_TAO,
            //                TRANG_THAI = a.TRANG_THAI,
            //                NGAY_LAY_DO = a.NGAY_LAY_DO,
            //                NGAY_HEN_KHACH = a.NGAY_HEN_KHACH
            //            };
            var model = from dh in db.DON_HANG
                        join ctdh in db.CT_DON_HANG on dh.IDDH equals ctdh.IDDH
                        join sp in db.SAN_PHAM on ctdh.MASP equals sp.MASP
                        join kh in db.KHACH_HANG on dh.MAKH equals kh.MAKH
                        select new ViewOrderModel()
                        {
                            IDDH = dh.IDDH,
                            MAKH = kh.MAKH,
                            TENKH = kh.TENKH,
                            NICK_NAME = kh.NICK_NAME,
                            MASP = sp.MASP,
                            TEN_SP = sp.TEN_SP,
                            DON_GIA = (decimal)sp.DON_GIA,
                            NGAY_LAY_DO = dh.NGAY_LAY_DO,
                            NGAY_HEN_KHACH = dh.NGAY_HEN_KHACH,
                            TRANG_THAI = dh.TRANG_THAI,
                            NGAY_TAO = dh.NGAY_TAO,
                            SO_LUONG = ctdh.SO_LUONG,
                            THANH_TIEN = ctdh.THANH_TIEN

                        };

            var rslt = model.Take(50).ToList();
            return rslt;
        }

     
        public int Insert(DON_HANG Entity)
        {
            try
            {
                Entity.NGAY_TAO = DateTime.Now;
                db.DON_HANG.Add(Entity);
                db.SaveChanges();
                return Entity.IDDH;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public bool Deletes(int id)
        {
            try
            {
                var order = db.DON_HANG.FirstOrDefault(x => x.IDDH == id);
                db.DON_HANG.Remove(order);
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
