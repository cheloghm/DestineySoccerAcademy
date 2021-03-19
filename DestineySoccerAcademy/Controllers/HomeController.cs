using DestineySoccerAcademy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DestineySoccerAcademy.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();

                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Image/noImg.jpg");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                // to get the user details to load user Image    
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.ProfilePhoto, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Image/noImg.jpg");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }

        //public FileContentResult UserPhotos2(string id)
        //{

        //    String userId = User.Identity.GetUserId();


        //    // to get the user details to load user Image    
        //        var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
        //        var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

        //        return new FileContentResult(userImage.ProfilePhoto, "image/jpeg");
            
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region MY FUNCTIONS Starts here
        ///**************************MY FUNCTIONS Starts here*********************************/

        //[AllowAnonymous]
        //public ActionResult UserList()
        //{
        //    var context = new Models.ApplicationDbContext();
        //    return View(context.Users.ToList());
        //}
        //[AllowAnonymous]
        //public ActionResult UserDelete(string id)
        //{
        //    var context = new Models.ApplicationDbContext();
        //    var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
        //    return View(user);
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult UserDelete(ApplicationUser appuser)
        //{
        //    var context = new Models.ApplicationDbContext();
        //    var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
        //    context.Users.Remove(user);
        //    context.SaveChanges();
        //    //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
        //    return RedirectToAction("UserList");
        //}
        //[AllowAnonymous]
        //public ActionResult UserEdit(string id)
        //{
        //    var context = new Models.ApplicationDbContext();
        //    var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
        //    return View(user);
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult UserEdit(ApplicationUser appuser)
        //{
        //    var context = new Models.ApplicationDbContext();
        //    var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();

        //    byte[] imageData = null;
        //    if (Request.Files.Count > 0)
        //    {
        //        HttpPostedFileBase poImgFile = Request.Files["ProfilePhoto"];

        //        using (var binary = new BinaryReader(poImgFile.InputStream))
        //        {
        //            imageData = binary.ReadBytes(poImgFile.ContentLength);
        //        }
        //    }

        //    //context.Entry(appuser).State = EntityState.Modified;
        //    user.FirstName = appuser.FirstName;
        //    user.LastName = appuser.LastName;
        //    user.MobilePhone = appuser.MobilePhone;
        //    user.Address = appuser.Address;
        //    user.State = appuser.State;
        //    user.Country = appuser.Country;
        //    user.Birthdate = appuser.Birthdate;
        //    user.Email = appuser.Email;
        //    user.UserName = appuser.UserName;
        //    user.PhoneNumber = appuser.PhoneNumber;
        //    user.PasswordHash = user.PasswordHash;
        //    user.ProfilePhoto = imageData;
        //    context.SaveChanges();
        //    //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
        //    return RedirectToAction("UserList");
        //}

        ///**************************MY FUNCTIONS Ends here*********************************/

        #endregion
    }
}