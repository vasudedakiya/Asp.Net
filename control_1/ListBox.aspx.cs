using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_1_ListBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        bool flag = false;

        foreach (ListItem li in lbCountryLeft.Items)
        {
            if (li.Text == txtItem.Text || li.Value == txtValue.Text)
            {
                flag = true;
            }
        }

        if (flag == false)
        {
            lbCountryLeft.Items.Add(new ListItem(txtItem.Text, txtValue.Text));
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
        ListItem n = lbCountryLeft.Items.FindByValue(txtValue.Text);

        foreach (ListItem li in lbCountryLeft.Items)
        {
            if (li.Text == txtItem.Text && li.Value == txtValue.Text)
            {
                flag = true;
            }
        }

        if (flag == true)
        {
            lbCountryLeft.Items.Remove(n);
        }
        else
        {
            lblDisplay.Text = "Not Proper Value Matched";
        }
        txtItem.Text = "";
        txtValue.Text = "";
    }
    protected void btnSelectedLeft_Click(object sender, EventArgs e)
    {
        if (lbCountryLeft.SelectedItem != null)
        {
            lbCountryRight.Items.Add(new ListItem(lbCountryLeft.SelectedItem.Text, lbCountryLeft.SelectedValue));
            lbCountryLeft.Items.Remove(lbCountryLeft.SelectedItem);
        }
    }


    protected void btnAllLeft_Click(object sender, EventArgs e)
    {

        foreach (ListItem li in lbCountryLeft.Items)
        {
            if (lbCountryRight.Items.FindByText(li.Text) != null)
            {
                //lbCountryRight.Items.Add(new ListItem(li.Text, li.Value));
            }
            else
            {
                lbCountryRight.Items.Add(new ListItem(li.Text, li.Value));
            }
        }
    }

    protected void btnSelectedRight_Click(object sender, EventArgs e)
    {
        if (lbCountryRight.SelectedItem != null)
        {
            bool flag = false;
            foreach (ListItem li in lbCountryRight.Items)
            {
                if (lbCountryLeft.Items.FindByText(li.Text) != null)
                {
                    flag = true;

                }
            }
            if (flag == true)
            {
                lbCountryRight.Items.Remove(lbCountryRight.SelectedItem);
            }
            else
            {
                lbCountryLeft.Items.Add(new ListItem(lbCountryRight.SelectedItem.Text, lbCountryRight.SelectedValue));
                lbCountryRight.Items.Remove(lbCountryRight.SelectedItem);

            }
        }

    }

    protected void btnAllRight_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lbCountryRight.Items)
        {
            if (lbCountryLeft.Items.FindByText(li.Text) != null)
            {
                //lbCountryRight.Items.Add(new ListItem(li.Text, li.Value));
            }
            else
            {
                lbCountryLeft.Items.Add(new ListItem(li.Text, li.Value));
            }
        }
    }

    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lbCountryLeft.Items)
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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lbCountryLeft.Items)
        {
            if (li.Text == txtOldItem.Text && li.Value == txtOldValue.Text)
            {

                bool flag = false;

                foreach (ListItem oldli in lbCountryLeft.Items)
                {
                    if (oldli.Text == txtOldItem.Text && oldli.Value == txtOldValue.Text)
                    {
                        continue;
                    }
                    else if (oldli.Value == txtValue.Text )
                    {
                        flag = true;
                    }
                }

                if (flag == false)
                {
                    li.Text = txtItem.Text;
                    li.Value = txtValue.Text;
                }
                else
                {
                    lblDisplay.Text = "Duplicate Value Not allowed";
                }
                    txtItem.Text = "";
                    txtValue.Text = "";
                    txtOldItem.Text = "";
                    txtOldValue.Text = "";
                
            }
        }
    }
}