using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCL.Models;

namespace QLCL.Controllers
{
    public class DiemCachLyController : Controller
    {
        public IActionResult ThemDiemCachLy()
        {
            return View();
        }

        public IActionResult ThemThanhCong()
        {
            return View();
        }

        public IActionResult ThemThatBai()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertDCL(DiemCachLyModels diemCachLy)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;
            if (context.sqlInsertDiemCachLy(diemCachLy) == 1)
            {
                return RedirectToAction(actionName: "ThemThanhCong", controllerName: "DiemCachLy");
            }
            else
            {
                return RedirectToAction(actionName: "ThemThatBai", controllerName: "DiemCachLy");
            }
        }

        public IActionResult LietKeDiemCachLy()
        {

            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;

            ViewData["MaDiemCL"] = new SelectList(context.slqSelectDiaDiem(), "MaDiemCL", "TenDiemCL");

            return View();
        }

        public IActionResult ListCNByTenDCL(string MaDiemCL)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(QLCL.Models.DataContext)) as DataContext;


            return View(context.sqlListCNByTenDCL(MaDiemCL));

        }
    }
}
