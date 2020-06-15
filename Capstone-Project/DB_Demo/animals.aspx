<%@ Page Language="C#" AutoEventWireup="true" CodeFile="animals.aspx.cs" Inherits="animal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="~/Styles/AdminStyleSheet.css" rel="stylesheet" type="text/css" runat="server"/>

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 15%;
        }

        .auto-style3 {
            width: 10%;
        }

        .auto-style4 {
            width: 27%;
        }

        .auto-style5 {
            width: 55%;
            height: 25px;
        }

        .auto-style10 {
            width: 17%;
        }
        .auto-style11 {
            width: 25%;
            height: 50px;
        }
        .auto-style12 {
            height: 70px;
        }
        .auto-style13 {
            width: 55%;
            height: 35px;
        }
        .auto-style14 {
            height: 35px;
        }
    </style>
</head>
<body>
    <div class="class_big_content_wraper" id="div_big_content_wraper">
    <form id="form1" runat="server">
        <div>
            <p class="main_admin_page"><a href="admin.aspx">Admin Page</a></p>
            <div class="classSpecies" id="idSpecies">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: 220px;">
                <tr>
                    <th colspan="4" style="border: 1px solid black;" class="auto-style12">
                        <asp:Label ID="Label13" runat="server" Text="Add, Update or Delete Specie."></asp:Label>
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="To Add a new Specie you need to enter Specie name in the [Enter Specie Name field], then click [Add Specie]."></asp:Label>
                        <br />
                        <asp:Label ID="Label29" runat="server" Text="To Update Specie you need to select Species in the [All Species], then enter Specie name in the [Update Specie field], then click [Update Specie]."></asp:Label>
                        <br />
                        <asp:Label ID="Label15" runat="server" Text="To Delete Species you need to select Specie in the [All Species], then click [Delete Specie]."></asp:Label>

                    </th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label1" runat="server" Text="Enter Specie Name"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label46" runat="server" Text="All Species"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label48" runat="server" Text="Update Selected Specie"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label49" runat="server" Text="Delete Selected Specie"></asp:Label>

                    </th>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewSpecies" runat="server" type="text" /><br />
                        <asp:Button ID="bAddSpecies" runat="server" Text="Add Specie" OnClick="bAddSpecies_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:DropDownList ID="ddlShowSpecies" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowSpecies_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewSpeciesName" runat="server" type="text" /><br />
                        <asp:Button ID="bUpdateSpecies" runat="server" Text="Update Specie" OnClick="bUpdateSpecies_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:Button ID="bDeleteSpecies" runat="server" Text="Delete Specie" OnClick="bDeleteSpecies_Click" />

                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="border: 1px solid black;">

                        <asp:Label ID="lblSpeciesMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                    </td>
                </tr>
            </table>
                </div>
            <br />
            <div class="classType" id="idType">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: 220px;">
                <tr>
                    <th colspan="4" style="border: 1px solid black;" class="auto-style12">

                        <asp:Label ID="Label42" runat="server" Text="Add, Update or Delete Type"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" runat="server" Text="To Add a new Type you need to enter Type name in the [Enter Type Name field], then click [Add Type]."></asp:Label>
                        <br />
                        <asp:Label ID="Label17" runat="server" Text="To Update Type you need to select Type in the [All Types], then enter Type name in the [Update Type field], then click [Update Type]."></asp:Label>
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="To Delete Type you need to select Type in the [All Types], then click [Delete Type]."></asp:Label>
                    </th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label79" runat="server" Text="Enter Type Name"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label51" runat="server" Text="All Types"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label53" runat="server" Text="Update Selected Type"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label54" runat="server" Text="Delete Selected Type"></asp:Label>

                    </th>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewType" runat="server" type="text" /><br />
                        <asp:Button ID="bAddType" runat="server" Text="Add Type" OnClick="bAddType_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:DropDownList ID="ddlShowTypes" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowTypes_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewTypeName" runat="server" type="text" /><br />
                        <asp:Button ID="bUpdateType" runat="server" Text="Update Type" OnClick="bUpdateType_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:Button ID="bDeleteType" runat="server" Text="Delete Type" OnClick="bDeleteType_Click" />

                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="border: 1px solid black;">

                        <asp:Label ID="lblTypeMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                    </td>
                </tr>
            </table>
                </div>
            <br />
            <div class="classGender" id="idGender">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: 220px;">
                <tr>
                    <th colspan="4" style="border: 1px solid black;" class="auto-style12">
                        <asp:Label ID="Label19" runat="server" Text="Add, Update or Delete Gender"></asp:Label>
                        <br />
                        <asp:Label ID="Label20" runat="server" Text="To Add a new Gender you need to enter Gender name in the [Enter Gender Name field], then click [Add Gender]."></asp:Label>
                        <br />
                        <asp:Label ID="Label21" runat="server" Text="To Update Gender you need to select Gender in the [All Genders], then enter Gender name in the [Update Gender field], then click [Update Gender]."></asp:Label>
                        <br />
                        <asp:Label ID="Label22" runat="server" Text="To Delete Gender you need to select Gender in the [All Genders], then click [Delete Gender]."></asp:Label>
                    </th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label2" runat="server" Text="Enter Gender Name"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label56" runat="server" Text="All Genders"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label58" runat="server" Text="Update Selected Gender"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label59" runat="server" Text="Delete Selected Gender"></asp:Label>

                    </th>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewGender" runat="server" type="text" /><br />
                        <asp:Button ID="bAddGender" runat="server" Text="Add Gender" OnClick="bAddGender_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:DropDownList ID="ddlShowGender" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowGender_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewGenderName" runat="server" type="text" /><br />
                        <asp:Button ID="bUpdateGender" runat="server" Text="Update Gender" OnClick="bUpdateGender_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:Button ID="bDeleteGender" runat="server" Text="Delete Gender" OnClick="bDeleteGender_Click" />

                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="border: 1px solid black;">

                        <asp:Label ID="lblGenderMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                    </td>
                </tr>
            </table>
                </div>
            <br />
            <div class="classAge" id="idAge">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: 220px;">
                <tr>
                    <th colspan="4" style="border: 1px solid black;">
                        <asp:Label ID="Label23" runat="server" Text="Add, Update or Delete Age"></asp:Label>
                        <br />
                        <asp:Label ID="Label24" runat="server" Text="To Add a new Age you need to enter Age name in the [Enter Age Name field], then click [Add Age]."></asp:Label>
                        <br />
                        <asp:Label ID="Label25" runat="server" Text="To Update Age you need to select Age in the [All Ages], then enter Age name in the [Update Age field], then click [Update Age]."></asp:Label>
                        <br />
                        <asp:Label ID="Label26" runat="server" Text="To Delete Age you need to select Age in the [All Ages], then click [Delete Age]."></asp:Label>
                    </th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label3" runat="server" Text="Enter Age Range"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label61" runat="server" Text="All Ages"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label63" runat="server" Text="Update Selected Age"></asp:Label>

                    </th>
                    <th style="border: 1px solid black;">

                        <asp:Label ID="Label64" runat="server" Text="Delete Selected Age"></asp:Label>

                    </th>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewAge" runat="server" type="text" /><br />
                        <asp:Button ID="bAddAge" runat="server" Text="Add Age" OnClick="bAddAge_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:DropDownList ID="ddlShowAge" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowAge_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <input id="txNewAgeRange" runat="server" type="text" /><br />
                        <asp:Button ID="bUpdateAge" runat="server" Text="Update Age" OnClick="bUpdateAge_Click" />
                    </td>
                    <td style="border: 1px solid black;" class="auto-style11">
                        <asp:Button ID="bDeleteAge" runat="server" Text="Delete Age" OnClick="bDeleteAge_Click" />

                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="border: 1px solid black;">

                        <asp:Label ID="lblAgeMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                    </td>
                </tr>
            </table>
                </div>
            <br />
            <div class="classAnimalSelection" id="idAnimalSelection">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: 185px;">
                <tr>
                    <th colspan="6" style="border: 1px solid black;">

                        <asp:Label ID="Label9" runat="server" Text="Add, Update, Delete Animal"></asp:Label>
                        <br />
                        <asp:Label ID="Label71" runat="server" Text="To find Animal you need select [Origin, Spice, Type, Gender or Age] in the Drop Down Lists, then click [Find Animal]."></asp:Label>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="To Add a new Animal you need select [Origin, Spices, Type, Gender and Age] in the Drop Down Lists, then click [Add Animal]."></asp:Label>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="To Update existing Animal you need select Animal from [All Animals] and specify new Origin, Spices, Type, Gender or Age, then click [Update Animal]."></asp:Label>
                    </th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;" class="auto-style4">
                        <asp:Label ID="Label77" runat="server" Text="Select Origin"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;" class="auto-style10">
                        <asp:Label ID="Label68" runat="server" Text="Select Specie"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;" class="auto-style10">
                        <asp:Label ID="Label69" runat="server" Text="Select Type"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;" class="auto-style1">
                        <asp:Label ID="Label70" runat="server" Text="Select Gender"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;" class="auto-style3">
                        <asp:Label ID="Label76" runat="server" Text="Select Age"></asp:Label>
                    </th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label4" runat="server" Text="Find Animal"></asp:Label></th>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style4">
                        <asp:DropDownList ID="ddlOrigins" runat="server" Width="250px" AutoPostBack="False">
                        </asp:DropDownList>

                    </td>
                    <td style="border: 1px solid black;" class="auto-style10">
                        <asp:DropDownList ID="ddlSpecies" runat="server" AutoPostBack="False">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style10">
                        <asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="False">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style1">
                        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="False">
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid black;" class="auto-style3">
                        <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="False">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 25%; border: 1px solid black;">
                        <asp:Button ID="bFindAnimal" runat="server" Text="Find Animal" OnClick="bFindAnimal_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="border: 1px solid black;">
                        <asp:Label ID="lblNoAnimal" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>
                    </td>
                </tr>

            </table>
                </div>



            <div class="classAnimal" id="idAnimal">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: auto;">
                <tr>
                    <th style="border: 1px solid black;" class="auto-style5">
                        <asp:Label ID="Label5" runat="server" Text="All Animals"></asp:Label></th>
                </tr>
                <tr>
                    <td style="border: 1px solid black; " class="auto-style13">
                        <asp:DropDownList ID="ddlShowAnimals" runat="server" Width="540px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowAnimals_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style14">

                        <asp:Label ID="Label78" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="border: 1px solid black;" class="auto-style14">


                        <asp:Label ID="lblAnimalMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>


                    </td>
                </tr>
            </table>
                </div>


            <div class="classAnimalButtons" id="idAnimalButtons">
            <table style="width: 100%; text-align: center; border: 1px solid black; height: 75px;">
                <tr>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label6" runat="server" Text="Add Animal"></asp:Label></th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label7" runat="server" Text="Update Animal"></asp:Label></th>
                    <th style="border: 1px solid black;">
                        <asp:Label ID="Label8" runat="server" Text="Delete Animal"></asp:Label></th>
                </tr>
                <tr>
                    <td style="width: 25%; border: 1px solid black;">
                        <asp:Button ID="bAddAnimal" runat="server" Text="Add Animal" OnClick="bAddAnimal_Click" />
                    </td>
                    <td style="width: 25%; border: 1px solid black;">
                        <asp:Button ID="bUpdateAnimal" runat="server" Text="Update Animal" OnClick="bUpdateAnimal_Click" />
                    </td>
                    <td style="width: 25%; border: 1px solid black;">
                        <asp:Button ID="bDeleteAnimal" runat="server" Text="Delete Animal" OnClick="bDeleteAnimal_Click" />
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
