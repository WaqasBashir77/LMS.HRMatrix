using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.HRMatrix.UI.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createCourse([Bind(Include = "course_Name,Description")] Course cor)
        {
            HttpPostedFileBase profilePic = Request.Files[0]; // your file
            try
            {
                if (cor != null)
                {
                    string name = cor.course_Name.ToString();
                    string description = cor.Description.ToString();
                    string imgpath = SaveToPhysicalLocation(profilePic);
                    //"~/assets/img/photos/03.jpg";
                    string filename = profilePic.FileName;
                    imgpath = "~/CourseImages/" + filename;




                    if (name.Length == 0 ||
                        description.Length == 0)
                    {
                        string message1 = "Some Filelds are empty";
                        return Json(new { Message = message1, JsonRequestBehavior.DenyGet });

                    }
                    else if (ModelState.IsValid)
                    {
                        string message2 = "SUCCESS";
                        return Json(new { success = true, Error = message2 });
                        // return Json(new { Message = message2, JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        string message3 = "Failed";
                        return Json(new { Message = message3, JsonRequestBehavior.DenyGet });
                    }
                }
            }




            catch (Exception)
            {

                string message4 = "Failed";
                return Json(new { Message = message4, JsonRequestBehavior.DenyGet });
            }

            string message = "Failed";
            return Json(new { Message = message, JsonRequestBehavior.DenyGet });

        }
        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/CourseImages"), fileName);
                file.SaveAs(path);
                return path;
            }
            return string.Empty;
        }

    }
}