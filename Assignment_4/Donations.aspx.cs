using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Donations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userKey"] != null)
        {
            Community_AssistEntites db = new Community_AssistEntites();
            int key = (int)Session["userKey"]);
            var don = (from d in db.Donations
                where d.PersonKey == key
                select d).ToList();
            Gridview1.DataSource = don;
            Gridview1.Databind();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    

}