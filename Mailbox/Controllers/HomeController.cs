using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfastructureLib;
using Mailbox.Models;
using MailboxLib;
using MailboxLib.Business;
using MailboxLib.Data.Entities;
using UserProfileLib;
using UserProfileLib.Data.Entities;

namespace Mailbox.Controllers{
    [Authorize]
    public class HomeController : Controller{
        IMailboxService service;
        IInfastructureService infastructure;
        IProfileService profiler = new ProfileService();
        private SortedDictionary<string, int> UrlPageIDs = new SortedDictionary<string, int> { 
            {"~/", 22},
            {"~/create", 23},
            {"~/inbox", 24},
            {"~/sent", 25},
            {"~/friends", 26}
        };

        public HomeController() {
            service = new MailboxService();
            infastructure = new InfastructureService();
        }

        public ActionResult Index(){
            HomeIndexViewModel model = 
                HomeIndexViewModel.ForUserPage(User.Identity.Name, UrlPageIDs["~/"]);
            return View(model);
        }

        public ActionResult Create(string returnView="Create") {
            ViewData["returnView"] = returnView;
            return View(HomeIndexViewModel.ForUserPage(User.Identity.Name, UrlPageIDs["~/create"]));
        }

        public ActionResult Inbox() {
            return View(HomeIndexViewModel.ForUserPage(User.Identity.Name, UrlPageIDs["~/inbox"]));
        }

        public ActionResult Sent() {
            return View(HomeIndexViewModel.ForUserPage(User.Identity.Name, UrlPageIDs["~/sent"]));
        }

        public ActionResult Friends() {
            return View(HomeIndexViewModel.ForUserPage(User.Identity.Name, UrlPageIDs["~/friends"]));
        }

        [HttpPost]
        public ActionResult BlockedUser_Create(DBlocked_User creating) {
            string username = User.Identity.Name;
            HomeIndexViewModel model = new HomeIndexViewModel {
                emails = service.Email_GetByUser(username),
                blockedUsers = profiler.Blocked_User_Create(creating, username),
                friendedUsers = profiler.Friended_User_GetByUser(username),
                navSection = infastructure.PageStructure_GetBySelected(UrlPageIDs["~/friends"])
            };
            return View("Friends", model);
        }

        [HttpPost]
        public ActionResult BlockedUser_Update(DBlocked_User updating) {
            return View("Index");
        }

        [HttpPost]
        public ActionResult BlockedUser_Delete(DBlocked_User deleting) {
            string username = User.Identity.Name;
            HomeIndexViewModel model = new HomeIndexViewModel {
                emails = service.Email_GetByUser(username),
                blockedUsers = profiler.Blocked_User_Delete(deleting, username),
                friendedUsers = profiler.Friended_User_GetByUser(username),
                navSection = infastructure.PageStructure_GetBySelected(UrlPageIDs["~/friends"])
            };
            return View("Friends", model);
        }

        [HttpPost]
        public ActionResult Email_Create(DEmail creating, string returnView="Create") {
            string username = User.Identity.Name;
            ViewData["returnView"] = returnView;
            HomeIndexViewModel model = new HomeIndexViewModel {
                emails = service.Email_Create(creating, username),
                blockedUsers = profiler.Blocked_User_GetByUser(username),
                friendedUsers = profiler.Friended_User_GetByUser(username),
                navSection = infastructure.PageStructure_GetBySelected(UrlPageIDs["~/create"])
            };
            return View(returnView, model);
        }

        [HttpPost]
        public ActionResult Email_Update(DEmail updating) {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Email_Delete(DEmail deleting, string returnView="Create") {
            string username = User.Identity.Name;
            HomeIndexViewModel model = new HomeIndexViewModel {
                emails = service.Email_Delete(deleting, username),
                blockedUsers = profiler.Blocked_User_GetByUser(username),
                friendedUsers = profiler.Friended_User_GetByUser(username),
                navSection = infastructure.PageStructure_GetBySelected(UrlPageIDs["~/sent"])
            };
            return View(returnView, model);
        }

        [HttpPost]
        public ActionResult FriendedUser_Create(DFriended_User creating) {
            string username = User.Identity.Name;
            HomeIndexViewModel model = new HomeIndexViewModel { 
                emails = service.Email_GetByUser(User.Identity.Name),
                blockedUsers = profiler.Blocked_User_GetByUser(User.Identity.Name),
                friendedUsers = profiler.Friended_User_Create(creating, username),
                navSection = infastructure.PageStructure_GetBySelected(UrlPageIDs["~/friends"])
            };
            return View("Friends", model);
        }

        [HttpPost]
        public ActionResult FriendedUser_Update(DFriended_User updating) {
            return View("Index");
        }

        [HttpPost]
        public ActionResult FriendedUser_Delete(DFriended_User deleting) {
            string username = User.Identity.Name;
            HomeIndexViewModel model = new HomeIndexViewModel { 
                emails = service.Email_GetByUser(username),
                blockedUsers = profiler.Blocked_User_GetByUser(username),
                friendedUsers = profiler.Friended_User_Delete(deleting, username),
                navSection = infastructure.PageStructure_GetBySelected(UrlPageIDs["~/friends"])
            };
            return View("Friends", model);
        }
    }
}
