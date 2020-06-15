<%@ Page Language="C#" AutoEventWireup="true" CodeFile="animal_requirements.aspx.cs" Inherits="animal_requirements" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="~/Styles/AdminStyleSheet.css" rel="stylesheet" type="text/css" runat="server"/>

    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }

        .auto-style2 {
            width: 12%;
        }

        .auto-style4 {
            width: 17%;
        }

        .auto-style5 {
            width: 10%;
        }

        .auto-style6 {
            width: 23%;
        }

        .auto-style7 {
            width: 23%;
            height: 45px;
        }

        .auto-style8 {
            width: 17%;
            height: 45px;
        }

        .auto-style9 {
            width: 12%;
            height: 45px;
        }

        .auto-style10 {
            width: 10%;
            height: 45px;
        }

        .auto-style11 {
            width: 25%;
            height: 45px;
        }
    </style>
</head>
<body>
    <div class="class_big_content_wraper" id="div_big_content_wraper">
        <form id="form1" runat="server">
            <div>
                <div class="classAddAnimalReq" id="idAddAnimalReq">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 440px;">
                        <tr>
                            <th colspan="4" style="border: 1px solid black;">
                                <asp:Label ID="Label102" runat="server" Text="Add Requirement for specific Animal"></asp:Label>
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="To Add Requirement for specific Animal you need to select Animal in the [All Animals], then select [Requirement] in the [All available Requirements], then click [Add Animal Requirement]."></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="To Delete Requirement from Animal you need to select Animal in the [All Animals], then select Requirement in the [Requirements that connected to the selected Animal], then click [Delete Animal Requirement]"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black; text-align: left;">

                                <asp:Label ID="Label105" runat="server" Text="All Animals"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black; text-align: left;">
                                <asp:DropDownList ID="ddlAnimals" runat="server" Width="700px" AutoPostBack="True" OnSelectedIndexChanged="ddlAnimals_SelectedIndexChanged">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black; text-align: left;">

                                <asp:Label ID="Label106" runat="server" Text="Requirements that connected to the selected Animal"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black; text-align: left;">
                                <asp:DropDownList ID="ddlAnimalRequirements" runat="server" Width="700px" AutoPostBack="False">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black; text-align: left;">

                                <asp:Label ID="Label107" runat="server" Text="All available Requirements"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black; text-align: left;">
                                <asp:DropDownList ID="ddlAvailableRequirements" runat="server" Width="700px" AutoPostBack="False">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black; text-align: left;">
                                <asp:Label ID="Label109" runat="server" Text="Add Animal Requirement"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black; text-align: left;">
                                <asp:Button ID="bAddAnimalRequirement" runat="server" Text="Add Animal Requirement" OnClick="bAddAnimalRequirement_Click" />

                            </td>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black; text-align: left;">
                                <asp:Label ID="Label110" runat="server" Text="Delete Animal Requirement"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black; text-align: left;">
                                <asp:Button ID="bDeleteAnimalRequirement" runat="server" Text="Delete Animal Requirement" OnClick="bDeleteAnimalRequirement_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border: 1px solid black;" class="auto-style1">

                                <asp:Label ID="lblAnimalRequirementMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>
                <div class="classAnimalSearch" id="idAnimalSearch">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 175px;">
                        <tr>
                            <th colspan="6" style="border: 1px solid black;">
                                <asp:Label ID="Label1" runat="server" Text="Animal Search"></asp:Label></th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;" class="auto-style6">
                                <asp:Label ID="Label77" runat="server" Text="Select Origin"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style6">
                                <asp:Label ID="Label68" runat="server" Text="Select Species"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style4">
                                <asp:Label ID="Label69" runat="server" Text="Select Type"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style2">
                                <asp:Label ID="Label70" runat="server" Text="Select Gender"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;" class="auto-style5">
                                <asp:Label ID="Label76" runat="server" Text="Select Age"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label2" runat="server" Text="Find Animal"></asp:Label></th>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" class="auto-style7">
                                <asp:DropDownList ID="ddlOrigins" runat="server" Width="250px" AutoPostBack="False">
                                </asp:DropDownList>

                            </td>
                            <td style="border: 1px solid black;" class="auto-style7">
                                <asp:DropDownList ID="ddlSpecies" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
                            </td>
                            <td style="border: 1px solid black;" class="auto-style8">
                                <asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
                            </td>
                            <td style="border: 1px solid black;" class="auto-style9">
                                <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
                            </td>
                            <td style="border: 1px solid black;" class="auto-style10">
                                <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
                            </td>
                            <td style="border: 1px solid black;" class="auto-style11">
                                <asp:Button ID="FindAnimal" runat="server" Text="Find Animal" OnClick="FindAnimal_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="border: 1px solid black;" class="auto-style1">

                                <asp:Label ID="lblNoAnimal" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>
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
