using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace MyCrudProject.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo=new ClientInfo();
        public string errormessage = "";
        public string successmessage = "";

        public void OnGet()
        {

        }
        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address=Request.Form["address"];

            if(clientInfo.name.Length==0|| clientInfo.email.Length==0 || 
                clientInfo.phone.Length==0 || clientInfo.address.Length==0)
            {
                errormessage = "All the fields are required";
                return;
            }
            //save the data inti database
            clientInfo.name = "";clientInfo.email = "";clientInfo.phone = "";clientInfo.address = "";
            successmessage = "New Client Added correctly";
        }
    }
}
