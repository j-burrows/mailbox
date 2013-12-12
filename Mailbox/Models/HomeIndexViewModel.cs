using System.Collections.Generic;
using InfastructureLib;
using InfastructureLib.Data.Entities;
using MailboxLib;
using MailboxLib.Data.Entities;
using System.Linq;
using UserProfileLib.Data.Entities;
using UserProfileLib;
namespace Mailbox.Models{
    public class HomeIndexViewModel{
        private string username;
        public IEnumerable<DEmail> emails{get;set;}
        public IEnumerable<DBlocked_User> blockedUsers { get; set; }
        public IEnumerable<DFriended_User> friendedUsers { get; set; }
        public IEnumerable<IEnumerable<DPage>> navSection { get; set; }

        public IEnumerable<DEmail> Inbox { get {
            return emails.Where(x => x.Recipient.Equals(username) && !blockedUsers.Any(y => y.Author_Name.Equals(x.Sender)));
        } }
        public IEnumerable<DEmail> BlockedInbox { get { 
            return emails.Where(x => x.Recipient.Equals(username) && blockedUsers.Any(y => y.Author_Name.Equals(x.Sender)));
        } }
        public IEnumerable<DEmail> Sent {
            get {
                return emails.Where(x => x.Sender.Equals(username));
            }
        }

        public HomeIndexViewModel() {}

        public static HomeIndexViewModel ForUserPage(string username, int Page_ID){
            IInfastructureService infastructure = new InfastructureService();
            IMailboxService provider = new MailboxService();
            IProfileService profiler = new ProfileService();
            
            return new HomeIndexViewModel {
                username = username,
                emails = provider.Email_GetByUser(username),
                blockedUsers = profiler.Blocked_User_GetByUser(username),
                friendedUsers = profiler.Friended_User_GetByUser(username),
                navSection = infastructure.PageStructure_GetBySelected(Page_ID)
            };
        }
    }
}