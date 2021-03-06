<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContectAddEdit.aspx.cs" Inherits="AdminPanel_Contect_ContectAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">


    <div class="row">
        <div class="col-md-12">
            <h2 style="font-family: Verdana; text-align: center; color: dodgerblue">Contect Add/Edit Page</h2>
            <hr style="color: lightblue; border: double" />
        </div>
    </div>

    <%-- ------------------------- --%>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Contact Name: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtContectName" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- ---------------------------- --%>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Contact Number: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>


    <%-- ------------------------------- --%>

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Country :</h3>
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" ></asp:DropDownList>
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">State :</h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">City :</h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:DropDownList ID="ddlCityID" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- ------------------------------- --%>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">WhatsApp No: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtWhatsAppNo" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- ---------------------------- --%>



    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Category :</h3>
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlContactCategory" runat="server" CssClass="form-control" AutoPostBack="true" ></asp:DropDownList>
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>


    <%-- -------------------------------- --%>
     <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Birth-Date: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- ------------------------------- --%>
     <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Email: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>

     <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Age: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>

     <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Address: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>

     <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Blood-Group: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">FaceBook ID: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtFaceBookID" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">LinkdIn ID: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtLinkdInID" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <%-- -------------------------------- --%>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-md" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-md" OnClick="btnCancel_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 text-center">
            <strong>
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text="" EnableViewState="False"></asp:Label>
            </strong>
        </div>
    </div>

    <%-- --------------------------------------------------------------------------------------------- --%>
    <br /> <br /> <br /> <br />
    

</asp:Content>


