using AutoMapper;
using LMS.HRMatrix.Model;
using LMS.HRMatrix.Service;
using LMS.HRMatrix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.HRMatrix.UI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }
        public void SetNotification(string message, string notifyType, bool autoHideNotification = true)
        {
            this.TempData["Notification"] = message;
            this.TempData["notificationAutoHide"] = (autoHideNotification) ? "true" : "false";

            switch (notifyType)
            {
                case "Success":
                    this.TempData["notificationClass"] = "alert-success";
                    break;
                case "Error":
                    this.TempData["notificationClass"] = "alert-danger";
                    break;
                case "Warning":
                    this.TempData["notificationClass"] = "alert-warning";
                    break;
            }
        }
    }
}