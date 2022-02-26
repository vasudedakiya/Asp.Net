using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class radio_checkbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            allDegreeLbl.Visible = false;
            allDiploLbl.Visible = false;
        }
        
    }

    protected void btnSelectDep_Click(object sender, EventArgs e)
    {
        if (rbDegree.Checked == true)
        {
            allDegreeLbl.Visible = true;
            allDiploLbl.Visible = false;
        }
        if (rbDiploma.Checked == true)
        {

            allDegreeLbl.Visible = false;
            allDiploLbl.Visible = true;
        }
    }

    protected void btnDisplayRadio_Click(object sender, EventArgs e)
    {
        if (rbDegree.Checked == true)
        {
            if (rbCI.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDegree.Text + "</strong> and <strong>" + rbCI.Text + "</strong>";
            }
            else if (rbCE.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDegree.Text + "</strong> and <strong>" + rbCE.Text + "</strong>";
            }
            else if (rbEE.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDegree.Text + "</strong> and <strong>" + rbEE.Text + "</strong>";
            }
            else if (rbME.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDegree.Text + "</strong> and <strong>" + rbME.Text + "</strong>";
            }
        }
        else if (rbDiploma.Checked == true)
        {
            if (rbDiCE.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDiploma.Text + "</strong> and <strong>" + rbDiCE.Text + "</strong>";
            }
            else if (rbDiCI.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDiploma.Text + "</strong> and <strong>" + rbDiCI.Text + "</strong>";
            }
            else if (rbDiEE.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDiploma.Text + "</strong> and <strong>" + rbDiEE.Text + "</strong>";
            }
            else if (rbDiME.Checked == true)
            {
                lblSelection.Text = "You Selected <strong>" + rbDiploma.Text + "</strong> and <strong>" + rbDiME.Text + "</strong>";
            }
        }
    }

    //--------------------------------------------------------------------------
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        chkCE.Checked = true;
        chkEC.Checked = true;
        chkCI.Checked = true;
        chkME.Checked = true;
    }
    protected void chkNone_CheckedChanged(object sender, EventArgs e)
    {
        chkAll.Checked = false;
        chkAlternative.Checked = false;
        chkCE.Checked = false;
        chkEC.Checked = false;
        chkCI.Checked = false;
        chkME.Checked = false;
    }
    protected void chkAlternative_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCE.Checked == false)
        {
            chkCE.Checked = true;
        }
        else if (chkCE.Checked == true)
        {
            chkCE.Checked = false;
        }
        //---------------------------------------
        if (chkEC.Checked == false)
        {
            chkEC.Checked = true;
        }
        else if (chkEC.Checked == true)
        {
            chkEC.Checked = false;
        }
        //---------------------------------------
        if (chkCI.Checked == false)
        {
            chkCI.Checked = true;
        }
        else if (chkCI.Checked == true)
        {
            chkCI.Checked = false;
        }
        //---------------------------------------
        if (chkME.Checked == false)
        {
            chkME.Checked = true;
        }
        else if (chkME.Checked == true)
        {
            chkME.Checked = false;
        }
    }
    //protected void chkDiAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    chkDiCE.Checked = true;
    //    chkDiEC.Checked = true;
    //    chkDiCI.Checked = true;
    //    chkDiME.Checked = true;
    //}
    //protected void chkDiNone_CheckedChanged(object sender, EventArgs e)
    //{
    //    chkDiAll.Checked = false;
    //    chkDiSlternative.Checked = false;
    //    chkDiCE.Checked = false;
    //    chkDiEC.Checked = false;
    //    chkDiCI.Checked = false;
    //    chkDiME.Checked = false;
    //}
    //protected void chkDiSlternative_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkDiCE.Checked == false)
    //    {
    //        chkDiCE.Checked = true;
    //    }
    //    else if (chkDiCE.Checked == true)
    //    {
    //        chkDiCE.Checked = false;
    //    }
    //    //---------------------------------------
    //    if (chkDiEC.Checked == false)
    //    {
    //        chkDiEC.Checked = true;
    //    }
    //    else if (chkDiEC.Checked == true)
    //    {
    //        chkDiEC.Checked = false;
    //    }
    //    //---------------------------------------
    //    if (chkDiCI.Checked == false)
    //    {
    //        chkDiCI.Checked = true;
    //    }
    //    else if (chkDiCI.Checked == true)
    //    {
    //        chkDiCI.Checked = false;
    //    }
    //    //---------------------------------------
    //    if (chkDiME.Checked == false)
    //    {
    //        chkDiME.Checked = true;
    //    }
    //    else if (chkDiME.Checked == true)
    //    {
    //        chkDiME.Checked = false;
    //    }
    //}

    protected void btnDisplayChk_Click(object sender, EventArgs e)
    {
        lblDisplayChk.Text = "Your Fav Branch are : ";
        if (chkCE.Checked == true)
        {
            lblDisplayChk.Text += "<br/><strong> " + chkCE.Text + "</strong>, ";
        }
        if (chkEC.Checked == true)
        {
            lblDisplayChk.Text += "<br/><strong> " + chkEC.Text + "</strong>, ";
        }
        if (chkCI.Checked == true)
        {
            lblDisplayChk.Text += "<br/><strong> " + chkCI.Text + "</strong>, ";
        }
        if (chkME.Checked == true)
        {
            lblDisplayChk.Text += "<br/><strong> " + chkME.Text + "</strong>, ";
        }
    }
}