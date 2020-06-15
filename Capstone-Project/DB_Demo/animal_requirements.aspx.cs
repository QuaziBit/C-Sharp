using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class animal_requirements : System.Web.UI.Page
{
    private MDOLEntities1 mdolEntities = new MDOLEntities1();
    private List<string> exceptionList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadAnimaRequirements();
            LoadInfo();
        }
    }

    private void AddAnimalRequirement()
    {
        try
        {
            //Get previously selected Animal from Session
            //Later for this Animal will be added Requirements
            Animal animaTemp = (Animal)Session["animaTemporalObjec"];

            //Get selected Requirement
            string selectedRequirement = ddlAvailableRequirements.SelectedValue.ToString();

            //Find Requirement by its Name "selectedRequirement"
            Requirement requirementTemp = (from r in mdolEntities.Requirements
                                           where r.Name.ToLower().Equals(selectedRequirement.ToLower())
                                           select r).FirstOrDefault();

            if (animaTemp != null && requirementTemp != null)
            {
                //Get all Animal Requirements
                var animalReqTemp = from ar in mdolEntities.AnimalRequirements
                                    select ar;

                //Prevent adding duplicate requirements for the selected Animal
                int dCounter = 0;
                foreach (var r in animalReqTemp)
                {
                    if (r.AnimalID == animaTemp.AnimalID)
                    {
                        if (r.RequirementID == requirementTemp.RequirementID)
                        {
                            dCounter++;
                        }
                    }
                }
                if (dCounter == 0)
                {
                    //Add Requirement for the selected Animal
                    AnimalRequirement temp = new AnimalRequirement();
                    temp.AnimalID = animaTemp.AnimalID;
                    temp.RequirementID = requirementTemp.RequirementID;
                    mdolEntities.AnimalRequirements.Add(temp);
                    mdolEntities.SaveChanges();
                }

            }

            LoadAnimaRequirements();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal_Requirements Class}: [Method: AddAnimalRequirement()]";
            ExceptionsSaver(str);
        }
    }

    private void DeleteAnimalRequirement()
    {
        Animal animalTemp = null;
        Requirement requirementTemp = null;
        AnimalRequirement temp = null;

        try
        {
            animalTemp = (Animal)Session["animaTemporalObjec"];
            string selectedRequirement = ddlAnimalRequirements.SelectedValue.ToString();

            //Find Requirement by its Name
            requirementTemp = (from r in mdolEntities.Requirements
                                           where r.Name.ToLower().Equals(selectedRequirement.ToLower())
                                           select r).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal_Requirements Class}: [Method: DeleteAnimalRequirement()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Find specific Animal Requirement record
            temp = (from ar in mdolEntities.AnimalRequirements
                    where ar.AnimalID == animalTemp.AnimalID &&
                    ar.RequirementID == requirementTemp.RequirementID
                    select ar).FirstOrDefault();

            lblAnimalRequirementMessage.Text = null;
        }
        catch(Exception ex)
        {
            lblAnimalRequirementMessage.Text = "Oops, Requirement record cannot be found.";
        }

        //Remove record
        if (temp != null)
        {
            try
            {
                //Delete selected Requirement from selected Animal
                mdolEntities.AnimalRequirements.Remove(temp);
                mdolEntities.SaveChanges();

                lblAnimalRequirementMessage.Text = null;

                LoadAnimaRequirements();
            }
            catch(Exception ex)
            {
                lblAnimalRequirementMessage.Text = "Oops, Requirement record cannot be Deleted.";
            }
        }
    }

    //After adding Animal and Requirement or "on first web page load", 
    //this method will be called to refresh Animal and Requirement Drop Down Lists
    private void LoadAnimaRequirements()
    {
        try
        {
            lblAnimalRequirementMessage.Text = null;

            string countryName = null;
            string stateName = null;
            string countyName = null;

            string speciesName = null;
            string typeName = null;
            string genderName = null;
            string ageRange = null;

            //Get all Animals
            var animals = from a in mdolEntities.Animals
                          select a;

            //Load Animals into Dro Down List
            ddlAnimals.Items.Clear();
            foreach (var a in animals)
            {
                ddlAnimals.Items.Add(a.Origin.Country.CountryName + "; " + a.Origin.State.StateName + "; " + a.Origin.County.CountyName + "; " + a.Species.SpeciesName + "; " + a.Type.TypeName + "; " + a.Gender.GenderName + "; " + a.Age.AgeRange);
            }

            //Get previously selected Animal from Session
            Animal animalTemp = null;
            animalTemp = (Animal)Session["animaTemporalObjec"];

            if (animalTemp == null)
            {
                //Split Text from ddlShowAnimals
                //=====================================================================//
                //Get selected Animal by default from ddlAnimals
                string selectedAnimalItem = ddlAnimals.SelectedItem.Value.ToString();

                //Split selectedItem into Species, Type, Gender and Age
                string animalStrTemp = selectedAnimalItem;
                string[] animalTempArray = animalStrTemp.Split(';');
                for (int i = 0; i < animalTempArray.Length; i++)
                {
                    //Remove space
                    char[] space = { ' ' };
                    string tmp = animalTempArray[i].Trim(space);
                    animalTempArray[i] = tmp;
                }

                for (int i = 0; i < animalTempArray.Length; i++)
                {
                    if (i == 0)
                    {
                        countryName = animalTempArray[i];
                    }
                    if (i == 1)
                    {
                        stateName = animalTempArray[i];
                    }
                    if (i == 2)
                    {
                        countyName = animalTempArray[i];
                    }
                    if (i == 3)
                    {
                        speciesName = animalTempArray[i];
                    }
                    if (i == 4)
                    {
                        typeName = animalTempArray[i];
                    }
                    if (i == 5)
                    {
                        genderName = animalTempArray[i];
                    }
                    if (i == 6)
                    {
                        ageRange = animalTempArray[i];
                    }
                }

                //Find Species, Type, Gender and Age based on what was selected in ddlShowAnimals
                Species speciesTemp = (from s in mdolEntities.Species
                                       where s.SpeciesName.ToLower().Equals(speciesName.ToLower())
                                       select s).FirstOrDefault();
                Type typeTemp = (from t in mdolEntities.Types
                                 where t.TypeName.ToLower().Equals(typeName.ToLower())
                                 select t).FirstOrDefault();
                Gender genderTemp = (from g in mdolEntities.Genders
                                     where g.GenderName.ToLower().Equals(genderName.ToLower())
                                     select g).FirstOrDefault();
                Age ageTemp = (from a in mdolEntities.Ages
                               where a.AgeRange.ToLower().Equals(ageRange.ToLower())
                               select a).FirstOrDefault();

                //Find Animal
                animalTemp = (from a in mdolEntities.Animals
                              where a.Origin.Country.CountryName.ToLower().Equals(countryName.ToLower()) &&
                              a.Origin.State.StateName.ToLower().Equals(stateName.ToLower()) &&
                              a.Origin.County.CountyName.ToLower().Equals(countyName.ToLower()) &&
                              a.SpeciesID == speciesTemp.SpeciesID &&
                              a.TypeID == typeTemp.TypeID &&
                              a.GenderID == genderTemp.GenderID &&
                              a.AgeID == ageTemp.AgeID
                              select a).FirstOrDefault();
            }
            else
            {
                //If Session is not null select previously selected animal in the Drop Down List
                ddlAnimals.SelectedIndex = ddlAnimals.Items.IndexOf(ddlAnimals.Items.FindByValue(animalTemp.Origin.Country.CountryName + "; " + animalTemp.Origin.State.StateName + "; " + animalTemp.Origin.County.CountyName + "; " + animalTemp.Species.SpeciesName + "; " + animalTemp.Type.TypeName + "; " + animalTemp.Gender.GenderName + "; " + animalTemp.Age.AgeRange));
            }


            //Get all Requirements thet connected to the selected Animal
            List<AnimalRequirement> animalRequirementsList = new List<AnimalRequirement>();
            var animalRequirements = from ar in mdolEntities.AnimalRequirements
                                     where ar.AnimalID == animalTemp.AnimalID
                                     select ar;
            ddlAnimalRequirements.Items.Clear();
            foreach (var ar in animalRequirements)
            {
                animalRequirementsList.Add((AnimalRequirement)ar);
                ddlAnimalRequirements.Items.Add(ar.Requirement.Name);
            }

            //Get all Available Requirements
            var allRequirements = from r in mdolEntities.Requirements
                                  select r;
            ddlAvailableRequirements.Items.Clear();
            foreach (var r in allRequirements)
            {
                ddlAvailableRequirements.Items.Add(r.Name);
            }

            Session["animaTemporalObjec"] = animalTemp;
            Session["animalRequirementsList"] = animalRequirementsList;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal_Requirements Class}: [Method: LoadAnimaRequirements()]";
            ExceptionsSaver(str);
        }
    }


    //Animal Requirements
    //####################################################################################//
    //Add, Update, Delete Animal Requirements
    //==========================================================================//
    protected void ddlAnimals_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Reset of warning text
            lblNoAnimal.Text = "";

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//
            //Get selected Animal by default from ddlAnimals
            string countryName = null;
            string stateName = null;
            string countyName = null;

            string speciesName = null;
            string typeName = null;
            string genderName = null;
            string ageRange = null;

            //Split Text from ddlShowAnimals
            //=====================================================================//
            string selectedAnimalItem = ddlAnimals.SelectedItem.Value.ToString();

            //Split selectedItem into Species, Type, Gender and Age
            string animalTemp = selectedAnimalItem;
            string[] animalTempArray = animalTemp.Split(';');
            for (int i = 0; i < animalTempArray.Length; i++)
            {
                //Remove space
                char[] space = { ' ' };
                string tmp = animalTempArray[i].Trim(space);
                animalTempArray[i] = tmp;
            }

            for (int i = 0; i < animalTempArray.Length; i++)
            {
                if (i == 0)
                {
                    countryName = animalTempArray[i];
                }
                if (i == 1)
                {
                    stateName = animalTempArray[i];
                }
                if (i == 2)
                {
                    countyName = animalTempArray[i];
                }
                if (i == 3)
                {
                    speciesName = animalTempArray[i];
                }
                if (i == 4)
                {
                    typeName = animalTempArray[i];
                }
                if (i == 5)
                {
                    genderName = animalTempArray[i];
                }
                if (i == 6)
                {
                    ageRange = animalTempArray[i];
                }
            }

            //Find Species, Type, Gender and Age based on what was selected in ddlShowAnimals
            Species speciesTemp = (from s in mdolEntities.Species
                                   where s.SpeciesName.ToLower().Equals(speciesName.ToLower())
                                   select s).FirstOrDefault();
            Type typeTemp = (from t in mdolEntities.Types
                             where t.TypeName.ToLower().Equals(typeName.ToLower())
                             select t).FirstOrDefault();
            Gender genderTemp = (from g in mdolEntities.Genders
                                 where g.GenderName.ToLower().Equals(genderName.ToLower())
                                 select g).FirstOrDefault();
            Age ageTemp = (from a in mdolEntities.Ages
                           where a.AgeRange.ToLower().Equals(ageRange.ToLower())
                           select a).FirstOrDefault();

            //Find Animal
            Animal animaTemp = (from a in mdolEntities.Animals
                                where a.Origin.Country.CountryName.ToLower().Equals(countryName.ToLower()) &&
                                a.Origin.State.StateName.ToLower().Equals(stateName.ToLower()) &&
                                a.Origin.County.CountyName.ToLower().Equals(countyName.ToLower()) &&
                                a.SpeciesID == speciesTemp.SpeciesID &&
                                a.TypeID == typeTemp.TypeID &&
                                a.GenderID == genderTemp.GenderID &&
                                a.AgeID == ageTemp.AgeID
                                select a).FirstOrDefault();
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

            //Get all Requirements the connected to the selected Animal
            List<AnimalRequirement> animalRequirementsList = new List<AnimalRequirement>();
            var animalRequirements = from ar in mdolEntities.AnimalRequirements
                                     where ar.AnimalID == animaTemp.AnimalID
                                     select ar;
            ddlAnimalRequirements.Items.Clear();
            foreach (var ar in animalRequirements)
            {
                animalRequirementsList.Add((AnimalRequirement)ar);
                ddlAnimalRequirements.Items.Add(ar.Requirement.Name);
            }

            //Get all Available Requirements
            var allRequirements = from r in mdolEntities.Requirements
                                  select r;
            ddlAvailableRequirements.Items.Clear();
            foreach (var r in allRequirements)
            {
                ddlAvailableRequirements.Items.Add(r.Name);
            }

            Session["animaTemporalObjec"] = animaTemp;
            Session["animalRequirementsList"] = animalRequirementsList;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal_Requirements Class}: [Method: ddlAnimals_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bAddAnimalRequirement_Click(object sender, EventArgs e)
    {
        //Reset of warning text
        lblNoAnimal.Text = "";
        AddAnimalRequirement();
    }
    protected void bDeleteAnimalRequirement_Click(object sender, EventArgs e)
    {
        //Reset of warning text
        lblNoAnimal.Text = "";
        DeleteAnimalRequirement();
    }
    //==========================================================================//
    //####################################################################################//

    //Load information into Origins, Species, Types, Gender and Age drop down lists
    protected void LoadInfo()
    {
        try
        {
            //Get all Origin, Specie, Type, Gender and Age records
            var origins = from o in mdolEntities.Origins
                          select o;
            var species = from s in mdolEntities.Species
                          select s;
            var types = from t in mdolEntities.Types
                        select t;
            var gender = from g in mdolEntities.Genders
                         select g;
            var age = from a in mdolEntities.Ages
                      orderby a.AgeRange
                      select a;

            //Load all Origin, Specie, Type, Gender and Age records into Drop Down Lists
            ddlOrigins.Items.Clear();
            ddlSpecies.Items.Clear();
            ddlTypes.Items.Clear();
            ddlGender.Items.Clear();
            ddlAge.Items.Clear();
            foreach (var o in origins)
            {
                ddlOrigins.Items.Add(o.Country.CountryName + "; " + o.State.StateName + "; " + o.County.CountyName);
            }
            foreach (var s in species)
            {
                ddlSpecies.Items.Add(s.SpeciesName);
            }
            foreach (var t in types)
            {
                ddlTypes.Items.Add(t.TypeName);
            }
            foreach (var g in gender)
            {
                ddlGender.Items.Add(g.GenderName);
            }
            foreach (var a in age)
            {
                ddlAge.Items.Add(a.AgeRange);
            }
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal_Requirements Class}: [Method: LoadInfo()]";
            ExceptionsSaver(str);
        }
    }
    protected void FindAnimal_Click(object sender, EventArgs e)
    {
        //Reset of warning text
        lblNoAnimal.Text = "";

        try
        {
            string sOrigin = null;

            string sCountryName = null;
            string sStateName = null;
            string sCountyName = null;

            string sSpecies = null;
            string sType = null;
            string sGender = null;
            string sAge = null;


            //=========================================================================//
            //Get Selected Origin item from Drop Down List
            sOrigin = ddlOrigins.SelectedValue.ToString();

            //Split Selected Origin item into Country, State and County
            string originTemp = sOrigin;
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
                    sCountryName = originTempArray[i];
                }
                if (i == 1)
                {
                    sStateName = originTempArray[i];
                }
                if (i == 2)
                {
                    sCountyName = originTempArray[i];
                }
            }
            //=============================================================================//
            //Get Species, Type, Gender and Age from drop down lists
            sSpecies = ddlSpecies.SelectedValue.ToString();
            sType = ddlTypes.SelectedValue.ToString();
            sGender = ddlGender.SelectedValue.ToString();
            sAge = ddlAge.SelectedValue.ToString();

            //Find Species, Type, Gender and Age based on what was selected in drop down lists
            Species speciesTemp = (from s in mdolEntities.Species
                                   where s.SpeciesName.ToLower().Equals(sSpecies.ToLower())
                                   select s).FirstOrDefault();
            Type typeTemp = (from t in mdolEntities.Types
                             where t.TypeName.ToLower().Equals(sType.ToLower())
                             select t).FirstOrDefault();
            Gender genderTemp = (from g in mdolEntities.Genders
                                 where g.GenderName.ToLower().Equals(sGender.ToLower())
                                 select g).FirstOrDefault();
            Age ageTemp = (from a in mdolEntities.Ages
                           where a.AgeRange.ToLower().Equals(sAge.ToLower())
                           select a).FirstOrDefault();

            Animal animalTemp = null;

            //Find Animal record based on selected values
            animalTemp = (from a in mdolEntities.Animals
                          where a.Origin.Country.CountryName.ToLower().Equals(sCountryName.ToLower()) &&
                          a.Origin.State.StateName.ToLower().Equals(sStateName.ToLower()) &&
                          a.Origin.County.CountyName.ToLower().Equals(sCountyName.ToLower()) &&
                          a.SpeciesID == speciesTemp.SpeciesID &&
                          a.TypeID == typeTemp.TypeID &&
                          a.GenderID == genderTemp.GenderID &&
                          a.AgeID == ageTemp.AgeID
                          select a).FirstOrDefault();

            //If animal has not been found get Animal from the Session
            if (animalTemp == null)
            {
                if (Session["animaTemporalObjec"] != null)
                {
                    animalTemp = (Animal)Session["animaTemporalObjec"];
                    lblNoAnimal.Text = "No such Animal in the Database.";
                }
            }
            else
            {
                //Animal record selection based on record that was found in DB
                ddlAnimals.SelectedIndex = ddlAnimals.Items.IndexOf(ddlAnimals.Items.FindByValue(sCountryName + "; " + sStateName + "; " + sCountyName + "; " + sSpecies + "; " + sType + "; " + sGender + "; " + sAge));
            }

            //Get all Requirements that connected to the selected Animal
            var animalRequirements = from ar in mdolEntities.AnimalRequirements
                                     where ar.AnimalID == animalTemp.AnimalID
                                     select ar;
            ddlAnimalRequirements.Items.Clear();
            foreach (var ar in animalRequirements)
            {
                ddlAnimalRequirements.Items.Add(ar.Requirement.Name);
            }

            //Get all Available Requirements
            var allRequirements = from r in mdolEntities.Requirements
                                  select r;
            ddlAvailableRequirements.Items.Clear();
            foreach (var r in allRequirements)
            {
                ddlAvailableRequirements.Items.Add(r.Name);
            }

            //Save into session newly selected or found Animal Record in DB
            Session["animaTemporalObjec"] = animalTemp;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal_Requirements Class}: [Method: FindAnimal_Click()]";
            ExceptionsSaver(str);
        }
    }

    //If some Exception occurs this method will be called, an Exception will be 
    //added into List after, this List will be saved in the Session.
    //In addition, all Exception will be displayed in the Drop Down Box
    private void ExceptionsSaver(string str)
    {
        if (Session["AnimalReqExceptionList"] != null)
        {
            exceptionList = (List<string>)Session["AnimalReqExceptionList"];
            exceptionList.Add(str);

            exceptionsTable.Visible = true;

            lbExceptions.Items.Clear();
            foreach (string s in exceptionList)
            {
                lbExceptions.Items.Add(s);
            }

            Session["AnimalReqExceptionList"] = exceptionList;
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

            Session["AnimalReqExceptionList"] = exceptionList;
        }
    }
}