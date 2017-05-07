using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Donate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //make sure they are logged in to see this page.
        if (Session["userKey"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void DonateButton1_Click(object sender, EventArgs e)
    {
        Community_AssistEntities db = new Community_AssistEntities();
        
        var key = (int)Session["userKey"];

        
        Donation d = new Donation();
        //assign the values
        d.DonationAmount = decimal.Parse(DonationTextBox.Text);
        d.DonationDate = DateTime.Now;
        d.PersonKey = key;

        //add the donation to the collection Donations
        db.Donations.Add(d);
        //save the changes to the database
        db.SaveChanges();

        Response.Redirect("Donations.Aspx");
    }
}