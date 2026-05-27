using AspGodPractice.Models;
using AspGodPractice.Repositories.UserRepository;
using AspGodPractice.Services.UserService;
using System;

using System.Web.Mvc;

namespace AspGodPractice.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController() : this(new UserService(new UserRepository()))
        {
        }
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            // We pass the ID to the view so the frontend script knows who to look up
            ViewBag.UserId = id;
            return View();
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers(); // Returns List<User>
                return Json(users, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetUserDetailsJson(int id)
        {
            try
            {
                var user = _userService.GetUserDetailsById(id); // Returns User
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View(); // This looks for Views/User/Create.cshtml
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult Create(CreateUserDto userDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Json(new { success = false, message = "Invalid input data." });
        //    }

        //    try
        //    {
        //        var createdUser = _userService.CreateUser(userDto);
        //        if (createdUser != null)
        //        {
        //            return Json(new { success = true, data = createdUser });
        //        }
        //        return Json(new { success = false, message = "Database error." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}
    }
}