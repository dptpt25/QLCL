using Microsoft.AspNetCore.Mvc;
using QLCL.Models;


namespace QLCL.Controllers
{
    public class CongNhanController : Controller
    {
        public IActionResult LietKeTrieuChung()
        {
            return View();
        }
        public IActionResult XoaThanhCong()
        {
            return View();
        }
        public IActionResult XoaThatBai()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ListByTC(int soTC)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;
            return View(context.Lietketrieuchung(soTC));
        }

        public IActionResult Delete(string MaCongNhan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;

            return View(context.sqlSelectCNByMaCongNhan(MaCongNhan));

        }

        public IActionResult DeleteConfirmed(string MaCongNhan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;

            if (context.sqlDeleteCongNhan(MaCongNhan) == 1)
            {
                return RedirectToAction(actionName: "ThemThanhCong", controllerName: "DiemCachLy");
            }
            else
            {
                return RedirectToAction(actionName: "ThemThatBai", controllerName: "DiemCachLy");
            }

        }

        public IActionResult Detail(string MaCongNhan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;

            return View(context.sqlSelectCNByMaCongNhan(MaCongNhan));

        }
    }
}
