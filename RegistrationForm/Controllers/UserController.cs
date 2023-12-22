using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RegistrationForm.Models;

namespace RegistrationForm.Controllers
{
    public class UserController : Controller
    {
        private readonly DataAccess registrationDBHandle = new DataAccess("Data Source=DESKTOP-8MGS6KF\\SQLEXPRESS;Initial Catalog=mayuri;Integrated Security=true");

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = registrationDBHandle.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertUser(string name, string email, string phone, string address, int stateId, int cityId)
        {
            try
            {
                var userModel = new UserModel
                {
                    Name = name,
                    Email = email,
                    Phone = phone,
                    Address = address,
                    StateId = stateId,
                    CityId = cityId
                };

               
                if (ModelState.IsValid && registrationDBHandle.AddUser(userModel))
                {
                    return Json(new { success = true, message = "User inserted successfully" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Failed to insert user" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json(new { success = false, message = "An error occurred while inserting user: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetUserDetails(int id)
        {
            var user = registrationDBHandle.GetUsers().Find(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return Json(user, JsonRequestBehavior.AllowGet);
        }

       
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id,string name, string email, string phone, string address, int stateId, int cityId)
            {
                try
                {
                    var userModel = new UserModel
                    {
                        Id=id,
                        Name = name,
                        Email = email,
                        Phone = phone,
                        Address = address,
                        StateId = stateId,
                        CityId = cityId
                    };


                    if (ModelState.IsValid && registrationDBHandle.UpdateUser(userModel))
                    {
                        return Json(new { success = true, message = "User updated successfully" }, JsonRequestBehavior.AllowGet);
                    }

                    return Json(new { success = false, message = "Failed to update user" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {

                    return Json(new { success = false, message = "An error occurred while inserting user: " + ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var userToDelete = registrationDBHandle.GetUsers().Find(u => u.Id == id);

            if (userToDelete == null)
            {
                return HttpNotFound();
            }

            var isDeleted = registrationDBHandle.DeleteUser(id);

            if (isDeleted)
            {
                return Json(new { success = true, message = "User deleted successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Error deleting user" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetCities(int stateId)
        {
              var cities = registrationDBHandle.GetCities(stateId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCitiesName(int cityId)
        {
            var cities = registrationDBHandle.GetCitiesName(cityId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetStates()
        {
            var states = registrationDBHandle.GetStates();
            return Json(states, JsonRequestBehavior.AllowGet);
        }
    }
}
