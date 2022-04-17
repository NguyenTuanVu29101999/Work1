using ClosedXML.Excel;
using Project.Model.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Controllers
{
    public class ExportController : Controller
    {
        // GET: Export
        public ActionResult Index()
        {
            return View(this.GetListAccount());
        }

        public IList<ACCOUNT> GetListAccount()
        {
            ZaSaStored db = new ZaSaStored();
            var account = (from e in db.ACCOUNT select e).ToList();
                                
            return account;
        }
        public FileResult Export() {
            ZaSaStored entities = new ZaSaStored();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("TAI_KHOAN"),
                                            new DataColumn("MAT_KHAU"),
                                            new DataColumn("ID_GROUP"),
                                            new DataColumn("OWNERS") });
            var customers = from customer in entities.ACCOUNT.Take(10)
                            select customer;

            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.TAI_KHOAN, customer.MAT_KHAU, customer.ID_GROUP, customer.OWNERS);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }  
    }
}