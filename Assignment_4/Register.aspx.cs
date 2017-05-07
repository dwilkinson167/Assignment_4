using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        Community_AssistEntities db = new Community_AssistEntities();
        Person p = new Person();
        string lastName = LastNameTextBox.Text;
        string firstName = FirstNameTextBox.Text;
        string email = EmailTextBox.Text;
        string password = PasswordTextBox.Text;
        string apartment = apartmentTextBox.Text;
        string street = StreetTextBox.Text;
        string city = CityTextBox.Text;
        string state = StateTextBox.Text;
        string zip = ZipcodeTextBox.Text;
        string home = HomePhoneTextBox.Text;
        string work = WorkPhoneTextBox.Text;
        int result = db.usp_Register(lastName, firstName,
            email, password, apartment, street, city, state, zip, home, work);
        if( result !=-1)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            ResultLabel.Text = "Something went terribly wrong!";
        }
    }
}