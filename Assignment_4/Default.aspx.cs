using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //we are using the same stored procedure that was
        //used in the previous assignment but Entites
        //treats it as a method. It still returns -1 for no match
        Community_AssistEntities cae = new Community_AssistEntities();
        int result = cae.usp_Login(UserNameTextBox.Text, PasswordTextBox.Text);
        if(result != -1)
        {
            //here we do a linq query to get the user key
            var email = UserNameTextBox.Text;
            var key = (from p in cae.People
                       where p.PersonEmail.Equals(email)
                       select p.PersonKey).FirstOrDefault();
            //cast the result to integer
            //assign it to a session variable.
            Session["userKey"] = key;
            Response.Redirect("Donate.aspx");
        }
        else
        {
            ErrorLabel.Text = "Invalid login";
        }
    }
}