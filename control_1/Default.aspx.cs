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
        divBranchDegree.Visible = false;
        divBranchDiploma.Visible = false;

    }
    protected void btnSelectDep_Click(object sender, EventArgs e)
    {
        if (rbDegree.Checked == true)
        {
            divBranchDegree.Visible = true;
            divBranchDiploma.Visible = false;
        }
        if (rbDiploma.Checked == true)
        {

            divBranchDegree.Visible = false;
            divBranchDiploma.Visible = true;
        }
    }
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
        if (chkCE.Checked == true)
        {
            chkCE.Checked = false;
        }
        if (chkEC.Checked == true)
        {
            chkEC.Checked = false;
        }
        if (chkCI.Checked == true)
        {
            chkCI.Checked = false;
        }
        if (chkME.Checked == true)
        {
            chkME.Checked = false;
        }

        if (chkCE.Checked == false)
        {
            chkCE.Checked = true;
        }
        if (chkEC.Checked == false)
        {
            chkEC.Checked = true;
        }
        if (chkCI.Checked == false)
        {
            chkCI.Checked = true;
        }
        if (chkME.Checked == false)
        {
            chkME.Checked = true;
        }
    }
}