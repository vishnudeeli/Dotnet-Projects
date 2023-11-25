using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using EAL_Login;
using BAL_Login;

namespace WebLayeredProject
{
    public partial class LoginPage : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
        EALLogin elogin = null;
        BALLogin blogin = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            elogin = new EALLogin();
            blogin = new BALLogin();
            GridView1.DataSource = blogin.ShowdataLogin(connectionString);
            GridView1.DataBind();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            elogin=new EALLogin();
            blogin = new BALLogin();
            elogin.Username = TextBox1.Text;
            elogin.Password = TextBox2.Text;
            
            if(blogin.IsValidateUser(elogin,connectionString))
            {
                Response.Write("valid user");
            }
            else
            {
                Response.Write("Invavalid user");
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            elogin = new EALLogin();
            blogin = new BALLogin();
            elogin.Username = TextBox1.Text;
            elogin.Password = TextBox2.Text;

            

        protected void Button3_Click(object sender, EventArgs e)
        {
            elogin = new EALLogin();
            elogin.Username = TextBox1.Text;
            elogin.Password = TextBox2.Text;
            blogin = new BALLogin();
            int i = blogin.InsertData(elogin, connectionString);
            if (i > 0)
            {
                Response.Write("ROW INSERTED SUCCESSFULLY");
            }
            else
            {
                Response.Write("ROW NOT INSERTED");
            }
            GridView1.DataSource = blogin.ShowdataLogin(connectionString);
            GridView1.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            elogin = new EALLogin();
            elogin.Username = TextBox1.Text;
            elogin.Password = TextBox2.Text;
            blogin = new BALLogin();
            int i = blogin.UpdateData(elogin, connectionString);
            if (i > 0)
            {
                Response.Write("ROW UPDATED SUCCESSFULLY");
            }
            else
            {
                Response.Write("ROW NOT UPDATED(INVALID USERNAME)");
            }
            GridView1.DataSource = blogin.ShowdataLogin(connectionString);
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            elogin = new EALLogin();
            elogin.Username = TextBox1.Text;
            elogin.Password = TextBox2.Text;
            blogin = new BALLogin();
            int i = blogin.DeleteData(elogin, connectionString);
            if (i > 0)
            {
                Response.Write("ROW DELETED SUCCESSFULLY");
            }
            else
            {
                Response.Write("ROW NOT DELETED(INVALID USERNAME OR PASSWORD)");
            }
            GridView1.DataSource = blogin.ShowdataLogin(connectionString);
            GridView1.DataBind();
        }
    }
}