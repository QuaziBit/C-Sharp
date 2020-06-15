using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDemo : System.Web.UI.Page
{
    MDOLEntities1 mdolEntities = new MDOLEntities1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSpecies();
            LoadOrigins();

            ShowInfo();
        }
    }

    //Load Species
    protected void LoadSpecies()
    {
        try
        {
            //Add Species into ddlSpecies List
            var species = from s in mdolEntities.Species
                          select s;
            foreach (var s in species)
            {
                ddlSpecies.Items.Add(s.SpeciesName);
            }

            //Get Selected Species by default from ddlSpecies
            string selectedSpecies = ddlSpecies.SelectedValue.ToString();

            Session["selectedSpecies"] = selectedSpecies;
        }
        catch(Exception ex)
        {

        }
    }

    //Origin Part
    //====================================================================//
    protected void LoadOrigins()
    {
        LoadCountries();
        LoadStates();
        LoadCounties();

        LoadTypes();
        LoadGenders();
        LoadAge();
    }

    protected void LoadCountries()
    {
        try
        {
            string selectedSpecies = null;

            //Get previously selected Specie
            selectedSpecies = Session["selectedSpecies"].ToString();

            //If Specie is null all Countries will be loaded into Drop Down List,
            //else only Countries that connected to the selected Specie
            //will be loaded
            if (selectedSpecies == null)
            {
                //Add Countries into ddlState
                var countries = from c in mdolEntities.Countries
                                select c;
                ddlCountry.Items.Clear();
                foreach (var c in countries)
                {
                    ddlCountry.Items.Add(c.CountryName);
                }
            }
            else
            {
                //Get Countries based on what Specie was selected
                var countries = from a in mdolEntities.Animals
                                where a.Species.SpeciesName.ToLower().Equals(selectedSpecies.ToLower())
                                select a.Origin.Country;
                HashSet<Country> countriesTemp = new HashSet<Country>();
                foreach (var c in countries)
                {
                    countriesTemp.Add(c);
                }
                //Add Countries into ddlCountry
                ddlCountry.Items.Clear();
                foreach (Country c in countriesTemp)
                {
                    ddlCountry.Items.Add(c.CountryName);
                }
            }

            string selectedCountry = ddlCountry.SelectedValue.ToString();

            //Save selected Country into Session
            Session["selectedCountry"] = selectedCountry;
        }
        catch(Exception ex)
        {

        }
    }
    protected void LoadStates()
    {
        try
        {
            string selectedSpecies = null;
            string selectedCountry = null;

            //Get previously selected Specie and Country from Session
            selectedSpecies = Session["selectedSpecies"].ToString();
            selectedCountry = Session["selectedCountry"].ToString();

            //If Specie and Country is null all States will be loaded into Drop Down List, 
            //else only States that connected to the selected Specie and Country 
            //will be loaded
            if (selectedSpecies == null && selectedCountry == null)
            {
                //Add States into ddlState
                var states = from s in mdolEntities.States
                             select s;
                ddlState.Items.Clear();
                foreach (var s in states)
                {
                    ddlState.Items.Add(s.StateName);
                }
            }
            else
            {
                //Get States based on what Specie and Country was selected
                var states = from a in mdolEntities.Animals
                             where a.Species.SpeciesName.ToLower().Equals(selectedSpecies.ToLower()) &&
                             a.Origin.Country.CountryName.ToLower().Equals(selectedCountry.ToLower())
                             select a.Origin.State;
                HashSet<State> statesTemp = new HashSet<State>();
                foreach (var s in states)
                {
                    statesTemp.Add(s);
                }
                //Add States into ddlState
                ddlState.Items.Clear();
                foreach (State s in statesTemp)
                {
                    ddlState.Items.Add(s.StateName);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void LoadCounties()
    {
        try
        {
            string selectedSpecies = null;
            string selectedCountry = null;

            //Get previously selected Specie and Country from Session
            selectedSpecies = Session["selectedSpecies"].ToString();
            selectedCountry = Session["selectedCountry"].ToString();

            //If Specie and Country is null all Counties will be loaded into Drop Down List, 
            //else only Countries that connected to the selected Specie and Country 
            //will be loaded
            if (selectedSpecies == null && selectedCountry == null)
            {
                //Add Counties into ddlCounty
                var counties = from c in mdolEntities.Counties
                               select c;
                ddlCounty.Items.Clear();
                foreach (var c in counties)
                {
                    ddlCounty.Items.Add(c.CountyName);
                }
            }
            else
            {
                //Get Counties based on what Specie and Country was selected
                var counties = from a in mdolEntities.Animals
                               where a.Species.SpeciesName.ToLower().Equals(selectedSpecies.ToLower()) &&
                               a.Origin.Country.CountryName.ToLower().Equals(selectedCountry.ToLower())
                               select a.Origin.County;
                HashSet<County> countiesTemp = new HashSet<County>();
                foreach (var c in counties)
                {
                    countiesTemp.Add(c);
                }

                //Add Counties into ddlCounty
                ddlCounty.Items.Clear();
                foreach (County c in countiesTemp)
                {
                    ddlCounty.Items.Add(c.CountyName);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    //====================================================================//



    //Animal Part
    //#####################################################################//
    protected void LoadTypes()
    {
        try
        {
            string selectedSpecies = null;
            string selectedCountry = null;

            //Get previously selected Specie and Country from Session
            selectedSpecies = Session["selectedSpecies"].ToString();
            selectedCountry = Session["selectedCountry"].ToString();

            //If Specie and Country is null all Types will be loaded into Drop Down List, 
            //else only Types that connected to the selected Specie and Country 
            //will be loaded
            if (selectedSpecies == null && selectedCountry == null)
            {
                //Add Types into ddlType
                var types = from t in mdolEntities.Types
                            select t;
                ddlType.Items.Clear();
                foreach (var t in types)
                {
                    ddlType.Items.Add(t.TypeName);
                }
            }
            else
            {
                //Get Types based on what Specie and Country was selected
                var types = from a in mdolEntities.Animals
                            where a.Species.SpeciesName.ToLower().Equals(selectedSpecies.ToLower()) &&
                            a.Origin.Country.CountryName.ToLower().Equals(selectedCountry.ToLower())
                            select a.Type;
                HashSet<Type> typesTemp = new HashSet<Type>();
                foreach (var t in types)
                {
                    typesTemp.Add(t);
                }
                //Add Types into ddlType
                ddlType.Items.Clear();
                foreach (Type t in typesTemp)
                {
                    ddlType.Items.Add(t.TypeName);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void LoadGenders()
    {
        try
        {
            string selectedSpecies = null;
            string selectedCountry = null;

            //Get previously selected Specie and Country from Session
            selectedSpecies = Session["selectedSpecies"].ToString();
            selectedCountry = Session["selectedCountry"].ToString();

            //If Specie and Country is null all Genders will be loaded into Drop Down List, 
            //else only Genders that connected to the selected Specie and Country 
            //will be loaded
            if (selectedSpecies == null && selectedCountry == null)
            {
                //Add Gender into ddlGender
                var gender = from g in mdolEntities.Genders
                             select g;
                ddlGender.Items.Clear();
                foreach (var g in gender)
                {
                    ddlGender.Items.Add(g.GenderName);
                }
            }
            else
            {
                //Get Genders based on what Specie and Country was selected
                var gender = from a in mdolEntities.Animals
                             where a.Species.SpeciesName.ToLower().Equals(selectedSpecies.ToLower()) &&
                             a.Origin.Country.CountryName.ToLower().Equals(selectedCountry.ToLower())
                             select a.Gender;
                HashSet<Gender> genderTemp = new HashSet<Gender>();
                foreach (var g in gender)
                {
                    genderTemp.Add(g);
                }
                //Add Gender into ddlGender
                ddlGender.Items.Clear();
                foreach (Gender g in genderTemp)
                {
                    ddlGender.Items.Add(g.GenderName);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void LoadAge()
    {
        try
        {
            string selectedSpecies = null;
            string selectedCountry = null;
            selectedSpecies = Session["selectedSpecies"].ToString();
            selectedCountry = Session["selectedCountry"].ToString();

            //If Specie and Country is null all Ages will be loaded into Drop Down List, 
            //else only Ages that connected to the selected Specie and Country 
            //will be loaded
            if (selectedSpecies == null && selectedCountry == null)
            {
                //Add Age into ddlAge
                var age = from a in mdolEntities.Ages
                          orderby a.AgeRange
                          select a;
                ddlAge.Items.Clear();
                foreach (var a in age)
                {
                    ddlAge.Items.Add(a.AgeRange);
                }
            }
            else
            {
                //Get Ages based on what Specie and Country was selected
                var age = from a in mdolEntities.Animals
                          where a.Species.SpeciesName.ToLower().Equals(selectedSpecies.ToLower()) &&
                          a.Origin.Country.CountryName.ToLower().Equals(selectedCountry.ToLower())
                          orderby a.Age.AgeRange
                          select a.Age;
                HashSet<Age> ageTemp = new HashSet<Age>();
                foreach (var a in age)
                {
                    ageTemp.Add(a);
                }
                //Add Age into ddlAge
                ddlAge.Items.Clear();
                foreach (Age a in ageTemp)
                {
                    ddlAge.Items.Add(a.AgeRange);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    //#####################################################################//

    protected void ddlSpecies_SelectedIndexChanged(object sender, EventArgs e)
    {
        animlaContent.InnerHtml = "";

        //Get Selected Specie by default from ddlSpecies
        string selectedSpecies = ddlSpecies.SelectedValue.ToString();

        Session["selectedSpecies"] = selectedSpecies;

        LoadOrigins();

        ShowInfo();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        animlaContent.InnerHtml = "";

        //Get Selected Country by default from ddlSpecies
        string selectedCountry = ddlCountry.SelectedValue.ToString();

        Session["selectedCountry"] = selectedCountry;

        LoadStates();
        LoadCounties();

        LoadTypes();
        LoadGenders();
        LoadAge();

        ShowInfo();
    }

    protected void ShowInfo()
    {
        string str = null;

        string species = null;

        string country = null;
        string state = null;
        string county = null;

        string type = null;
        string gender = null;
        string age = null;

        Origin originTemp = null;
        try
        {
            //Get Country, State and County from Drop Down Lists
            country = ddlCountry.SelectedValue.ToString();
            state = ddlState.SelectedItem.ToString();
            county = ddlCounty.SelectedItem.ToString();

            //Find requirements based on the choosing data
            originTemp = (from o in mdolEntities.Origins
                          where o.Country.CountryName.Equals(country)
                          && o.State.StateName.Equals(state)
                          && o.County.CountyName.Equals(county)
                          select o).FirstOrDefault();
        }
        catch(Exception ex)
        {

        }

        Animal animalTemp = null;
        try
        {
            //Get Specie, Type Gender and Age from Drop Down Lists
            species = ddlSpecies.SelectedItem.ToString();

            type = ddlType.SelectedItem.ToString();
            gender = ddlGender.SelectedItem.ToString();
            age = ddlAge.SelectedItem.ToString();

            //Find Animal in DB by Origin, Type, Gender etc.
            animalTemp = (from a in mdolEntities.Animals
                          where a.OriginID == originTemp.OriginID &&
                          a.Species.SpeciesName.Equals(species) &&
                          a.Type.TypeName.Equals(type) &&
                          a.Gender.GenderName.Equals(gender) &&
                          a.Age.AgeRange.Equals(age)
                          select a).FirstOrDefault();
        }
        catch(Exception ex)
        {

        }


        if (originTemp != null && animalTemp != null)
        {
            try
            {
                AnimalRequirement animalReqTemp = null;

                //Get Animal Requirements only for selected Animal
                var animalReq = from a in mdolEntities.AnimalRequirements
                                where a.AnimalID == animalTemp.AnimalID
                                select a;

                //Get Requirement Description based on what information was 
                //selected from Drop Down Lists
                if (animalReq.Any())
                {
                    foreach (var a in animalReq)
                    {
                        animalReqTemp = a;

                        //Get data and save it
                        string requirementType = a.Requirement.RequirementType.Type;
                        string requirementName = a.Requirement.Name;
                        string link = a.Requirement.Link;
                        string text = a.Requirement.Text;
                        string html = a.Requirement.HTML;

                        string rType = null;
                        string rName = null;
                        string rLink = null;
                        string rText = null;
                        string rHTML = null;

                        //If link, text or html is null or is "N/A"
                        //use default values
                        if (requirementType != null && !requirementType.Equals("N/A"))
                        {
                            rType = requirementType;
                        }
                        if (requirementName != null && !requirementName.Equals("N/A"))
                        {
                            rName = requirementName + "<br />";
                        }
                        if (link != null && !link.Equals("N/A"))
                        {
                            rLink = "<div class='link' id='divLink'><a href='" + link + "'>" + requirementName + "</a></div>";
                        }
                        else
                        {
                            rLink = "<div class='link' id='divLink'>" + requirementName + "<br />Link is unavailable.</div>";
                        }
                        if (text != null && !text.Equals("N/A"))
                        {
                            rText = "<div class='text' id='divText'>" + requirementName + "<br />" + text + "</div>";
                        }
                        else
                        {
                            rText = "<div class='text' id='divText'>" + requirementName + "<br />Information is unavailable.</div>";
                        }
                        if (html != null && !html.Equals("N/A"))
                        {
                            rHTML = "<div class='html_inj' id='divHTML'>" + html + "</div>";
                        }

                        str = rLink + rText + rHTML;

                        //Call method that will inject data into web page
                        htmlInjection(str);
                    }
                }
                else
                {
                    string emptyContentText = "Requirements are not defined for the selected animal.";
                    string emptyContent = "<div class='empty_content' id='divEmptyContent'>" + emptyContentText + "</div>";
                    str = emptyContent;

                    htmlInjection(str);
                }
            }
            catch (Exception ex)
            {
                //string emptyContentText = "Exception";
                //string emptyContent = "<div class='empty_content' id='divEmptyContent'>" + emptyContentText + "</div>";
                //str = emptyContent;

                //htmlInjection(str);
            }
        }
        else
        {
            string emptyContentText = "Requirements are not defined for the selected animal.";
            string emptyContent = "<div class='empty_content' id='divEmptyContent'>" + emptyContentText + "</div>";
            str = emptyContent;

            htmlInjection(str);
        }
    }
    private void htmlInjection(string str)
    {
        //Add ending block after each injection Requirement
        string ending = "<div class='split_info' id='divSplitInfo'></div>";

        //Get previously injected data from web page
        string temp = animlaContent.InnerHtml;

        //Data Injection
        animlaContent.InnerHtml = temp + str + ending;

        //animlaContent.InnerHtml += str;
    }
    protected void bShowReq_Click(object sender, EventArgs e)
    {
        //Clear web page from previously injected data into web page
        animlaContent.InnerHtml = "";
        ShowInfo();
    }
}