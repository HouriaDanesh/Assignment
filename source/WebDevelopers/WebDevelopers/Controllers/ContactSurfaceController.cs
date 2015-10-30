using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using WebDevelopers.Models;

namespace WebDevelopers.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult ShowForm()
        {
            contactModel myModel = new contactModel();
            return PartialView("ContactForm", myModel);

        }
        public ActionResult HandleFormPost(contactModel model)
        {
            var newComment = Services.ContentService.CreateContent(model.Name + "." + DateTime.Now, CurrentPage.Id, "ContactFormula");
            newComment.SetValue("emailForm", model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactMessage", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    }
}