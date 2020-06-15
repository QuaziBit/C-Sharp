<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="UserDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width" />

    <link href="//template.mt.gov/resources/template/template.css" rel="stylesheet" type="text/css" />
    <script src="//template.mt.gov/resources/template/template.js" type="text/javascript"></script>

    <link href="//ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/themes/start/jquery-ui.css" type="text/css" rel="Stylesheet" />

    <link href="~/Styles/UserStyleSheet.css" rel="stylesheet" type="text/css" runat="server"/>

    <title></title>
</head>

<body class="desktop">

    <header id="template-header">
    </header>

    <div id="template-page-wrapper" class="main_wraper">
        <div class="menu">
            <form id="form2" runat="server">
                <div class="menu_element">
                    <asp:Label ID="lSpecies" runat="server" Text="Species"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlSpecies" runat="server" Height="30px" Width="130px" Font-Size="17px" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecies_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="menu_element">
                    <asp:Label ID="lCountry" runat="server" Text="Countries"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlCountry" runat="server" Height="30px" Width="130px" Font-Size="17px" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="menu_element">
                    <asp:Label ID="lState" runat="server" Text="States/Provinces"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlState" runat="server" Height="30px" Width="200px" Font-Size="17px">
                    </asp:DropDownList>
                </div>
                <div class="menu_element">
                    <asp:Label ID="lCounty" runat="server" Text="Counties"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlCounty" runat="server" Height="30px" Width="130px" Font-Size="17px">
                    </asp:DropDownList>
                </div>
                <div class="menu_element">
                    <asp:Label ID="lType" runat="server" Text="Types"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlType" runat="server" Height="30px" Width="130px" Font-Size="17px">
                    </asp:DropDownList>
                </div>
                <div class="menu_element">
                    <asp:Label ID="lGender" runat="server" Text="Gender"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlGender" runat="server" Height="30px" Width="130px" Font-Size="17px">
                    </asp:DropDownList>
                </div>
                <div class="menu_element">
                    <asp:Label ID="lAge" runat="server" Text="Age"></asp:Label>
                    <br />
                    <asp:DropDownList class="ddlList" ID="ddlAge" runat="server" Height="30px" Width="130px" Font-Size="17px">
                    </asp:DropDownList>
                </div>
                <div class="menu_element_button">
                    <asp:Button ID="bShowReq" runat="server" Text="Show Requirements" Font-Size="Large" OnClick="bShowReq_Click"/>
                </div>
            </form>
        </div>
        <div runat="server" class="content" id="animlaContent">
        </div>
    </div>

    <footer id="template-footer">
    </footer>
</body>
</html>


