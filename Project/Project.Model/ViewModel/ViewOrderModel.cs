using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Project.Model.ViewModel
{
    [Serializable]
    public class ViewOrderModel
    {
        ZaSaStored data = new ZaSaStored();
        [Key]
        public int IDDH { get; set; }
        [Key]
        public int MAKH { get; set; }

        [Display(Name = "Khách hàng ")]
        public string TENKH { get; set; }

        public string NICK_NAME { get; set; }

        [Display(Name = "Điện thoại giao hàng")]
        public string DT_GH { get; set; }

        public DateTime? NGAY_TAO { get; set; }

        [Display(Name = "Trạng thái đơn hàng: ")]
        public string TRANG_THAI { get; set; }

        [Display(Name = "Giao hàng")]
        public bool SHIP { get; set; }

        [Display(Name = "Ngày khách lấy đồ")]
        [Required(ErrorMessage = "Phải có ngày lấy đồ")]
        public DateTime NGAY_LAY_DO { get; set; }

        [Display(Name = "Ngày hẹn khách")]
        [Required(ErrorMessage = "Phải có ngày hẹn khách")]
        public DateTime NGAY_HEN_KHACH { get; set; }
        public int MASP { get; set; }

        [Display(Name = "Tên SP")]
        public string TEN_SP { get; set; }

        [Display(Name = "đơn vị")]
        public string DVT { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal DON_GIA { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public int SO_LUONG { get; set; }

        [Display(Name = "Ghi chú")]
        public string NOTE { get; set; }

        //public double THANH_TIEN
        //{
        //    get { return (double)(SO_LUONG * DON_GIA); }
        //}
        [Display(Name = "Thành tiền")]
        public double THANH_TIEN { get; set; }




    }

}
