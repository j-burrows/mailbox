using System.Web.Mvc;

namespace Mailbox.Helpers{
    public static class SectionHelper{
        public static MvcHtmlString ValidationSection(this string errorMessage) {
            string formattedErrorMessage = "<span class=\"ValidationError\">";
            if(errorMessage != null && errorMessage != string.Empty){
                formattedErrorMessage += errorMessage;
            }
            formattedErrorMessage += "</span>";
            return MvcHtmlString.Create(formattedErrorMessage);
        }
    }
}