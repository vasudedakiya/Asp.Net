using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class calc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOutput_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNo1.Text) && string.IsNullOrEmpty(txtNo2.Text) && string.IsNullOrEmpty(txtOpratre.Text))
        {

            lblOutput.Text = "Enter num1, num2 and opratre";
        }
        else if (string.IsNullOrEmpty(txtNo1.Text) && string.IsNullOrEmpty(txtNo2.Text))
        {
            lblOutput.Text = "Enter num1 and num2";
        }
        else if (string.IsNullOrEmpty(txtNo1.Text))
        {
            lblOutput.Text = "Enter number 1";
        }
        else if (string.IsNullOrEmpty(txtNo2.Text))
        {
            lblOutput.Text = "Enter number 2";
        }
        else if (string.IsNullOrEmpty(txtOpratre.Text))
        {
            lblOutput.Text = "Enter Opratre ";
        }


        else if (txtOpratre.Text == "+" || txtOpratre.Text == "-" || txtOpratre.Text == "*" || txtOpratre.Text == "/" || txtOpratre.Text == "%")
        {
            if (txtOpratre.Text == "+")
            {
                lblOutput.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text));
            }
            if (txtOpratre.Text == "-")
            {
                lblOutput.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) - Convert.ToInt32(txtNo2.Text));
            }
            if (txtOpratre.Text == "*")
            {
                lblOutput.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) * Convert.ToInt32(txtNo2.Text));
            }
            if (txtOpratre.Text == "/")
            {
                lblOutput.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) / Convert.ToInt32(txtNo2.Text));
            }
            if (txtOpratre.Text == "%")
            {
                lblOutput.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) % Convert.ToInt32(txtNo2.Text));
            }
        }

        else
        {
            lblOutput.Text = "Enter correct Opratre ";
        }
    }
}