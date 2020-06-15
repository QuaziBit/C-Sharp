using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class origin : System.Web.UI.Page
{
    private MDOLEntities1 mdolEntities = new MDOLEntities1();
    private List<string> exceptionList = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadCountries();
            LoadStates();
            LoadCounties();
            LoadOriginItems();
        }
    }

    private void AddCountry()
    {
        try
        {
            string countryName = null;

            //Get text value from New Country Field if this Field is not null and not Empty
            if (txNewCountry.Value.ToString() != null && !txNewCountry.Value.ToString().Equals(""))
            {
                countryName = txNewCountry.Value.ToString();
            }

            if (countryName != null)
            {
                //Get all Countries from DB
                var countries = from c in mdolEntities.Countries
                                select c;

                //Add new Country and check if entered Country name exists in the Database
                int dCounter = 0;
                foreach (var c in countries)
                {
                    if (c.CountryName.ToLower().Equals(countryName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new Country record
                    Country countryTemp = new Country();
                    countryTemp.CountryName = countryName;
                    mdolEntities.Countries.Add(countryTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblCountryMessage.Text = countryName + ": already exists in the database";
                }
            }
            txNewCountry.Value = null;
            LoadCountries();
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: AddCountry()]";
            ExceptionsSaver(str);
        }
    }
    private void AddState()
    {
        try
        {
            string stateName = null;

            //Get text value from New State Field if this Field is not null and not Empty
            if (txNewState.Value.ToString() != null && !txNewState.Value.ToString().Equals(""))
            {
                stateName = txNewState.Value.ToString();
            }

            if (stateName != null)
            {
                //Get all States from DB
                var states = from s in mdolEntities.States
                             select s;

                //Add new State and check if entered State name exists in the Database
                int dCounter = 0;
                foreach (var s in states)
                {
                    if (s.StateName.ToLower().Equals(stateName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new State record
                    State stateTemp = new State();
                    stateTemp.StateName = stateName;
                    mdolEntities.States.Add(stateTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblStateMessage.Text = stateName + ": already exists in the database";
                }
            }
            txNewState.Value = null;
            LoadStates();
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: AddState()]";
            ExceptionsSaver(str);
        }
    }
    private void AddCounty()
    {
        try
        {
            string countyName = null;

            //Get text value from New County Field if this Field is not null and not Empty
            if (txNewCounty.Value.ToString() != null && !txNewCounty.Value.ToString().Equals(""))
            {
                countyName = txNewCounty.Value.ToString();
            }

            if (countyName != null)
            {
                //Get all County records from DB
                var counties = from c in mdolEntities.Counties
                               select c;

                //Add new County and check if entered County name exists in the Database
                int dCounter = 0;
                foreach (var c in counties)
                {
                    if (c.CountyName.ToLower().Equals(countyName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new County record
                    County countyTemp = new County();
                    countyTemp.CountyName = countyName;
                    mdolEntities.Counties.Add(countyTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblCountyMessage.Text = countyName + ": already exists in the database";
                }
            }
            txNewCounty.Value = null;
            LoadCounties();
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: AddCounty()]";
            ExceptionsSaver(str);
        }
    }
    private void AddOrigin()
    {
        try
        {
            //Temporary Objects
            Country countryTemp = null;
            State stateTemp = null;
            County countyTemp = null;

            //Get string values from Drop Down Lists and save them
            string countryName = ddlCountries.SelectedValue.ToString();
            string stateName = ddlStates.SelectedValue.ToString();
            string countyName = ddlCounties.SelectedValue.ToString();

            //Find Country, State and County in Database by name
            countryTemp = (from c in mdolEntities.Countries
                           where c.CountryName.ToLower().Equals(countryName.ToLower())
                           select c).FirstOrDefault();
            stateTemp = (from s in mdolEntities.States
                         where s.StateName.ToLower().Equals(stateName.ToLower())
                         select s).FirstOrDefault();
            countyTemp = (from c in mdolEntities.Counties
                          where c.CountyName.ToLower().Equals(countyName.ToLower())
                          select c).FirstOrDefault();

            //Get all Origins from DB
            var originD = from o in mdolEntities.Origins
                          select o;

            //Check if entered Origin exists in the Database
            int dCounter = 0;
            foreach (var o in originD)
            {
                if (o.CountryID == countryTemp.CountryID && o.StateID == stateTemp.StateID && o.CountyID == countyTemp.CountyID)
                {
                    dCounter++;
                }
            }
            if (dCounter == 0)
            {
                //Add new Origin record
                Origin originTemp = new Origin();
                originTemp.CountryID = countryTemp.CountryID;
                originTemp.StateID = stateTemp.StateID;
                originTemp.CountyID = countyTemp.CountyID;
                mdolEntities.Origins.Add(originTemp);
                mdolEntities.SaveChanges();
            }
            else
            {
                lblOriginMessage.Text = countryName + "; " + stateName + "; " + countyName + ": already exists in the database";
            }
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: AddOrigin()]";
            ExceptionsSaver(str);
        }
    }



    private void UpdateCountry()
    {
        try
        {
            //Temporary Object
            Country countryTemp = null;

            string selectedCountryName = Session["selectedCountryName"].ToString();

            //Get new Country Name from Drop Down List and save it
            string newCountryName = txNewCountryName.Value.ToString();

            //Find Country record in database by Country Name
            countryTemp = (from c in mdolEntities.Countries
                           where c.CountryName.ToLower().Equals(selectedCountryName.ToLower())
                           select c).FirstOrDefault();

            if (txNewCountryName.Value != null && !txNewCountryName.Value.Equals(""))
            {
                //Get all Countries from Database
                var countries = from c in mdolEntities.Countries
                                select c;

                //Check whether there is a similar "Country Name" in the database
                int dCounter = 0;
                foreach (var c in countries)
                {
                    if (c.CountryName.ToLower().Equals(newCountryName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Country record
                    countryTemp.CountryName = newCountryName;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblCountryMessage.Text = newCountryName + ": already exists in the database";
                }
            }
            txNewCountryName.Value = null;
            LoadCountries();
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: UpdateCountry()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateState()
    {
        try
        {
            //Temporary Object
            State stateTemp = null;

            //Get Selected State Name from Session
            string selectedStateName = Session["selectedStateName"].ToString();

            //Get new State Name from Drop Down List
            string newStateName = txNewStateName.Value.ToString();

            //Find State record in database by "State Name"
            stateTemp = (from s in mdolEntities.States
                         where s.StateName.ToLower().Equals(selectedStateName.ToLower())
                         select s).FirstOrDefault();

            if (txNewStateName.Value != null && !txNewStateName.Value.Equals(""))
            {
                //Get all States from DB
                var states = from s in mdolEntities.States
                             select s;

                //Check for duplicates
                //Check if entered State name exists in the Database
                int dCounter = 0;
                foreach (var s in states)
                {
                    if (s.StateName.ToLower().Equals(newStateName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Country record
                    stateTemp.StateName = newStateName;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblStateMessage.Text = newStateName + ": already exists in the database";
                }
            }
            txNewStateName.Value = null;
            LoadStates();
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: UpdateState()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateCounty()
    {
        try
        {
            //Temporary Object
            County countyTemp = null;

            //Get Selected County Name from Session
            string selectedCountyName = Session["selectedCountyName"].ToString();

            //Get new County Name from Drop Down List
            string newCountyName = txNewCountyName.Value.ToString();

            //Find County record in database by "County Name"
            countyTemp = (from c in mdolEntities.Counties
                          where c.CountyName.ToLower().Equals(selectedCountyName.ToLower())
                          select c).FirstOrDefault();

            if (txNewCountyName.Value != null && !txNewCountyName.Value.Equals(""))
            {
                //Get all Counties from Database
                var counties = from c in mdolEntities.Counties
                               select c;

                //Check if entered County Name exists in the Database
                int dCounter = 0;
                foreach (var c in counties)
                {
                    if (c.CountyName.ToLower().Equals(newCountyName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update County record
                    countyTemp.CountyName = newCountyName;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblCountyMessage.Text = newCountyName + ": already exists in the database";
                }
            }
            txNewCountyName.Value = null;
            LoadCounties();
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: UpdateCounty()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateOrigin()
    {
        try
        {
            //Get Origin object from Session
            Origin originTemp = (Origin)Session["originTemp"];

            //Find County, State and County based on what was selected in ddlShowOrigins
            Country countryTemp = null;
            State stateTemp = null;
            County countyTemp = null;

            //Get string values from Drop Down Lists and save them
            string countryName = ddlCountries.SelectedValue.ToString();
            string stateName = ddlStates.SelectedValue.ToString();
            string countyName = ddlCounties.SelectedValue.ToString();

            //Find in Database Country, State and County by name
            countryTemp = (from c in mdolEntities.Countries
                           where c.CountryName.ToLower().Equals(countryName.ToLower())
                           select c).FirstOrDefault();
            stateTemp = (from s in mdolEntities.States
                         where s.StateName.ToLower().Equals(stateName.ToLower())
                         select s).FirstOrDefault();
            countyTemp = (from c in mdolEntities.Counties
                          where c.CountyName.ToLower().Equals(countyName.ToLower())
                          select c).FirstOrDefault();

            //Get existing Origin Object from Database based on originTemp Object and update it
            Origin temp = null;
            temp = (from o in mdolEntities.Origins
                    where o.OriginID == originTemp.OriginID
                    select o).FirstOrDefault();


            //Get all Origins from Database
            var originD = from o in mdolEntities.Origins
                          select o;

            //Check if entered Origin exists in the Database
            int dCounter = 0;
            foreach (var o in originD)
            {
                if (o.CountryID == countryTemp.CountryID && o.StateID == stateTemp.StateID && o.CountyID == countyTemp.CountyID)
                {
                    dCounter++;
                }
            }
            if (dCounter == 0)
            {
                //Update Origin Record
                temp.OriginID = originTemp.OriginID;
                temp.CountryID = countryTemp.CountryID;
                temp.StateID = stateTemp.StateID;
                temp.CountyID = countyTemp.CountyID;
                mdolEntities.SaveChanges();
            }
            else
            {
                lblOriginMessage.Text = countryName + "; " + stateName + "; " + countyName + ": already exists in the database";
            }
            LoadOriginItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: UpdateOrigin()]";
            ExceptionsSaver(str);
        }
    }


    private void DeleteCountry()
    {
        //Teporary Object
        Country countryTemp = null;

        try
        {
            //Get Selected County Name from Session
            string selectedCountryName = Session["selectedCountryName"].ToString();

            //Find Country record in database by "Country Name"
            countryTemp = (from c in mdolEntities.Countries
                           where c.CountryName.ToLower().Equals(selectedCountryName.ToLower())
                           select c).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: DeleteCountry()]";
            ExceptionsSaver(str);
        }

        if (countryTemp != null)
        {
            try
            {
                //Delete Country Record
                mdolEntities.Countries.Remove(countryTemp);
                mdolEntities.SaveChanges();

                lblCountryMessage.Text = null;
                txNewCountryName.Value = null;

                LoadCountries();
                LoadOriginItems();
            }
            catch(Exception ex)
            {
                lblCountryMessage.Text = "This Country cannot be deleted because some records are connected to this Country.";
            }
        }
    }
    private void DeleteState()
    {
        //Teporary Object
        State stateTemp = null;

        try
        {
            //Get Selected State Name from Session
            string selectedStateName = Session["selectedStateName"].ToString();

            //Find State record in database by "State Name"
            stateTemp = (from s in mdolEntities.States
                         where s.StateName.ToLower().Equals(selectedStateName.ToLower())
                         select s).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: DeleteState()]";
            ExceptionsSaver(str);
        }

        if (stateTemp != null)
        {
            try
            {
                //Delete Country Record
                mdolEntities.States.Remove(stateTemp);
                mdolEntities.SaveChanges();

                lblStateMessage.Text = null;
                txNewStateName.Value = null;

                LoadStates();
                LoadOriginItems();
            }
            catch(Exception ex)
            {
                lblStateMessage.Text = "This State cannot be deleted because some records are connected to this State.";
            }
        }
    }
    private void DeleteCounty()
    {
        //Teporary Object
        County countyTemp = null;

        try
        {
            //Get Selected County Name from Session
            string selectedCountyName = Session["selectedCountyName"].ToString();

            //Find County record in database by "County Name"
            countyTemp = (from c in mdolEntities.Counties
                          where c.CountyName.ToLower().Equals(selectedCountyName.ToLower())
                          select c).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: DeleteCounty()]";
            ExceptionsSaver(str);
        }

        if (countyTemp != null)
        {
            try
            {
                //Delete County Record
                mdolEntities.Counties.Remove(countyTemp);
                mdolEntities.SaveChanges();

                lblCountyMessage.Text = null;
                txNewCountyName.Value = null;

                LoadCounties();
                LoadOriginItems();
            }
            catch (Exception ex)
            {
                lblCountyMessage.Text = "This County cannot be deleted because some records are connected to this County.";
            }
        }
    }
    private void DeleteOrigin()
    {
        Origin originTemp = null;
        Origin temp = null;
        try
        {
            //Get Origin Object from Session
            originTemp = (Origin)Session["originTemp"];

            //Get existing Origin Object from Database based on originTemp Object and update it
            temp = (from o in mdolEntities.Origins
                    where o.OriginID == originTemp.OriginID
                    select o).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: DeleteOrigin()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Delete Origin Record
            mdolEntities.Origins.Remove(temp);
            mdolEntities.SaveChanges();

            lblOriginMessage.Text = null;
            LoadOriginItems();
        }
        catch (Exception ex)
        {
            lblOriginMessage.Text = "This Origin cannot be deleted because some records are connected to this Origin.";
        }
    }


    //Methods LoadCountries, LoadStates, LoadCounties and LoadOriginItems are used to
    //===============================================================================//
    //load information into Drop Down Lists
    private void LoadCountries()
    {
        try
        {
            //lblCountryMessage.Text = null;

            //Get all Countries from Database
            var countries = from c in mdolEntities.Countries
                            select c;

            //Clear drop down list
            ddlShowCountries.Items.Clear();

            //Load Countries into drow down list
            foreach (var c in countries)
            {
                ddlShowCountries.Items.Add(c.CountryName);
            }

            //On Item selected from Drop Down List get Item value "Country Name"
            string selectedCountryName = ddlShowCountries.SelectedItem.Value.ToString();
            txNewCountryName.Value = selectedCountryName;

            //Save Selected Country Name in Session
            Session["selectedCountryName"] = selectedCountryName;
        }
        catch(Exception)
        {
            string str = "Exaption in the: {Origin Class}: [Method: LoadCountries()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadStates()
    {
        try
        {
            //lblStateMessage.Text = null;

            //Get all States from Database
            var states = from s in mdolEntities.States
                         select s;

            //Clear drop down list
            ddlShowStates.Items.Clear();

            //Load States into drow down list
            foreach (var s in states)
            {
                ddlShowStates.Items.Add(s.StateName);
            }

            //On Item selected from ListBox get Item value "State Name"
            string selectedStateName = ddlShowStates.SelectedItem.Value.ToString();
            txNewStateName.Value = selectedStateName;

            //Save Selected State Name in Session
            Session["selectedStateName"] = selectedStateName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: LoadStates()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadCounties()
    {
        try
        {
            //lblCountyMessage.Text = null;

            //Get all Counties from database
            var county = from c in mdolEntities.Counties
                         select c;

            //Clear drop down list
            ddlShowCounties.Items.Clear();

            //Load Counties into drow down list
            foreach (var c in county)
            {
                ddlShowCounties.Items.Add(c.CountyName);
            }

            //On Item selected from Drop Down List get Item value "County Name"
            string selectedCountyName = ddlShowCounties.SelectedItem.Value.ToString();
            txNewCountyName.Value = selectedCountyName.ToString();

            //Save Selected County Name in Session
            Session["selectedCountyName"] = selectedCountyName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: LoadCounties()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadOriginItems()
    {
        try
        {
            //lblOriginMessage.Text = null;

            string countryName = null;
            string stateName = null;
            string countyName = null;

            //Get from DB Countries, States and Counties
            var countries = from c in mdolEntities.Countries
                            select c;
            var states = from s in mdolEntities.States
                         select s;
            var counties = from c in mdolEntities.Counties
                           select c;

            //Clear Drop Down Lists
            ddlCountries.Items.Clear();
            ddlStates.Items.Clear();
            ddlCounties.Items.Clear();

            //Load Countries, State and Counties into drow down lists
            foreach (var c in countries)
            {
                ddlCountries.Items.Add(c.CountryName);
            }
            foreach (var s in states)
            {
                ddlStates.Items.Add(s.StateName);
            }
            foreach (var c in counties)
            {
                ddlCounties.Items.Add(c.CountyName);
            }

            //Clear Drop Down List
            ddlShowOrigins.Items.Clear();

            //Get all Origins from DB
            var origins = from o in mdolEntities.Origins
                          select o;

            //Load Origins into Drop Down List
            foreach (var o in origins)
            {
                ddlShowOrigins.Items.Add(o.Country.CountryName + "; " + o.State.StateName + "; " + o.County.CountyName);
            }

            //=========================================================================//
            //Get Selected Origin item from Drop Down List
            string selectedItem = ddlShowOrigins.SelectedItem.Value.ToString();

            //Split Selected Origin item into Country, State and County
            string originTemp = selectedItem;
            string[] originTempArray = originTemp.Split(';');
            for (int i = 0; i < originTempArray.Length; i++)
            {
                //Remove space
                char[] originSpace = { ' ' };
                string tmp = originTempArray[i].Trim(originSpace);
                originTempArray[i] = tmp;
            }

            //Save splitted values in countryName, stateName and countyName
            for (int i = 0; i < originTempArray.Length; i++)
            {
                if (i == 0)
                {
                    countryName = originTempArray[i];
                }
                if (i == 1)
                {
                    stateName = originTempArray[i];
                }
                if (i == 2)
                {
                    countyName = originTempArray[i];
                }
            }
            //=========================================================================//

            //Display Country, State and County in Drop Down Lists
            //based on what was selected in ddlShowOrigins
            ddlCountries.SelectedIndex = ddlCountries.Items.IndexOf(ddlCountries.Items.FindByValue(countryName));
            ddlStates.SelectedIndex = ddlStates.Items.IndexOf(ddlStates.Items.FindByValue(stateName));
            ddlCounties.SelectedIndex = ddlCounties.Items.IndexOf(ddlCounties.Items.FindByValue(countyName));

            //Find County, State and County based on what was selected in ddlShowOrigins
            Country countryTemp = null;
            State stateTemp = null;
            County countyTemp = null;

            //Get Country, State and County from DB by name
            countryTemp = (from c in mdolEntities.Countries
                           where c.CountryName.ToLower().Equals(countryName.ToLower())
                           select c).FirstOrDefault();
            stateTemp = (from s in mdolEntities.States
                         where s.StateName.ToLower().Equals(stateName.ToLower())
                         select s).FirstOrDefault();
            countyTemp = (from c in mdolEntities.Counties
                          where c.CountyName.ToLower().Equals(countyName.ToLower())
                          select c).FirstOrDefault();

            //Find Origin
            Origin originTem = null;
            originTem = (from o in mdolEntities.Origins
                         where o.CountryID == countryTemp.CountryID &&
                         o.StateID == stateTemp.StateID &&
                         o.CountyID == countyTemp.CountyID
                         select o).FirstOrDefault();

            //Save Origin in Session
            Session["originTemp"] = originTem;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: LoadOriginItems()]";
            ExceptionsSaver(str);
        }
    }

    //Webpage control elements

    //Origin Part
    //####################################################################################//
    //Add, Update, Delete Country
    //==========================================================================//
    protected void bAddCountry_Click(object sender, EventArgs e)
    {
        lblCountryMessage.Text = null;
        AddCountry();
    }
    protected void bUpdateCountry_Click(object sender, EventArgs e)
    {
        lblCountryMessage.Text = null;
        UpdateCountry();
    }
    protected void bDeleteCountry_Click(object sender, EventArgs e)
    {
        lblCountryMessage.Text = null;
        DeleteCountry();
    }
    protected void ddlShowCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblCountryMessage.Text = null;
            //On Item selected from Drop Down List get Item value "Country Name"
            string selectedCountryName = ddlShowCountries.SelectedItem.Value.ToString();
            txNewCountryName.Value = selectedCountryName;

            //Save selected Country Name in Session
            Session["selectedCountryName"] = selectedCountryName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: ddlShowCountries_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    //==========================================================================//


    //Add, Update, Delete State
    //==========================================================================//
    protected void bAddState_Click(object sender, EventArgs e)
    {
        lblStateMessage.Text = null;
        AddState();
    }
    protected void bUpdateState_Click(object sender, EventArgs e)
    {
        lblStateMessage.Text = null;
        UpdateState();
    }
    protected void bDeleteState_Click(object sender, EventArgs e)
    {
        lblStateMessage.Text = null;
        DeleteState();
    }
    protected void ddlShowStates_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblStateMessage.Text = null;

            //On Item selected from ListBox get Item value "State Name"
            string selectedStateName = ddlShowStates.SelectedItem.Value.ToString();
            txNewStateName.Value = selectedStateName;

            //Save selected State Name in Session
            Session["selectedStateName"] = selectedStateName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: ddlShowStates_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    //==========================================================================//


    //Add, Update, Delete County
    //==========================================================================//
    protected void bAddCounty_Click(object sender, EventArgs e)
    {
        lblCountyMessage.Text = null;
        AddCounty();
    }
    protected void bUpdateCounty_Click(object sender, EventArgs e)
    {
        lblCountyMessage.Text = null;
        UpdateCounty();
    }
    protected void bDeleteCounty_Click(object sender, EventArgs e)
    {
        lblCountyMessage.Text = null;
        DeleteCounty();
    }
    protected void ddlShowCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            lblCountyMessage.Text = null;
            //On Item selected from Drop Down List get Item value "County Name"
            string selectedCountyName = ddlShowCounties.SelectedItem.Value.ToString();
            txNewCountyName.Value = selectedCountyName.ToString();

            //Save selected County Name in Session
            Session["selectedCountyName"] = selectedCountyName;
        }
        catch(Exception ex)
        {

            string str = "Exaption in the: {Origin Class}: [Method: ddlShowCounties_SelectedIndexChanged1()]";
            ExceptionsSaver(str);
        }
    }
    //==========================================================================//


    //Add, Update, Delete Origin
    //==========================================================================//
    protected void bAddOrigin_Click(object sender, EventArgs e)
    {
        lblOriginMessage.Text = null;
        AddOrigin();
    }
    protected void ddlShowOrigins_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblOriginMessage.Text = null;

            string countryName = null;
            string stateName = null;
            string countyName = null;

            //Split Text from ddlShowOrigins
            //=====================================================================//
            string selectedItem = ddlShowOrigins.SelectedItem.Value.ToString();

            //Split selectedItem into Country, State and County
            string originTemp = selectedItem;
            string[] originTempArray = originTemp.Split(';');
            for (int i = 0; i < originTempArray.Length; i++)
            {
                //Remove space
                char[] originSpace = { ' ' };
                string tmp = originTempArray[i].Trim(originSpace);
                originTempArray[i] = tmp;
            }

            for (int i = 0; i < originTempArray.Length; i++)
            {
                if (i == 0)
                {
                    countryName = originTempArray[i];
                }
                if (i == 1)
                {
                    stateName = originTempArray[i];
                }
                if (i == 2)
                {
                    countyName = originTempArray[i];
                }
            }
            //=====================================================================//

            //Display Country, State and County in Drop Down Lists
            //based on what was selected in ddlShowOrigins
            ddlCountries.SelectedIndex = ddlCountries.Items.IndexOf(ddlCountries.Items.FindByValue(countryName));
            ddlStates.SelectedIndex = ddlStates.Items.IndexOf(ddlStates.Items.FindByValue(stateName));
            ddlCounties.SelectedIndex = ddlCounties.Items.IndexOf(ddlCounties.Items.FindByValue(countyName));

            //Find County, State and County based on what was selected in ddlShowOrigins
            Country countryTemp = null;
            State stateTemp = null;
            County countyTemp = null;

            //Get County, State and County from DB by name
            countryTemp = (from c in mdolEntities.Countries
                           where c.CountryName.ToLower().Equals(countryName.ToLower())
                           select c).FirstOrDefault();
            stateTemp = (from s in mdolEntities.States
                         where s.StateName.ToLower().Equals(stateName.ToLower())
                         select s).FirstOrDefault();
            countyTemp = (from c in mdolEntities.Counties
                          where c.CountyName.ToLower().Equals(countyName.ToLower())
                          select c).FirstOrDefault();

            //Find Origin
            Origin originTem = null;
            originTem = (from o in mdolEntities.Origins
                         where o.CountryID == countryTemp.CountryID &&
                         o.StateID == stateTemp.StateID &&
                         o.CountyID == countyTemp.CountyID
                         select o).FirstOrDefault();

            //Save Origin in Session
            Session["originTemp"] = originTem;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: ddlShowOrigins_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateOrigin_Click(object sender, EventArgs e)
    {
        lblOriginMessage.Text = null;
        UpdateOrigin();
    }
    protected void bDeleteOrigin_Click(object sender, EventArgs e)
    {
        lblOriginMessage.Text = null;
        DeleteOrigin();
    }

    //If some Exception occurs this method will be called, an Exception will be 
    //added into List after, this List will be saved in the Session.
    //In addition, all Exception will be displayed in the Drop Down Box
    private void ExceptionsSaver(string str)
    {
        if (Session["OriginExceptionList"] != null)
        {
            exceptionList = (List<string>)Session["OriginExceptionList"];
            exceptionList.Add(str);

            exceptionsTable.Visible = true;

            lbExceptions.Items.Clear();
            foreach (string s in exceptionList)
            {
                lbExceptions.Items.Add(s);
            }

            Session["OriginExceptionList"] = exceptionList;
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

            Session["OriginExceptionList"] = exceptionList;
        }
    }
    //==========================================================================//
    //####################################################################################//
}