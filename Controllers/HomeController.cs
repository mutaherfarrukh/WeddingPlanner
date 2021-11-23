using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
// ADD THIS!!
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        //COMBINED PARTIAL LOGIN/REGISTRATION PAGE
        public IActionResult Index()
        {
            return View("LoginReg");
        }

        //REGISTER NEW USER PAGE//
        // [HttpGet("Register")]
        // public IActionResult Register()
        // {
        //     return View();
        // }

        //REGISTER NEW USER PROCESS//
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(User newUser)
        {
            // Check initial ModelState
            if(ModelState.IsValid)
            {
                // If a User exists with provided email
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("LoginReg", newUser);
                }
                else
                {
                    //add the stuff to the database!
                    // Initializing a PasswordHasher object, providing our User class as its type
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    //Save your user object to the database
                    Console.WriteLine("Success! now you can add me to the database!");
                    _context.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("UserID", newUser.UserId);
                    return RedirectToAction("Home");
                }
            }
            return View("LoginReg");
        }


        //LOGIN USER PAGE//
        // [HttpGet("Login")]
        // public IActionResult Login()
        // {
        //     return View();
        // }

        //LOGIN EXISTING USER PROCESS//
        [HttpPost("LoginUser")]
        public IActionResult LoginUser(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                User userInDb = _context.Users
                    .FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginReg");
                }
                
                // Initialize hasher object
                // var hasher = new PasswordHasher<LoginUser>();
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginReg");
                }
                Console.WriteLine(userInDb.UserId);
                HttpContext.Session.SetInt32("UserID", userInDb.UserId);
                Console.WriteLine("Session is "+HttpContext.Session.GetInt32("UserID"));
                return RedirectToAction("Home");
            }
            Console.WriteLine("Model Is Not Valid");
            return View("LoginReg");
        }

        //LOGOUT USER//
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Console.WriteLine("Session has been cleared!");
            return View("LoginReg");
        }

        //SUCCESS HOME PAGE
        [HttpGet("Home")]
        public IActionResult Home()
        {
            return RedirectToAction("AllWeddings");

            // //Check if User is logged in
            // int? sessionID = HttpContext.Session.GetInt32("UserID");
            // Console.WriteLine("UserID is "+ sessionID);
            // if (sessionID==null)
            // {
            //     ModelState.AddModelError("LoginPassword", "Please Login First");
            //     ModelState.AddModelError("FirstName", "Please Register First");
            //     return View("LoginReg");
            // }

            // User userInDb = _context.Users
            //         .FirstOrDefault(u => u.UserId == sessionID);

            // ViewBag.CurrentUser = userInDb;
            // return View();
        }

        // DISPLAY ALL WEDDINGS
        [HttpGet("AllWeddings")]
        public IActionResult AllWeddings()
        {
            //Check if User is logged in
            int? sessionID = HttpContext.Session.GetInt32("UserID");
            Console.WriteLine("UserID is "+ sessionID);
            if (sessionID==null)
            {
                ModelState.AddModelError("LoginPassword", "Please Login First");
                ModelState.AddModelError("FirstName", "Please Register First");
                return View("LoginReg");
            }

            User userInDb = _context.Users
                    .Include(usr => usr.Attending)
                    .FirstOrDefault(u => u.UserId == sessionID);
            ViewBag.CurrentUser = userInDb;

            // Import wedding data from database
            // Needs a link to the user that created the wedding
            // needs a link to the RSVP list to count guest list
            ViewBag.AllWeddings = _context.Weddings
            .Include(pln => pln.Planner)
            .Include(gst => gst.Guests)
            .ThenInclude(usr => usr.User)
            .ToList();
            return View();
        }

        // DISPLAY NEW WEDDING PAGE
        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {
            return View();
        }


        // CREATE NEW WEDDING PROCESS
        [HttpPost("NewWedding/process")]
        public IActionResult NewWeddingProcess(Wedding addWedding)
        {
            //Check if User is logged in
            int? sessionID = HttpContext.Session.GetInt32("UserID");
            Console.WriteLine("UserID is "+ sessionID);
            if (sessionID==null)
            {
                ModelState.AddModelError("LoginPassword", "Please Login First");
                ModelState.AddModelError("FirstName", "Please Register First");
                return View("LoginReg");
            }

            User userInDb = _context.Users
                .FirstOrDefault(u => u.UserId == sessionID);
            ViewBag.CurrentUser = userInDb;


            // FORM VALIDATION
            if (ModelState.IsValid)
            {
                addWedding.UserID = (int)sessionID;//Sets wedding userID = to logged-in user
                _context.Add(addWedding);
                _context.SaveChanges();
                return RedirectToAction("AllWeddings");
            }
            else
            {
                return View("NewWedding");
            }
        }

        // DISPLAY SINGLE WEDDING
        [HttpGet("SingleWedding/{id}")]
        public IActionResult SingleWedding(int id)
        {
            ViewBag.viewWedding = _context.Weddings
            .Include(gst=>gst.Guests)
            .ThenInclude(wed=>wed.User)
            .FirstOrDefault(wed => wed.WeddingID == id);
            return View();
        }


        // DELETE WEDDING
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Wedding deleteWedding = _context.Weddings
            .FirstOrDefault(wed => wed.WeddingID == id);
            _context.Weddings.Remove(deleteWedding);
            _context.SaveChanges();
            return RedirectToAction("AllWeddings");
        }



        // RSVP TO WEDDING
        [HttpGet("RSVP/{id}")]
        public IActionResult RSVP(int id)
        {
            RSVP newRSVP = new RSVP{
                WeddingID = id,
                UserID = (int)HttpContext.Session.GetInt32("UserID")
            };
            _context.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("AllWeddings");
        }

        // UN-RSVP TO WEDDING
        [HttpGet("unRSVP/{id}")]
        public IActionResult unRSVP(int id)
        {
            int selectedWedding = id;
            int storedUser = (int)HttpContext.Session.GetInt32("UserID");

            RSVP deleteRSVP = _context.RSVPs
            .FirstOrDefault(rsvp => rsvp.WeddingID == selectedWedding && rsvp.UserID == storedUser);

            _context.RSVPs.Remove(deleteRSVP);
            _context.SaveChanges();
            return RedirectToAction("AllWeddings");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
