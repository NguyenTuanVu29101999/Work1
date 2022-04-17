using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common;
using Project.Model;
namespace Project.Model.DAO
{
    public class UserDAO
    {
        ZaSaStored db = null;
        public UserDAO()
        {
            db = new ZaSaStored();
        }
        public ACCOUNT GetById(string userName)
        {
            return db.ACCOUNT.SingleOrDefault(x => x.TAI_KHOAN == userName);
        }
        public ACCOUNT ViewDetail(int id)//TRY XUẤT DỮ LIỆU THEO ID
        {
            return db.ACCOUNT.Find(id);
        }
        public List<AccountGroup> GetSelectGroupID()
        {
            return db.AccountGroups.ToList();
        }
        public List<string> GetListPermission(string username)
        {
            var user = db.ACCOUNT.Single(x => x.TAI_KHOAN == username);
            var data = (from a in db.Permissions
                        join b in db.AccountGroups on a.ID_GROUP equals b.ID_GROUP
                        join c in db.Roles on a.ID_ROLES equals c.ID_ROLES
                        where b.ID_GROUP == user.ID_GROUP
                        select new 
                        {
                            ID_ROLES = a.ID_ROLES,
                            ID_GROUP = a.ID_GROUP
                        }).AsEnumerable().Select(x => new Permissions
                        {
                            ID_ROLES = x.ID_ROLES,
                            ID_GROUP = x.ID_GROUP
                        });
            return data.Select(x => x.ID_ROLES).ToList();
        }
        public int Login(string Username, string Password,bool isLoginAdmin = false)
        {
            var rslt = db.ACCOUNT.SingleOrDefault(x => x.TAI_KHOAN == Username);
            if (rslt == null)
            {
                return 0; // tài khoản không tồn tại trả về 0
            }
            else
            {
                if(isLoginAdmin == true)
                {
                    if(rslt.ID_GROUP == CommonConstant.ADMIN_GROUP || rslt.ID_GROUP == CommonConstant.MOD_GROUP)
                    {
                        if (rslt.TRANG_THAI == false)// nếu tài khoản chưa dc kích hoạt
                            return -1;//tài khoản không hoạt động
                        else
                        {
                            if (rslt.MAT_KHAU == Password) // nếu mật khẩu trong csdl giống với mật khẩu truyền 
                                return 1;// mật khẩu trong csdl khớp với mật khẩu truyền vào
                            else
                                return -2;//  mật khẩu trong csdl không khớp với mật khẩu truyền vào
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (rslt.TRANG_THAI == false)// nếu tài khoản chưa dc kích hoạt
                        return -1;//tài khoản không hoạt động
                    else
                    {
                        if (rslt.MAT_KHAU == Password) // nếu mật khẩu trong csdl giống với mật khẩu truyền 
                            return 1;// mật khẩu trong csdl khớp với mật khẩu truyền vào
                        else
                            return -2;//  mật khẩu trong csdl không khớp với mật khẩu truyền vào
                    }
                }
            }
        }

        public IEnumerable<ACCOUNT> ListAll(string searchString)
        {
            IQueryable<ACCOUNT> model = db.ACCOUNT.OrderByDescending(x => x.NGAY_TAO);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.OWNERS.Contains(searchString) || x.TAI_KHOAN.Contains(searchString));
            }
            return model.OrderByDescending(x => x.NGAY_TAO);
            //return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            //// sử dụng khi phân trang
        }
        public long Insert(ACCOUNT Entity)// phương thức thêm dữ liệu
        {
            Entity.NGAY_TAO = DateTime.Now;
            db.ACCOUNT.Add(Entity);
            db.SaveChanges();
            return Entity.ID;
        }

        public bool Update(ACCOUNT Entity)
        {
            try
            {
                var user = db.ACCOUNT.Find(Entity.ID);
                user.ID_GROUP = Entity.ID_GROUP;
                user.TAI_KHOAN = Entity.TAI_KHOAN;
                user.MAT_KHAU = Entity.MAT_KHAU;
                user.OWNERS = Entity.OWNERS;
                //user.GroupID = Entity.GroupID;
                user.NGAY_TAO = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.ACCOUNT.FirstOrDefault(M => M.ID == id);
                db.ACCOUNT.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // phương thức thay đổi Status
        public bool ChangeStatus(long id)
        {
            var user = db.ACCOUNT.Find(id);
            user.TRANG_THAI = !user.TRANG_THAI;// khi dữ liệu trong database là true thì dữ liệu lê web là false
            db.SaveChanges();
            return user.TRANG_THAI;

        }
    }
}
