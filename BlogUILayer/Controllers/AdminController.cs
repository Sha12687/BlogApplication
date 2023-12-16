using AppUILayer.Models.ViewModel;
using BlogDAL;
using BlogDAL.Authentication;
using BlogDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogUILayer.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthService authService;
        private readonly IAdminRepository adminRepository;
        private readonly IEmpRepository empRepository;

        public AdminController(IAuthService authService,IAdminRepository adminRepository
            ,IEmpRepository empRepository)
        {
            this.authService = authService;
            this.adminRepository = adminRepository;
            this.empRepository = empRepository;
        }
        // GET: Admin
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
                bool Authres = authService.Authenticate(model.EmailId, model.Password, UserRole.Admin);
                if (Authres)
                {
                    var employee = adminRepository.GetAdminInfoByEmailId(model.EmailId);
                    Session["EmailId"] = model.EmailId;
                    return RedirectToAction("Home", "Admin");
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


        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Home()
        {
            var employeeList = empRepository.GetAllEmpInfos();
            var employeeViewModelList = employeeList.Select(admin => new EmoloyeeViewModel
            {
                EmailId = admin.EmailId,
                Name = admin.Name,
                DateOfJoining = admin.DateOfJoining
            });
            // Map ot
            return View(employeeViewModelList);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
