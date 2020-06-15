using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class requirements : System.Web.UI.Page
{
    private MDOLEntities1 mdolEntities = new MDOLEntities1();
    private List<string> exceptionList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRequirementTypes();
            LoadRequirements();
        }
    }

    private void AddRequirementType()
    {
        try
        {
            string requirementType = null;

            //Get text value from New Requirement Type Name Field if this Field is not null and not Empty
            if (txNewRequirementType.Value.ToString() != null && !txNewRequirementType.Value.ToString().Equals(""))
            {
                requirementType = txNewRequirementType.Value.ToString();
            }

            if (requirementType != null)
            {
                //Get all Requirement Types from DB
                var requirementTypes = from r in mdolEntities.RequirementTypes
                                       select r;

                //Check if entered Requirement Type is exists in the Database
                int dCounter = 0;
                foreach (var r in requirementTypes)
                {
                    if (r.Type.ToLower().Equals(requirementType.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {

                    //Add new Requirement Type
                    RequirementType requirementTypeTemp = new RequirementType();
                    requirementTypeTemp.Type = requirementType;
                    mdolEntities.RequirementTypes.Add(requirementTypeTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    //Show message that this record cannot be added
                    lblRequirementTypeMessage.Text = requirementType + ": already exists in the database";
                }
            }
            txNewRequirementType.Value = null;
            LoadRequirementTypes();
            LoadRequirements();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: AddRequirementType()]";
            ExceptionsSaver(str);
        }
    }
    private void AddRequirement()
    {
        try
        {
            string requirementType = null;

            if (ddlRequirementTypes.SelectedValue.ToString() != null && !ddlRequirementTypes.SelectedValue.ToString().Equals(""))
            {
                //Get selected Requirement Type from Drop Down List
                requirementType = ddlRequirementTypes.SelectedValue.ToString();
            }

            //Find Requirement Type in the Database
            RequirementType requirementTypeTemp = (from r in mdolEntities.RequirementTypes
                                                   where r.Type.ToLower().Equals(requirementType.ToLower())
                                                   select r).FirstOrDefault();

            string requirementName = null;

            //Get text value from New Requirement Name Field if this Field is not null and not Empty.
            //If Requirement Name is empty, assign default Requirement Name
            if (txbNewRequirementName.Text != null && !txbNewRequirementName.Text.Equals(""))
            {
                requirementName = txbNewRequirementName.Text;
                lblRequirementNameMessage.Text = null;
            }
            else
            {
                requirementName = "Undefined Requirement";
                lblRequirementNameMessage.Text = "You have to enter name fo new Requirement. New Requirement Name will be created by default";
            }

            //Get Text values from Text Areas for link, Text and HTML
            string link = null;
            if (txbNewLink.Text != null && !txbNewLink.Text.Equals(""))
            {
                link = txbNewLink.Text;
                lblLinkMessage.Text = null;
            }
            else
            {
                link = "N/A";
                lblLinkMessage.Text = "You have to enter Link. New Link will be created by default";
            }

            string text = null;
            if (txbNewText.Text != null && !txbNewText.Text.Equals(""))
            {
                text = txbNewText.Text;
                lblTextMessage.Text = null;
            }
            else
            {
                text = "N/A";
                lblTextMessage.Text = "You have to enter Text. New Text will be created by default";
            }

            string html = null;
            if (txbNewHTML.Text != null && !txbNewHTML.Text.Equals(""))
            {
                html = txbNewHTML.Text;
                lblHTMLMessage.Text = null;
            }
            else
            {
                html = "N/A";
                lblHTMLMessage.Text = "You have to enter HTML. New HTML will be created by default";
            }


            if (requirementTypeTemp != null)
            {
                //Get all Requirements
                var requirements = from r in mdolEntities.Requirements
                                   select r;

                //Check if entered Requirement is not in the Database
                int dCounter = 0;
                foreach (var r in requirements)
                {
                    if (r.Name.ToLower().Equals(requirementName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new Requirement
                    Requirement requirementTemp = new Requirement();
                    requirementTemp.ReqType_ID = requirementTypeTemp.ReqType_ID;
                    requirementTemp.Name = requirementName;
                    requirementTemp.Link = link;
                    requirementTemp.Text = text;
                    requirementTemp.HTML = html;
                    mdolEntities.Requirements.Add(requirementTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    //Show message that this record cannot be added
                    lblRequirementNameMessage.Text = requirementName + ": already exists in the database";
                }
            }
            txbNewRequirementName.Text = null;
            txbNewLink.Text = null;
            txbNewText.Text = null;
            txbNewHTML.Text = null;
            LoadRequirementTypes();
            LoadRequirements();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: AddRequirement()]";
            ExceptionsSaver(str);
        }
    }

    private void UpdateRequirementType()
    {
        RequirementType requirementTypeTemp = null;
        string selectedRequirementType = null;
        try
        {
            selectedRequirementType = Session["selectedRequirementType"].ToString();
        }
        catch(Exception ex)
        {
            string str = "[1] Exaption in the: {Requirements Class}: [Method: UpdateRequirementType()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Get new name of Requirement Type and save it
            string updateRequirementType = txUpdateRequirementType.Value.ToString();

            //Find Requirement Type record in database by Age Range
            requirementTypeTemp = (from r in mdolEntities.RequirementTypes
                                   where r.Type.ToLower().Equals(selectedRequirementType.ToLower())
                                   select r).FirstOrDefault();

            if (txUpdateRequirementType.Value != null && !txUpdateRequirementType.Value.Equals(""))
            {
                //Get all Requirement Type records
                var requirementTypes = from r in mdolEntities.RequirementTypes
                                       select r;

                //Check whether there is a Requirement Type in the database
                int dCounter = 0;
                foreach (var r in requirementTypes)
                {
                    if (r.Type.ToLower().Equals(updateRequirementType.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Requirement Type record
                    requirementTypeTemp.Type = updateRequirementType;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    //Show message that this record cannot be added
                    lblRequirementTypeMessage.Text = requirementTypeTemp.Type + ": already exists in the database";
                }
            }
            txUpdateRequirementType.Value = null;
            LoadRequirementTypes();
            LoadRequirements();
        }
        catch(Exception ex)
        {
            string str = "[2] Exaption in the: {Requirements Class}: [Method: UpdateRequirementType()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateRequirementName()
    {
        Requirement requirementObjTemp = null;
        Requirement requirementTemp = null;

        try
        {
            requirementObjTemp = (Requirement)Session["requirementObjTemp"];

            //This Requirement will be updated
            requirementTemp = (from r in mdolEntities.Requirements
                               where r.RequirementID == requirementObjTemp.RequirementID
                               select r).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "[1] Exaption in the: {Requirements Class}: [Method: UpdateRequirementName()]";
            ExceptionsSaver(str);
        }

        try
        {
            string requirementType = null;
            if (ddlRequirementTypes.SelectedValue.ToString() != null && !ddlRequirementTypes.SelectedValue.ToString().Equals(""))
            {
                //Get selected Requirement Type from Drop Down List
                requirementType = ddlRequirementTypes.SelectedValue.ToString();
            }

            //Find Requirement Type in the Database
            RequirementType requirementTypeTemp = (from r in mdolEntities.RequirementTypes
                                                   where r.Type.ToLower().Equals(requirementType.ToLower())
                                                   select r).FirstOrDefault();

            //Get new Requirement Name, Linq, Text and HTML
            string requirementName = null;
            if (txbUpdateRequirementName.Text != null && !txbUpdateRequirementName.Text.Equals(""))
            {
                requirementName = txbUpdateRequirementName.Text;
            }

            if (requirementTemp != null && requirementTypeTemp != null && requirementName != null && !requirementName.Equals(""))
            {
                //Get all Requirements
                var requirements = from r in mdolEntities.Requirements
                                   select r;

                //Check if entered Requirement is not in the Database
                int dCounter = 0;
                foreach (var r in requirements)
                {
                    if (r.Name.ToLower().Equals(requirementName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Requirement
                    requirementTemp.ReqType_ID = requirementTypeTemp.ReqType_ID;
                    requirementTemp.Name = requirementName;

                    Session["requirementObjTemp"] = requirementTemp;

                    mdolEntities.SaveChanges();
                }
                else
                {
                    //Show message that this record cannot be added
                    lblUpdateRequirementMessage.Text = requirementName + ": already exists in the database";
                }
            }
            txbUpdateRequirementName.Text = null;
            txbUpdateLink.Text = null;
            txbUpdateText.Text = null;
            txbUpdateHTML.Text = null;
            LoadRequirementTypes();
            LoadRequirements();
        }
        catch(Exception ex)
        {
            string str = "[2] Exaption in the: {Requirements Class}: [Method: UpdateRequirementName()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateRequirementDescriptions()
    {
        Requirement requirementObjTemp = null;
        Requirement requirementTemp = null;
        try
        {
            requirementObjTemp = (Requirement)Session["requirementObjTemp"];

            //This Requirement will be updated
            requirementTemp = (from r in mdolEntities.Requirements
                               where r.RequirementID == requirementObjTemp.RequirementID
                               select r).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "[1] Exaption in the: {Requirements Class}: [Method: UpdateRequirementDescriptions()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Get new Linq, Text and HTML values from Text Areas
            string link = null;
            if (txbUpdateLink.Text != null && !txbUpdateLink.Text.Equals(""))
            {
                link = txbUpdateLink.Text;
            }

            string text = null;
            if (txbUpdateText.Text != null && !txbUpdateText.Text.Equals(""))
            {
                text = txbUpdateText.Text;
            }

            string html = null;
            if (txbUpdateHTML.Text != null && !txbUpdateHTML.Text.Equals(""))
            {
                html = txbUpdateHTML.Text;
            }


            if (requirementTemp != null && link != null && !link.Equals("") && text != null && !text.Equals("") && html != null && !html.Equals(""))
            {
                requirementTemp.Link = link;
                requirementTemp.Text = text;
                requirementTemp.HTML = html;
                mdolEntities.SaveChanges();
            }

            txbUpdateRequirementName.Text = null;
            txbUpdateLink.Text = null;
            txbUpdateText.Text = null;
            txbUpdateHTML.Text = null;
            LoadRequirementTypes();
            LoadRequirements();
        }
        catch(Exception ex)
        {
            string str = "[2] Exaption in the: {Requirements Class}: [Method: UpdateRequirementDescriptions()]";
            ExceptionsSaver(str);
        }
    }


    private void DeleteRequirementType()
    {
        RequirementType requirementTypeTemp = null;

        try
        {
            string selectedRequirementType = Session["selectedRequirementType"].ToString();

            //Find Requirement Type record in database by Age Range
            requirementTypeTemp = (from r in mdolEntities.RequirementTypes
                                   where r.Type.ToLower().Equals(selectedRequirementType.ToLower())
                                   select r).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: DeleteRequirementType()]";
            ExceptionsSaver(str);
        }

        if (requirementTypeTemp != null)
        {
            try
            {
                //Delete Requirement Type record
                mdolEntities.RequirementTypes.Remove(requirementTypeTemp);
                mdolEntities.SaveChanges();

                lblRequirementTypeMessage.Text = null;
                txNewRequirementType.Value = null;
                txUpdateRequirementType.Value = null;

                LoadRequirementTypes();
                LoadRequirements();
            }
            catch(Exception ex)
            {
                lblRequirementTypeMessage.Text = "This Requirement Type cannot be deleted because some records are connected to this Requirement Type.";
            }
        }
    }
    private void DeleteRequirement()
    {
        Requirement requirementObjTemp = null;
        Requirement requirementTemp = null;

        try
        {
            requirementObjTemp = (Requirement)Session["requirementObjTemp"];

            //This Requirement will be updated
            requirementTemp = (from r in mdolEntities.Requirements
                                           where r.RequirementID == requirementObjTemp.RequirementID
                                           select r).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: DeleteRequirement()]";
            ExceptionsSaver(str);
        }

        if (requirementTemp != null)
        {
            try
            {
                //Delete Requirement
                mdolEntities.Requirements.Remove(requirementTemp);
                mdolEntities.SaveChanges();

                lblRequirementMessage.Text = null;
                txbUpdateRequirementName.Text = null;
                txbUpdateLink.Text = null;
                txbUpdateText.Text = null;
                txbUpdateHTML.Text = null;

                Session["requirementObjTemp"] = null;

                LoadRequirementTypes();
                LoadRequirements();
            }
            catch(Exception ex)
            {
                lblRequirementMessage.Text = "This Requirement cannot be deleted because some records are connected to this Requirement.";
            }
        }
    }


    //Load all Requirement Types, Requirements
    private void LoadRequirementTypes()
    {
        try
        {
            //lblRequirementTypeMessage.Text = null;

            var requirementTypes = from r in mdolEntities.RequirementTypes
                                   select r;

            ddlShowRequirementTypes.Items.Clear();
            foreach (var r in requirementTypes)
            {
                ddlShowRequirementTypes.Items.Add(r.Type);
            }

            //On Item selected from Drop Down List get Item value "Requirement Type"
            string selectedRequirementType = ddlShowRequirementTypes.SelectedItem.Value.ToString();
            txUpdateRequirementType.Value = selectedRequirementType;

            Session["selectedRequirementType"] = selectedRequirementType;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: LoadRequirementTypes()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadRequirements()
    {
        Requirement temp = null;
        try
        {
            temp = (Requirement)Session["requirementObjTemp"];
        }
        catch (Exception ex)
        {
            string str = "[1] Exaption in the: {Requirements Class}: [Method: LoadRequirements()]";
            ExceptionsSaver(str);
        }

        try
        {
            //lblRequirementMessage.Text = null;
            //lblUpdateRequirementMessage.Text = null;

            //Load Requirement Type
            //Get all Requirement Types
            var RequirementTypes = from r in mdolEntities.RequirementTypes
                                   select r;

            //Load Requirement Types into Drop Down List
            ddlRequirementTypes.Items.Clear();
            foreach (var rt in RequirementTypes)
            {
                ddlRequirementTypes.Items.Add(rt.Type);
            }

            //Load Requirements
            //Get all Requirements
            var requirements = from r in mdolEntities.Requirements
                               select r;

            //Load Requirements into Drop Down List
            ddlShowRequirements.Items.Clear();
            foreach (var r in requirements)
            {
                ddlShowRequirements.Items.Add(r.Name);
            }

            
            string selectedRequirementName = null;
            if (temp == null)
            {
                //On Item selected from Drop Down List get Item value "Requirement Name"
                selectedRequirementName = ddlShowRequirements.SelectedItem.Value.ToString();
            }
            else
            {
                selectedRequirementName = temp.Name;
            }

            //Find Requirement record by its Name
            Requirement requirementObjTemp = (from r in mdolEntities.Requirements
                                              where r.Name.ToLower().Equals(selectedRequirementName.ToLower())
                                              select r).FirstOrDefault();

            //Display Requirement Name, Linq, Text and HTML data on the web page
            txbUpdateRequirementName.Text = requirementObjTemp.Name;
            txbUpdateLink.Text = requirementObjTemp.Link;
            txbUpdateText.Text = requirementObjTemp.Text;
            txbUpdateHTML.Text = requirementObjTemp.HTML;

            //Display Requirement Type in Drop Down List
            //based on what was selected in ddlShowRequirements
            ddlShowRequirements.SelectedIndex = ddlShowRequirements.Items.IndexOf(ddlShowRequirements.Items.FindByValue(selectedRequirementName));
            ddlRequirementTypes.SelectedIndex = ddlRequirementTypes.Items.IndexOf(ddlRequirementTypes.Items.FindByValue(requirementObjTemp.RequirementType.Type));

            //Save it in the session
            Session["requirementObjTemp"] = requirementObjTemp;
        }
        catch(Exception ex)
        {
            string str = "[2] Exaption in the: {Requirements Class}: [Method: LoadRequirements()]";
            ExceptionsSaver(str);
        }
    }




    //Requirements Part
    //####################################################################################//
    //Add, Update, Delete Requirement Type
    //==========================================================================//
    protected void bAddRequirementType_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        AddRequirementType();
    }
    protected void ddlShowRequirementTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RefreshLabels();

            //On Item selected from Drop Down List get Item value "Requirement Type"
            string selectedRequirementType = ddlShowRequirementTypes.SelectedItem.Value.ToString();
            txUpdateRequirementType.Value = selectedRequirementType;

            Session["selectedRequirementType"] = selectedRequirementType;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: ddlShowRequirementTypes_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateRequirementType_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        UpdateRequirementType();
    }
    protected void bDeleteRequirementType_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        DeleteRequirementType();
    }
    //==========================================================================//

    //Add, Update, Delete Requirements
    //==========================================================================//
    protected void bAddRequirement_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        AddRequirement();
    }
    protected void ddlShowRequirements_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RefreshLabels();

            //On Item selected from Drop Down List get Item value "Requirement Name"
            string selectedRequirementName = ddlShowRequirements.SelectedItem.Value.ToString();

            //Find Requirement record by its Name
            Requirement requirementObjTemp = (from r in mdolEntities.Requirements
                                              where r.Name.ToLower().Equals(selectedRequirementName.ToLower())
                                              select r).FirstOrDefault();

            //Display Requirement Name, Linq, Text and HTML data on the web page
            txbUpdateRequirementName.Text = requirementObjTemp.Name;
            txbUpdateLink.Text = requirementObjTemp.Link;
            txbUpdateText.Text = requirementObjTemp.Text;
            txbUpdateHTML.Text = requirementObjTemp.HTML;

            //Display Requirement Type in Drop Down Lists
            //based on what was selected in ddlShowRequirements
            ddlRequirementTypes.SelectedIndex = ddlRequirementTypes.Items.IndexOf(ddlRequirementTypes.Items.FindByValue(requirementObjTemp.RequirementType.Type));

            //Save it in the session
            Session["requirementObjTemp"] = requirementObjTemp;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Requirements Class}: [Method: ddlShowRequirements_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateRequirementName_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        UpdateRequirementName();
    }
    protected void bUpdateRequirementDescriptions_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        UpdateRequirementDescriptions();
    }
    protected void bDeleteRequirement_Click(object sender, EventArgs e)
    {
        RefreshLabels();
        DeleteRequirement();
    }

    protected void RefreshLabels()
    {
        lblRequirementTypeMessage.Text = null;
        lblRequirementMessage.Text = null;
        lblUpdateRequirementMessage.Text = null;
        lblLinkMessage.Text = null;
        lblTextMessage.Text = null;
        lblHTMLMessage.Text = null;
    }

    //If some Exception occurs this method will be called, an Exception will be 
    //added into List after, this List will be saved in the Session.
    //In addition, all Exception will be displayed in the Drop Down Box
    private void ExceptionsSaver(string str)
    {
        if (Session["RequirementsExceptionList"] != null)
        {
            exceptionList = (List<string>)Session["RequirementsExceptionList"];
            exceptionList.Add(str);

            exceptionsTable.Visible = true;

            lbExceptions.Items.Clear();
            foreach (string s in exceptionList)
            {
                lbExceptions.Items.Add(s);
            }

            Session["RequirementsExceptionList"] = exceptionList;
        }

        if (exceptionList == null)
        {
            exceptionList = new List<string>();
            exceptionList.Add(str);

            exceptionsTable.Visible = true;

            lbExceptions.Items.Clear();
            foreach (string s in exceptionList)
            {
                lbExceptions.Items.Add(s);
            }

            Session["RequirementsExceptionList"] = exceptionList;
        }
    }
    //==========================================================================//
    //####################################################################################/
}