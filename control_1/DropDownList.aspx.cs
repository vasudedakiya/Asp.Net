using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_1_DropDownList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool flag = false;

        foreach (ListItem li in ddlCountry.Items)
        {
            if (li.Text == txtItem.Text || li.Value == txtValue.Text)
            {
                flag = true;
            }
        }

        if (flag == false)
        {
            ddlCountry.Items.Add(new ListItem(txtItem.Text, txtValue.Text));
        }
        else
        {
            lblDisplay.Text = "Duplicate Value Not allowed";
        }
        txtItem.Text = "";
        txtValue.Text = "";
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {

        bool flag = false;
        ListItem n = ddlCountry.Items.FindByValue(txtValue.Text);

        foreach (ListItem li in ddlCountry.Items)
        {
            if (li.Text == txtItem.Text && li.Value == txtValue.Text)
            {
                flag = true;
            }
        }

        if (flag == true)
        {
            ddlCountry.Items.Remove(n);
        }
        else
        {
            lblDisplay.Text = "Not Proper Value Matched";
        }
        txtItem.Text = "";
        txtValue.Text = "";
    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {


        foreach (ListItem li in ddlCountry.Items)
        {
            if (li.Selected == true)
            {
                lblDisplay.Text += "<strong>" + li.Value.Trim() + " - " + li.Text.Trim() + "</strong>" + "<br/>";
            }
            else
            {
                lblDisplay.Text += li.Value.Trim() + " - " + li.Text.Trim() + "<br/>";
            }
        }
    }
}