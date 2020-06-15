<%@ Page Language="C#" AutoEventWireup="true" CodeFile="origins.aspx.cs" Inherits="origin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="~/Styles/AdminStyleSheet.css" rel="stylesheet" type="text/css" runat="server"/>

    <title></title>
    <style type="text/css">
        .auto-style7 {
            width: 20%;
        }

        .auto-style9 {
            width: 12%;
        }

        .auto-style10 {
            width: 10%;
        }

        .auto-style11 {
            width: 47%;
        }
        .auto-style12 {
            height: 45px;
        }
    </style>
</head>
<body>
    <div class="class_big_content_wraper" id="div_big_content_wraper">
        <form id="form1" runat="server">
            <div>
                <p class="main_admin_page"><a href="admin.aspx">Admin Page</a></p>

                <div class="classCountry" id="idCountry">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 240px;">
                        <tr>
                            <th style="border: 1px solid black;" colspan="4">
                                <asp:Label ID="Label1" runat="server" Text="Add, Update or Delete Country."></asp:Label>
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="To Add a new Country you need to enter Country name in the [Enter Country Name field], then click [Add Country]."></asp:Label>
                                <br />
                                <asp:Label ID="Label29" runat="server" Text="To Update Country you need to select Country in the [All Countries], then enter Country name in the [Update Country field], then click [Update Country]."></asp:Label>
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="To Delete Country you need to select Country in the [All Countries], then click [Delete Country]."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label40" runat="server" Text="Enter Country Name"></asp:Label></th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label7" runat="server" Text="All Countries"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label8" runat="server" Text="Update Country"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label10" runat="server" Text="Delete Selected Country"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewCountry" runat="server" type="text" /><br />
                                <asp:Button ID="bAddCountry" runat="server" Text="Add Country" OnClick="bAddCountry_Click" />
                            </td>

                            <td style="width: 25%; border: 1px solid black;">
                                <asp:DropDownList ID="ddlShowCountries" runat="server" Width="175px" OnSelectedIndexChanged="ddlShowCountries_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewCountryName" runat="server" type="text" /><br />
                                <asp:Button ID="bUpdateCountry" runat="server" Text="Update Country" OnClick="bUpdateCountry_Click" />
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <br />
                                <asp:Button ID="bDeleteCountry" runat="server" Text="Delete Country" OnClick="bDeleteCountry_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" colspan="4">

                                <asp:Label ID="lblCountryMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>

                <br />
                <div class="classState" id="idState">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 240px;">
                        <tr>
                            <th colspan="4" style="border: 1px solid black;">
                                <asp:Label ID="Label12" runat="server" Text="Add, Update or Delete State or Provinces."></asp:Label>
                                <br />
                                <asp:Label ID="Label13" runat="server" Text="To Add a new State you need to enter State name in the [Enter State or Province Name field], then click [Add State]."></asp:Label>
                                <br />
                                <asp:Label ID="Label15" runat="server" Text="To Update State you need to select State in the [All States], then enter State name in the [Update State field], then click [Update State]."></asp:Label>
                                <br />
                                <asp:Label ID="Label16" runat="server" Text="To Delete State you need to select State in the [All States], then click [Delete State]."></asp:Label>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label41" runat="server" Text="Enter State or Province Name"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label14" runat="server" Text="All States"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label31" runat="server" Text="Update State"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label17" runat="server" Text="Delete State"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewState" runat="server" type="text" /><br />
                                <asp:Button ID="bAddState" runat="server" Text="Add State" OnClick="bAddState_Click" />

                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:DropDownList ID="ddlShowStates" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowStates_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewStateName" runat="server" type="text" /><br />
                                <asp:Button ID="bUpdateState" runat="server" Text="Update State" OnClick="bUpdateState_Click" />

                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <br />
                                <asp:Button ID="bDeleteState" runat="server" Text="Delete State" OnClick="bDeleteState_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" colspan="4">
                                <asp:Label ID="lblStateMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>

                <br />
                <div class="classCounty" id="idCounty">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 240px;">
                        <tr>
                            <th colspan="4" style="border: 1px solid black;">
                                <asp:Label ID="Label19" runat="server" Text="Add, Update, Delete County"></asp:Label>
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="To Add a new County you need to enter County name in the [Enter County Name field], then click [Add County]."></asp:Label>
                                <br />
                                <asp:Label ID="Label6" runat="server" Text="To Update County you need to select County in the [All Counties], then enter County name in the [Update County field], then click [Update County]."></asp:Label>
                                <br />
                                <asp:Label ID="Label18" runat="server" Text="To Delete County you need to select County in the [All Counties], then click [Delete County]."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label2" runat="server" Text="Enter County Name."></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label33" runat="server" Text="All Counties"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label34" runat="server" Text="Update County"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label35" runat="server" Text="Delete County"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewCounty" runat="server" type="text" /><br />
                                <asp:Button ID="bAddCounty" runat="server" Text="Add County" OnClick="bAddCounty_Click" />

                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:DropDownList ID="ddlShowCounties" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowCounties_SelectedIndexChanged1">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewCountyName" runat="server" type="text" /><br />
                                <asp:Button ID="bUpdateCounty" runat="server" Text="Update County" OnClick="bUpdateCounty_Click" />

                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <br />
                                <asp:Button ID="bDeleteCounty" runat="server" Text="Delete County" OnClick="bDeleteCounty_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" colspan="4">

                                <asp:Label ID="lblCountyMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>

                <br />
                <div class="classOrigin" id="idOrigin">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 240px;">
                        <tr>
                            <th colspan="5" style="border: 1px solid black;">
                                <asp:Label ID="Label4" runat="server" Text="Add, Update, Delete Origin"></asp:Label>
                                <br />
                                <asp:Label ID="Label38" runat="server" Text="To Add a new Origin you need to select Country, State and County, then click [Add Origin]."></asp:Label>
                                <br />
                                <asp:Label ID="Label9" runat="server" Text="To Update existing Origin you need to select Origin in [All Origins], then you need to select Country, State or County, then click [Update Origin]."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;" class="auto-style9">
                                <asp:Label ID="Label26" runat="server" Text="Select Country"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style7">
                                <asp:Label ID="Label27" runat="server" Text="Select State"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style9">
                                <asp:Label ID="Label28" runat="server" Text="Select County"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style10">
                                <asp:Label ID="Label42" runat="server" Text="Add Origin"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style11">
                                <asp:Label ID="Label37" runat="server" Text="All Origins"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black; width: 12%;">
                                <asp:DropDownList ID="ddlCountries" runat="server">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td style="border: 1px solid black; width: 20%;">
                                <asp:DropDownList ID="ddlStates" runat="server">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td style="border: 1px solid black; width: 12%;">
                                <asp:DropDownList ID="ddlCounties" runat="server">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td style="border: 1px solid black; width: 10%;">
                                <br />
                                <asp:Button ID="bAddOrigin" runat="server" Text="Add Origin" OnClick="bAddOrigin_Click" />
                            </td>
                            <td style="border: 1px solid black; width: 46%;">
                                <asp:DropDownList ID="ddlShowOrigins" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowOrigins_SelectedIndexChanged">
                                </asp:DropDownList>

                                <br />
                                <asp:Button ID="bUpdateOrigin" runat="server" Text="Update Origin" OnClick="bUpdateOrigin_Click" />
                                <asp:Button ID="bDeleteOrigin" runat="server" Text="Delete Origin" OnClick="bDeleteOrigin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" colspan="5">

                                <asp:Label ID="lblOriginMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <p class="main_admin_page"><a href="admin.aspx">Admin Page</a></p>
            </div>
        <div> 
        <asp:Table ID="exceptionsTable" runat="server" Height="215px" Width="100%" BorderStyle="Solid" Visible="false">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell BorderStyle="Solid">
                <asp:Label ID="lblExceptions" runat="server" Text="Exceptions that occurred in the Origin Class"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell BorderStyle="Solid" HorizontalAlign="Center">
                <asp:ListBox ID="lbExceptions" runat="server" Height="128px" Width="95%"></asp:ListBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
            </div>
        </form>
    </div>
    </body>
</html>
