using AppUILayer.Models.ViewModel;
using BlogDAL;
using BlogDAL.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppUILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAuthService authService;
        private readonly IBlogReposotiry blogReposotiry;
        private readonly IEmpRepository empRepository;

        // GET: Employee
        public EmployeeController(IEmpRepository empRepository,IAuthService authService,IBlogReposotiry blogReposotiry)
        {
            this.empRepository = empRepository;
            this.authService = authService;
            this.blogReposotiry = blogReposotiry;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            // Add authentication logic for Employee login
            if (ModelState.IsValid)
            {
                bool Authres = authService.Authenticate(model.EmailId, model.Password, UserRole.Employee);
                if (Authres)
                {
                    var employee=empRepository.GetEmpInfoByEmialId(model.EmailId) ;
                    Session["EmailId"]=model.EmailId;
                    Session["UserName"]=employee.Name;
                    Session["UserId"] = employee.EmpInfoId;
                    return RedirectToAction("Home", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    // Add a flag to indicate unsuccessful login attempt
                    ModelState.AddModelError("LoginFailed", "true");
                }
            }
            return View(model);
        }

        public ActionResult Home()
        {
            string email = (string)Session["EmailId"];
            if (email != null)
            {
                var blogWrtieByLoggedInEmployee = blogReposotiry.GetBlogInfoByEmployeeId(email);
                var blogViewModels = blogWrtieByLoggedInEmployee.Select(blog => new BlogViewModel
                {

                    Title = blog.Title,
                    Subject = blog.Subject,
                    DateOfCreation = blog.DateOfCreation,
                    BlogUrl = blog.BlogUrl,
                    EmployeeName = blog.Employee.Name
                }).ToList();
                return View(blogViewModels);
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Blog");
        }

    }
}
