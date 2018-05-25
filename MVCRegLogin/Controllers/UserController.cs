using MVCRegLogin.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCRegLogin.Controllers
{
    public class UserController : Controller
    {
      
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User U)
        {
            //this action is for handle post(login)
            //if(ModelState.IsValid)    //this is check validity
            //{
                using (NewDataBaseEntities dc = new NewDataBaseEntities())
                {
                    var v = dc.Users.Where(a => a.UserName == U.UserName && a.Password == U.Password).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID;
                        Session["LogedUserFullname"] = v.FullName;
                        return RedirectToAction("AfterLogin");
                    }

                    else
                    {
                        U.LoginErrorMessage = "Wrong Username or Password.";
                       return View("Login",U);
                    }
                }
            //}
          // return View(U);
       
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Register");
            }
        }
        public ActionResult Logout()
        {
            int userID = (int)Session["LogedUserID"];
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        //Register Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User Z)
        {
            if (ModelState.IsValid)
            {
                using (NewDataBaseEntities dc = new NewDataBaseEntities())
                {
                    dc.Users.Add(Z);
                    dc.SaveChanges();
                    ModelState.Clear();
                    Z = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(Z);
        }
    }
}
