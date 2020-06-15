<%@ Page Language="C#" AutoEventWireup="true" CodeFile="requirements.aspx.cs" Inherits="requirements" validateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="~/Styles/AdminStyleSheet.css" rel="stylesheet" type="text/css" runat="server"/>

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 25%;
            height: 38px;
        }

        .auto-style2 {
            width: 12%;
        }
    </style>
</head>
<body>
    <div class="class_big_content_wraper" id="div_big_content_wraper">
        <form id="form1" runat="server">
            <div>
                <p class="main_admin_page"><a href="admin.aspx">Admin Page</a></p>
                <div class="classAddReqType" id="idAddReqType">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 220px;">
                        <tr>
                            <th colspan="4" style="border: 1px solid black;">
                        <asp:Label ID="Label13" runat="server" Text="Add, Update or Delete Requirement Type."></asp:Label>
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="To Add a new [Requirement Type] you need to enter [Requirement Type] in the [Enter Requirement Type field], then click [Add Requirement Type]."></asp:Label>
                        <br />
                        <asp:Label ID="Label29" runat="server" Text="To Update [Requirement Type] you need to select [Requirement Type] in the [All Requirement Types], then enter [Requirement Type] in the [Update Requirement Type field], then click [Update Requirement Type]."></asp:Label>
                        <br />
                        <asp:Label ID="Label15" runat="server" Text="To Delete [Requirement Type] you need to select [Requirement Type] in the [All Requirement Types], then click [Delete Requirement Type]."></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label1" runat="server" Text="Enter Requirement Type"></asp:Label></th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label80" runat="server" Text="All Requirement Types"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label82" runat="server" Text="Update Selected Requirement Type"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label83" runat="server" Text="Delete Selected Requirement Type"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txNewRequirementType" runat="server" type="text" /><br />
                                <asp:Button ID="bAddRequirementType" runat="server" Text="Add Requirement Type" OnClick="bAddRequirementType_Click" />
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:DropDownList ID="ddlShowRequirementTypes" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowRequirementTypes_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <input id="txUpdateRequirementType" runat="server" type="text" /><br />
                                <asp:Button ID="bUpdateRequirementType" runat="server" Text="Update Requirement Type" OnClick="bUpdateRequirementType_Click" />
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:Button ID="bDeleteRequirementType" runat="server" Text="Delete Requirement Type" OnClick="bDeleteRequirementType_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border: 1px solid black;">

                                <asp:Label ID="lblRequirementTypeMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>
                <br />

                <br />
                <div class="classAddReqName" id="idAddReqName">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 250px;">
                        <tr>
                            <th colspan="2" style="border: 1px solid black;">

                        <asp:Label ID="Label3" runat="server" Text="Add Requirement."></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="To Add a new [Requirement] you need to specify [Requirement Type] for a new [Requirement] to do this, select [Requirement Type] in the [Available Requirement Types], then enter name for a new Requirement in the [Requirement Name]. "></asp:Label>
                                <br />
                                <asp:Label ID="Label9" runat="server" Text="In addition, you need to enter Link, Text and HTML information in the appropriate fields. Link, Text and HTML fields cannot be empty if you do not need information for these fields you can enter 'N/A', then click [Add Requirement].."></asp:Label>
                                <br />
                                <asp:Label ID="Label110" runat="server" Text="Requirement Name should not be empty, and Requirement Name should not be greater than 300 characters."></asp:Label>

                        <br />
                            </th>
                        </tr>


                        <tr>
                            <th style="border: 1px solid black;" class="auto-style2">

                                <asp:Label ID="Label89" runat="server" Text="Available Requirement Types"></asp:Label>

                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label106" runat="server" Text="Requirement Name"></asp:Label>

                            </th>
                        </tr>

                        <tr>
                            <td style="border: 1px solid black;" class="auto-style2">
                                <asp:DropDownList ID="ddlRequirementTypes" runat="server" Width="250px">
                                </asp:DropDownList>

                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbNewRequirementName" runat="server" Height="50px" Width="700px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="border: 1px solid black;">
                                <asp:Label ID="lblRequirementNameMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>

                    </table>
                </div>
                <div class="classAddReqDescription" id="idAddReqDescription">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 320px;">
                        <tr>
                            <th colspan="3" style="border: 1px solid black;">
                                <asp:Label ID="Label2" runat="server" Text="Add Description for a new Requirement"></asp:Label></th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label90" runat="server" Text="Link for a new Requirement"></asp:Label>
                                <br />
                                <asp:Label ID="Label103" runat="server" Text="Link should not be empty."></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label91" runat="server" Text="Text for a new Requirement"></asp:Label>
                                <br />
                                <asp:Label ID="Label104" runat="server" Text="Text should not be empty."></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label92" runat="server" Text="HTML for a new Requirement"></asp:Label>
                                <br />
                                <asp:Label ID="Label105" runat="server" Text="HTML should not be empty."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbNewLink" runat="server" Height="150px" Width="320px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbNewText" runat="server" Height="150px" Width="320px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbNewHTML" runat="server" Height="150px" Width="320px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" class="auto-style1">
                                <asp:Label ID="lblLinkMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>
                            </td>
                            <td style="border: 1px solid black;" class="auto-style1">
                                <asp:Label ID="lblTextMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>
                            </td>
                            <td style="border: 1px solid black;" class="auto-style1">
                                <asp:Label ID="lblHTMLMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 25%; border: 1px solid black;">
                                <asp:Button ID="bAddRequirement" runat="server" Text="Add Requirement" OnClick="bAddRequirement_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="classUpdateReqName" id="idUpdateReqName">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 220px;">
                        <tr>
                            <th colspan="2" style="border: 1px solid black;">
                         <asp:Label ID="Label7" runat="server" Text="Update or Delete Requirement."></asp:Label>
                         <br />
                        <asp:Label ID="Label5" runat="server" Text="To Update [Requirement] you need to select [Requirement] in the [All Requirements], then enter name for selected Requirement in the [Update Requirement Field], then click [Update Requirement]."></asp:Label>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="To Update [Requirement Descriptions] you need to select [Requirement] in the [All Requirements], then enter Link, Text, or HTML in the appropriate Fields, then click [Update Requirement Descriptions]."></asp:Label>
                                <br />
                        <asp:Label ID="Label6" runat="server" Text="To Delete [Requirement] you need to select [Requirement] in the [All Requirements], then click [Delete Requirement]."></asp:Label><br />
                                <asp:Label ID="Label96" runat="server" Text="Requirement Name should not be empty, and Requirement Name should not be greater than 300 characters."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;" class="auto-style2">
                                <asp:Label ID="Label93" runat="server" Text="All Requirements"></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label95" runat="server" Text="Update Requirement"></asp:Label>

                                <br />

                                
                            </th>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black;" class="auto-style2">
                                <asp:DropDownList ID="ddlShowRequirements" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlShowRequirements_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbUpdateRequirementName" runat="server" Height="50px" Width="700px" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <asp:Button ID="bUpdateRequirementName" runat="server" Text="Update Requirement Name" OnClick="bUpdateRequirementName_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border: 1px solid black;">
                                <asp:Label ID="lblUpdateRequirementMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="classUpdateReqDescriptions" id="idUpdateReqDescriptions">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 280px;">
                        <tr>
                            <th colspan="3" style="border: 1px solid black;">



                                <asp:Label ID="Label100" runat="server" Text="Update Requirement Descriptions of selected Requirement."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label97" runat="server" Text="Link for a new Requirement"></asp:Label>
                                <br />
                                <asp:Label ID="Label107" runat="server" Text="Link should not be empty."></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label98" runat="server" Text="Text for a new Requirement"></asp:Label>
                                <br />
                                <asp:Label ID="Label108" runat="server" Text="Text should not be empty."></asp:Label>
                            </th>
                            <th style="border: 1px solid black;">
                                <asp:Label ID="Label99" runat="server" Text="HTML for a new Requirement"></asp:Label>
                                <br />
                                <asp:Label ID="Label109" runat="server" Text="HTML should not be empty."></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbUpdateLink" runat="server" Height="150px" Width="320px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbUpdateText" runat="server" Height="150px" Width="320px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:TextBox ID="txbUpdateHTML" runat="server" Height="150px" Width="320px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="border: 1px solid black;">
                                <asp:Button ID="bUpdateRequirementDescriptions" runat="server" Text="Update Requirement Descriptions" OnClick="bUpdateRequirementDescriptions_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="classDeleteReqName" id="idDeleteReqName">
                    <table style="width: 100%; text-align: center; border: 1px solid black; height: 110px;">
                        <tr>
                            <th style="border: 1px solid black;">

                                <asp:Label ID="Label101" runat="server" Text="Delete Selected Requirement"></asp:Label>

                            </th>
                        </tr>
                        <tr>
                            <td style="width: 25%; border: 1px solid black;">
                                <asp:Button ID="bDeleteRequirement" runat="server" Text="Delete Requirement" OnClick="bDeleteRequirement_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border: 1px solid black;">

                                <asp:Label ID="lblRequirementMessage" runat="server" Text="" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

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
