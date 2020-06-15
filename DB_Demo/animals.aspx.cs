using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class animal : System.Web.UI.Page
{
    private MDOLEntities1 mdolEntities = new MDOLEntities1();
    private List<string> exceptionList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSpecies();
            LoadTypes();
            LoadGender();
            LoadAge();

            LoadAnimalItems();
        }
    }


    private void AddSpecies()
    {
        try
        {
            string speciesName = null;

            //Get text value from New Species Field if this Field is not null and not Empty
            if (txNewSpecies.Value.ToString() != null && !txNewSpecies.Value.ToString().Equals(""))
            {
                speciesName = txNewSpecies.Value.ToString();
            }

            if (speciesName != null)
            {
                //Get all Species
                var species = from s in mdolEntities.Species
                              select s;

                //Check if entered Species name exists in the Database
                int dCounter = 0;
                foreach (var s in species)
                {
                    if (s.SpeciesName.ToLower().Equals(speciesName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new Specie into DB
                    Species speciesTemp = new Species();
                    speciesTemp.SpeciesName = speciesName;
                    mdolEntities.Species.Add(speciesTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblSpeciesMessage.Text = speciesName + ": already exists in the database";
                }
            }
            txNewSpecies.Value = null;
            LoadSpecies();
            LoadAnimalItems();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: AddSpecies()]";
            ExceptionsSaver(str);
        }
    }
    private void AddType()
    {
        try
        {
            string typeName = null;

            //Get text value from New Type Field if this Field is not null and not Empty
            if (txNewType.Value.ToString() != null && !txNewType.Value.ToString().Equals(""))
            {
                typeName = txNewType.Value.ToString();
            }

            if (typeName != null)
            {
                //Get all Types
                var types = from t in mdolEntities.Types
                            select t;

                //Check if entered Type name exists in the Database
                int dCounter = 0;
                foreach (var t in types)
                {
                    if (t.TypeName.ToLower().Equals(typeName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new Type into DB
                    Type typeTemp = new Type();
                    typeTemp.TypeName = typeName;
                    mdolEntities.Types.Add(typeTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblTypeMessage.Text = typeName + ": already exists in the database";
                }
            }
            txNewType.Value = null;
            LoadTypes();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: AddType()]";
            ExceptionsSaver(str);
        }
    }
    private void AddGender()
    {
        try
        {
            string genderName = null;

            //Get text value from New Gender Field if this Field is not null and not Empty
            if (txNewGender.Value.ToString() != null && !txNewGender.Value.ToString().Equals(""))
            {
                genderName = txNewGender.Value.ToString();
            }

            if (genderName != null)
            {
                //Get all Genders
                var gender = from g in mdolEntities.Genders
                             select g;

                //Check if entered Gender name is exists in the Database
                int dCounter = 0;
                foreach (var g in gender)
                {
                    if (g.GenderName.ToLower().Equals(genderName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new Gender into DB
                    Gender genderTemp = new Gender();
                    genderTemp.GenderName = genderName;
                    mdolEntities.Genders.Add(genderTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblGenderMessage.Text = genderName + ": already exists in the database";
                }
            }
            txNewGender.Value = null;
            LoadGender();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: AddGender()]";
            ExceptionsSaver(str);
        }
    }
    private void AddAge()
    {
        try
        {
            string newAge = null;

            //Get text value from New Age Field if this Field is not null and not Empty
            if (txNewAge.Value.ToString() != null && !txNewAge.Value.ToString().Equals(""))
            {
                newAge = txNewAge.Value.ToString();
            }

            if (newAge != null)
            {
                //Get all Ages
                var age = from a in mdolEntities.Ages
                          select a;

                //Check if entered Type name is exists in the Database
                int dCounter = 0;
                foreach (var a in age)
                {
                    if (a.AgeRange.ToLower().Equals(newAge.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Add new Age into DB
                    Age ageTemp = new Age();
                    ageTemp.AgeRange = newAge;
                    mdolEntities.Ages.Add(ageTemp);
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblAgeMessage.Text = newAge + ": already exists in the database";
                }
            }
            txNewAge.Value = null;
            LoadAge();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: AddAge()]";
            ExceptionsSaver(str);
        }
    }
    private void AddAnimal()
    {
        try
        {
            string countryName = null;
            string stateName = null;
            string countyName = null;

            //Get string values from Drop Down Lists and save them
            string speciesName = ddlSpecies.SelectedValue.ToString();
            string typeName = ddlTypes.SelectedValue.ToString();
            string genderName = ddlGender.SelectedValue.ToString();
            string ageRange = ddlAge.SelectedValue.ToString();

            //Split Text from ddlOrigins
            //=====================================================================//
            string selectedOrigin = ddlOrigins.SelectedItem.Value.ToString();

            //Split selectedItem into Country, State and County
            string originTemp = selectedOrigin;
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

            //Find Specie, Type, Gender and Age in Database
            //=====================================================================//
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
            //=====================================================================//

            //Find Origin in the DB
            //=====================================================================//
            Origin originObjTemp = (from o in mdolEntities.Origins
                                    where o.Country.CountryName.ToLower().Equals(countryName.ToLower()) &&
                                    o.State.StateName.ToLower().Equals(stateName.ToLower()) &&
                                    o.County.CountyName.ToLower().Equals(countyName.ToLower())
                                    select o).FirstOrDefault();
            //=====================================================================//

            //Get all Animals
            var animalD = from a in mdolEntities.Animals
                          select a;

            //Check if entered Animal exists in the Database
            int dCounter = 0;
            foreach (var a in animalD)
            {
                if (a.OriginID == originObjTemp.OriginID && a.SpeciesID == speciesTemp.SpeciesID && a.TypeID == typeTemp.TypeID && a.GenderID == genderTemp.GenderID && a.AgeID == ageTemp.AgeID)
                {
                    dCounter++;
                }
            }
            if (dCounter == 0)
            {
                //Add Animal record into Database
                Animal animalObjTemp = new Animal();
                animalObjTemp.SpeciesID = speciesTemp.SpeciesID;
                animalObjTemp.TypeID = typeTemp.TypeID;
                animalObjTemp.GenderID = genderTemp.GenderID;
                animalObjTemp.AgeID = ageTemp.AgeID;
                animalObjTemp.OriginID = originObjTemp.OriginID;

                //Save new Animal into Session
                Session["animalTemp"] = animalObjTemp;

                mdolEntities.Animals.Add(animalObjTemp);
                mdolEntities.SaveChanges();
            }
            else
            {
                lblAnimalMessage.Text = countryName + "; " + stateName + "; " + countyName + "; " + speciesTemp.SpeciesName + "; " + typeTemp.TypeName + "; " + genderTemp.GenderName + "; " + ageTemp.AgeRange + "; " + ": already exists in the database";
            }
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: AddAnimal()]";
            ExceptionsSaver(str);
        }
    }



    private void UpdateSpecies()
    {
        try
        {
            Species speciesTemp = null;

            //Get Selected Specie Name from Session
            string selectedSpeciesName = Session["selectedSpeciesName"].ToString();

            //Get new name of Specie and save it
            string newSpeciesName = txNewSpeciesName.Value.ToString();

            //Find Specie record in database by Specie Name
            speciesTemp = (from s in mdolEntities.Species
                           where s.SpeciesName.ToLower().Equals(selectedSpeciesName.ToLower())
                           select s).FirstOrDefault();

            if (txNewSpeciesName.Value != null && !txNewSpeciesName.Value.Equals(""))
            {
                //Get all Species
                var species = from s in mdolEntities.Species
                              select s;

                //Check if entered Species name is exists in the Database
                int dCounter = 0;
                foreach (var s in species)
                {
                    if (s.SpeciesName.ToLower().Equals(newSpeciesName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Species record
                    speciesTemp.SpeciesName = newSpeciesName;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblSpeciesMessage.Text = speciesTemp.SpeciesName + ": already exists in the database";
                }
            }
            txNewSpeciesName.Value = null;
            LoadSpecies();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: UpdateSpecies()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateType()
    {
        try
        {
            Type typeTemp = null;

            //Get Selected Type Name from Session
            string selectedTypeName = Session["selectedTypeName"].ToString();

            //Get new name of Type and save it
            string newTypeName = txNewTypeName.Value.ToString();

            //Find Type record in database by Type Name
            typeTemp = (from t in mdolEntities.Types
                        where t.TypeName.ToLower().Equals(selectedTypeName.ToLower())
                        select t).FirstOrDefault();

            if (txNewTypeName.Value != null && !txNewTypeName.Value.Equals(""))
            {
                //Get all Types
                var types = from t in mdolEntities.Types
                            select t;

                //Check if entered Type name is exists in the Database
                int dCounter = 0;
                foreach (var t in types)
                {
                    if (t.TypeName.ToLower().Equals(newTypeName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Species record
                    typeTemp.TypeName = newTypeName;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblTypeMessage.Text = typeTemp.TypeName + ": already exists in the database";
                }
            }
            txNewTypeName.Value = null;
            LoadTypes();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: UpdateType()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateGender()
    {
        try
        {
            Gender genderTemp = null;

            //Get Selected Gender Name from Session
            string selectedGenderName = Session["selectedGenderName"].ToString();

            //Get new name of Gender and save it
            string newGenderName = txNewGenderName.Value.ToString();

            //Find Gender record in database by Gender Name
            genderTemp = (from g in mdolEntities.Genders
                          where g.GenderName.ToLower().Equals(selectedGenderName.ToLower())
                          select g).FirstOrDefault();

            if (txNewGenderName.Value != null && !txNewGenderName.Value.Equals(""))
            {
                //Get all Genders
                var gender = from g in mdolEntities.Genders
                             select g;

                //Check if entered Type name is exists in the Database
                int dCounter = 0;
                foreach (var g in gender)
                {
                    if (g.GenderName.ToLower().Equals(newGenderName.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Species record
                    genderTemp.GenderName = newGenderName;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblGenderMessage.Text = genderTemp.GenderName + ": already exists in the database";
                }
            }
            txNewGenderName.Value = null;
            LoadGender();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: UpdateGender()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateAge()
    {
        try
        {
            Age ageTemp = null;

            //Get Selected Age Range from Session
            string selectedAgeRange = Session["selectedAgeRange"].ToString();

            //Get new name of Age and save it
            string newAgeRange = txNewAgeRange.Value.ToString();

            //Find Age record in database by Age Range
            ageTemp = (from a in mdolEntities.Ages
                       where a.AgeRange.ToLower().Equals(selectedAgeRange.ToLower())
                       select a).FirstOrDefault();

            if (txNewAgeRange.Value != null && !txNewAgeRange.Value.Equals(""))
            {
                //Get all Ages
                var age = from a in mdolEntities.Ages
                          select a;

                //Check if entered Type name is exists in the Database
                int dCounter = 0;
                foreach (var a in age)
                {
                    if (a.AgeRange.ToLower().Equals(newAgeRange.ToLower()))
                    {
                        dCounter++;
                    }
                }
                if (dCounter == 0)
                {
                    //Update Species record
                    ageTemp.AgeRange = newAgeRange;
                    mdolEntities.SaveChanges();
                }
                else
                {
                    lblAgeMessage.Text = ageTemp.AgeRange + ": already exists in the database";
                }
            }
            txNewAgeRange.Value = null;
            LoadAge();
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: UpdateAge()]";
            ExceptionsSaver(str);
        }
    }
    private void UpdateAnimal()
    {
        try
        {
            //Get Animal Object from Session
            Animal animaTemp = (Animal)Session["animalTemp"];

            string countryName = null;
            string stateName = null;
            string countyName = null;

            //Get string values from Drop Down Lists and save them
            string speciesName = ddlSpecies.SelectedValue.ToString();
            string typeName = ddlTypes.SelectedValue.ToString();
            string genderName = ddlGender.SelectedValue.ToString();
            string ageRange = ddlAge.SelectedValue.ToString();

            //##########################################################################//
            //Split Text from ddlOrigins
            //=====================================================================//
            string selectedOrigin = ddlOrigins.SelectedItem.Value.ToString();

            //Split selectedItem into Country, State and County
            string originTemp = selectedOrigin;
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

            //Find Origin
            Origin originObjTemp = (from o in mdolEntities.Origins
                                    where o.Country.CountryName.ToLower().Equals(countryName.ToLower()) &&
                                    o.State.StateName.ToLower().Equals(stateName.ToLower()) &&
                                    o.County.CountyName.ToLower().Equals(countyName.ToLower())
                                    select o).FirstOrDefault();

            //=====================================================================//


            //Find Species, Type, Gender and Age based on what was selected in the Drop Down Lists
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
            Animal temp = (from a in mdolEntities.Animals
                           where a.AnimalID == animaTemp.AnimalID
                           select a).FirstOrDefault();

            //Get all Animals
            var animalD = from a in mdolEntities.Animals
                          select a;

            //Check if entered Animal is exists in the Database
            int dCounter = 0;
            foreach (var a in animalD)
            {
                if (a.OriginID == originObjTemp.OriginID && a.SpeciesID == speciesTemp.SpeciesID && a.TypeID == typeTemp.TypeID && a.GenderID == genderTemp.GenderID && a.AgeID == ageTemp.AgeID)
                {
                    dCounter++;
                }
            }
            if (dCounter == 0)
            {
                //Save Changes
                temp.SpeciesID = speciesTemp.SpeciesID;
                temp.TypeID = typeTemp.TypeID;
                temp.GenderID = genderTemp.GenderID;
                temp.AgeID = ageTemp.AgeID;
                temp.OriginID = originObjTemp.OriginID;

                //Save new Animal into Session
                Session["animalTemp"] = temp;

                mdolEntities.SaveChanges();
            }
            else
            {
                lblAnimalMessage.Text = countryName + "; " + stateName + "; " + countyName + "; " + speciesTemp.SpeciesName + "; " + typeTemp.TypeName + "; " + genderTemp.GenderName + "; " + ageTemp.AgeRange + "; " + ": already exists in the database";
            }
            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: UpdateAnimal()]";
            ExceptionsSaver(str);
        }
    }



    private void DeleteSpecies()
    {
        Species speciesTemp = null;
        string selectedSpeciesName = null;

        try
        {
            selectedSpeciesName = Session["selectedSpeciesName"].ToString();

            //Find Specie record in database by Specie Name
            speciesTemp = (from s in mdolEntities.Species
                           where s.SpeciesName.ToLower().Equals(selectedSpeciesName.ToLower())
                           select s).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: DeleteSpecies()]";
            ExceptionsSaver(str);
        }

        if (speciesTemp != null)
        {
            try
            {
                //Delete Species Record
                mdolEntities.Species.Remove(speciesTemp);
                mdolEntities.SaveChanges();

                lblSpeciesMessage.Text = null;
                txNewSpeciesName.Value = null;

                LoadSpecies();
                LoadAnimalItems();
            }
            catch(Exception ex)
            {
                lblSpeciesMessage.Text = "This Species cannot be deleted because some records are connected to this Species.";
            }
        }
    }
    private void DeleteType()
    {
        Type typeTemp = null;
        string selectedTypeName = null;

        try
        {
            selectedTypeName = Session["selectedTypeName"].ToString();

            //Find Type record in database by Type Name
            typeTemp = (from t in mdolEntities.Types
                        where t.TypeName.ToLower().Equals(selectedTypeName.ToLower())
                        select t).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: DeleteType()]";
            ExceptionsSaver(str);
        }

        if (typeTemp != null)
        {
            try
            {
                //Delete Type Record
                mdolEntities.Types.Remove(typeTemp);
                mdolEntities.SaveChanges();

                lblTypeMessage.Text = null;
                txNewTypeName.Value = null;

                LoadTypes();
                LoadAnimalItems();
            }
            catch (Exception ex)
            {
                lblTypeMessage.Text = "This Type cannot be deleted because some records are connected to this Type.";
            }
        }
        
    }
    private void DeleteGender()
    {
        Gender genderTemp = null;
        string selectedGenderName = null;

        try
        {
            selectedGenderName = Session["selectedGenderName"].ToString();

            //Find Gender record in database by Gender Name
            genderTemp = (from g in mdolEntities.Genders
                          where g.GenderName.ToLower().Equals(selectedGenderName.ToLower())
                          select g).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: DeleteGender()]";
            ExceptionsSaver(str);
        }

        if (genderTemp != null)
        {
            try
            {
                //Delete Gender Record
                mdolEntities.Genders.Remove(genderTemp);
                mdolEntities.SaveChanges();

                lblGenderMessage.Text = null;
                txNewGenderName.Value = null;

                LoadGender();
                LoadAnimalItems();
            }
            catch (Exception ex)
            {
                lblGenderMessage.Text = "This Gender cannot be deleted because some records are connected to this Gender.";
            }
        }
        
    }
    private void DeleteAge()
    {
        Age ageTemp = null;
        string selectedAgeRange = null;

        try
        {
            selectedAgeRange = Session["selectedAgeRange"].ToString();

            //Find Age record in database by Age Range
            ageTemp = (from a in mdolEntities.Ages
                       where a.AgeRange.ToLower().Equals(selectedAgeRange.ToLower())
                       select a).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: DeleteAge()]";
            ExceptionsSaver(str);
        }

        if (ageTemp != null)
        {
            try
            {
                //Delete Age Record
                mdolEntities.Ages.Remove(ageTemp);
                mdolEntities.SaveChanges();

                lblAgeMessage.Text = null;
                txNewAgeRange.Value = null;

                LoadAge();
                LoadAnimalItems();
            }
            catch (Exception ex)
            {
                lblAgeMessage.Text = "This Age cannot be deleted because some records are connected to this Age.";
            }
        }
        
    }
    private void DeleteAnimal()
    {
        
        Animal animaTemp = null;
        Animal temp = null;
        try
        {
            animaTemp = (Animal)Session["animalTemp"];

            //Find Animal
            temp = (from a in mdolEntities.Animals
                    where a.AnimalID == animaTemp.AnimalID
                    select a).FirstOrDefault();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: DeleteAnimal()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Delete Animal
            mdolEntities.Animals.Remove(temp);
            mdolEntities.SaveChanges();

            lblAnimalMessage.Text = null;

            LoadAnimalItems();
        }
        catch (Exception ex)
        {
            lblAnimalMessage.Text = "This Animal cannot be deleted because some records are connected to this Animal.";
        }
    }


    private void LoadSpecies()
    {
        try
        {
            //lblSpeciesMessage.Text = null;

            //Get all Species from Database
            var species = from s in mdolEntities.Species
                          select s;

            //Clear drop down list
            ddlShowSpecies.Items.Clear();

            //Load Species into drow down list
            foreach (var s in species)
            {
                ddlShowSpecies.Items.Add(s.SpeciesName);
            }

            //On Item selected from Drop Down List get Item value "Species Name"
            string selectedSpeciesName = ddlShowSpecies.SelectedItem.Value.ToString();
            txNewSpeciesName.Value = selectedSpeciesName;

            Session["selectedSpeciesName"] = selectedSpeciesName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: LoadSpecies()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadTypes()
    {
        try
        {
            //lblTypeMessage.Text = null;

            //Get all Types from Database
            var types = from t in mdolEntities.Types
                        select t;

            //Clear drop down list
            ddlShowTypes.Items.Clear();

            //Load Types into drow down list
            foreach (var t in types)
            {
                ddlShowTypes.Items.Add(t.TypeName);
            }

            //On Item selected from Drop Down List get Item value "Type Name"
            string selectedTypeName = ddlShowTypes.SelectedItem.Value.ToString();
            txNewTypeName.Value = selectedTypeName;

            Session["selectedTypeName"] = selectedTypeName;
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: LoadTypes()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadGender()
    {
        try
        {
            //lblGenderMessage.Text = null;

            //Get all Gender from Database
            var gender = from g in mdolEntities.Genders
                         select g;

            //Clear drop down list
            ddlShowGender.Items.Clear();

            //Load Gender into drow down list
            foreach (var g in gender)
            {
                ddlShowGender.Items.Add(g.GenderName);
            }

            //On Item selected from Drop Down List get Item value "Gender Name"
            string selectedGenderName = ddlShowGender.SelectedItem.Value.ToString();
            txNewGenderName.Value = selectedGenderName;

            Session["selectedGenderName"] = selectedGenderName;
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: LoadGender()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadAge()
    {
        try
        {
            //lblAgeMessage.Text = null;

            //Get all Age from Database
            var age = from a in mdolEntities.Ages
                      orderby a.AgeRange
                      select a;

            //Clear drop down list
            ddlShowAge.Items.Clear();

            //Load Age into drow down list
            foreach (var g in age)
            {
                ddlShowAge.Items.Add(g.AgeRange);
            }

            //On Item selected from Drop Down List get Item value "Age Range"
            string selectedAgeRange = ddlShowAge.SelectedItem.Value.ToString();
            txNewAgeRange.Value = selectedAgeRange;

            Session["selectedAgeRange"] = selectedAgeRange;
        }
        catch (Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: LoadAge()]";
            ExceptionsSaver(str);
        }
    }
    private void LoadAnimalItems()
    {
        Animal animalTemp = null;

        try
        {

            //lblAnimalMessage.Text = null;

            string countryName = null;
            string stateName = null;
            string countyName = null;

            string speciesName = null;
            string typeName = null;
            string genderName = null;
            string ageRange = null;

            //=======================================================================//
            //Get all Origins, Species, Types, Genders, Ages records from DB
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

            //Load all Origins, Species, Types, Genders, Ages records into Drop Down Lists
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

            //Get all Animals
            var animals = from a in mdolEntities.Animals
                          select a;

            //Load all Animal records into Drop Down Lists
            ddlShowAnimals.Items.Clear();
            foreach (var a in animals)
            {
                ddlShowAnimals.Items.Add(a.Origin.Country.CountryName + "; " + a.Origin.State.StateName + "; " + a.Origin.County.CountyName + "; " + a.Species.SpeciesName + "; " + a.Type.TypeName + "; " + a.Gender.GenderName + "; " + a.Age.AgeRange);
            }
            //=======================================================================//

            //Get previously selected or new "created" Animal from Session
            //and make selection in ddlShowAnimals
            animalTemp = (Animal)Session["animalTemp"];
            string selectedAnimalItem;

            if (animalTemp == null)
            {
                selectedAnimalItem = ddlShowAnimals.SelectedItem.Value.ToString();
            }
            else
            {
                ddlShowAnimals.SelectedIndex = ddlShowAnimals.Items.IndexOf(ddlShowAnimals.Items.FindByValue(animalTemp.Origin.Country.CountryName + "; " + animalTemp.Origin.State.StateName + "; " + animalTemp.Origin.County.CountyName + "; " + animalTemp.Species.SpeciesName + "; " + animalTemp.Type.TypeName + "; " + animalTemp.Gender.GenderName + "; " + animalTemp.Age.AgeRange));
                selectedAnimalItem = ddlShowAnimals.SelectedItem.Value.ToString();
            }

            //Split Text from ddlShowAnimals
            //=====================================================================//
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

            //Display Specie, Type, Gender and Age in Drop Down Lists
            //based on what was selected in ddlShowAnimals
            ddlSpecies.SelectedIndex = ddlSpecies.Items.IndexOf(ddlSpecies.Items.FindByValue(speciesName));
            ddlTypes.SelectedIndex = ddlTypes.Items.IndexOf(ddlTypes.Items.FindByValue(typeName));
            ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByValue(genderName));
            ddlAge.SelectedIndex = ddlAge.Items.IndexOf(ddlAge.Items.FindByValue(ageRange));


            //Find Specie, Type, Gender and Age based on what was selected in ddlShowAnimals
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

            //Display Origin in Drop Down Lists
            //based on what was selected in ddlShowAnimals
            ddlOrigins.SelectedIndex = ddlOrigins.Items.IndexOf(ddlOrigins.Items.FindByValue(animalTemp.Origin.Country.CountryName + "; " + animalTemp.Origin.State.StateName + "; " + animalTemp.Origin.County.CountyName));

            Session["animalTemp"] = animalTemp;
        }
        catch (Exception ex)
        {
            string str = "[1] Exaption in the: {Animal Class}: [Method: LoadAnimalItems()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Get all Requirements thet connected to the selected Animal
            HashSet<string> animalRequirementsList = new HashSet<string>();
            var animalRequirements = from ar in mdolEntities.AnimalRequirements
                                     where ar.AnimalID == animalTemp.AnimalID
                                     select ar;
            foreach (var ar in animalRequirements)
            {
                animalRequirementsList.Add(ar.Requirement.Name);
            }

            //Count Requirements thet connected to the selected Animal
            int counter = 0;
            counter = animalRequirementsList.Count;
            Label78.Text = "";
            Label78.Text = "This Animal has: " + counter + " Requirements";
        }
        catch (Exception ex)
        {
            string str = "[2] Exaption in the: {Animal Class}: [Method: LoadAnimalItems()]";
            ExceptionsSaver(str);
        }
    }
    protected void SelectSpecificAnimal()
    {
        Animal animalTemp = null;

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

            //Get Specie, Type, Gender and Age from drop down lists
            sSpecies = ddlSpecies.SelectedValue.ToString();
            sType = ddlTypes.SelectedValue.ToString();
            sGender = ddlGender.SelectedValue.ToString();
            sAge = ddlAge.SelectedValue.ToString();


            //Find Specie, Type, Gender and Age based on what was selected in ddlShowAnimals
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


            //Find Animal
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
                if (Session["animalTemp"] != null)
                {
                    animalTemp = (Animal)Session["animalTemp"];
                    lblNoAnimal.Text = "No such Animal in the Database.";
                }
            }
            else
            {
                //Select Animal in Drop Down List based on record [first record] that was found in DB
                ddlShowAnimals.SelectedIndex = ddlShowAnimals.Items.IndexOf(ddlShowAnimals.Items.FindByValue(sCountryName + "; " + sStateName + "; " + sCountyName + "; " + sSpecies + "; " + sType + "; " + sGender + "; " + sAge));
            }

            Session["animalTemp"] = animalTemp;
        }
        catch (Exception ex)
        {
            string str = "[1] Exaption in the: {Animal Class}: [Method: SelectSpecificAnimal()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Get all Requirements thet connected to the selected Animal
            //HashSet is used to count amount of requirements
            HashSet<string> animalRequirementsList = new HashSet<string>();
            var animalRequirements = from ar in mdolEntities.AnimalRequirements
                                     where ar.AnimalID == animalTemp.AnimalID
                                     select ar;
            foreach (var ar in animalRequirements)
            {
                animalRequirementsList.Add(ar.Requirement.Name);
            }
            int counter = 0;

            //Count Requirements thet connected to the selected Animal
            counter = animalRequirementsList.Count;
            Label78.Text = "";
            Label78.Text = "This Animal has: " + counter + " Requirements";
        }
        catch (Exception ex)
        {
            string str = "[2] Exaption in the: {Animal Class}: [Method: SelectSpecificAnimal()]";
            ExceptionsSaver(str);
        }
    }



    //Animal Part
    //####################################################################################//
    //Add, Update, Delete Species
    //==========================================================================//
    protected void bAddSpecies_Click(object sender, EventArgs e)
    {
        lblSpeciesMessage.Text = null;
        AddSpecies();
    }
    protected void ddlShowSpecies_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblSpeciesMessage.Text = null;

            //On Item selected from Drop Down List get Item value "Specie Name"
            string selectedSpeciesName = ddlShowSpecies.SelectedItem.Value.ToString();
            txNewSpeciesName.Value = selectedSpeciesName;

            Session["selectedSpeciesName"] = selectedSpeciesName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: ddlShowSpecies_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateSpecies_Click(object sender, EventArgs e)
    {
        lblSpeciesMessage.Text = null;
        UpdateSpecies();
    }
    protected void bDeleteSpecies_Click(object sender, EventArgs e)
    {
        lblSpeciesMessage.Text = null;
        DeleteSpecies();
    }
    //==========================================================================//

    //Add, Update, Delete Type
    //==========================================================================//
    protected void bAddType_Click(object sender, EventArgs e)
    {
        lblTypeMessage.Text = null;
        AddType();
    }
    protected void ddlShowTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblTypeMessage.Text = null;
            //On Item selected from Drop Down List get Item value "Type Name"
            string selectedTypeName = ddlShowTypes.SelectedItem.Value.ToString();
            txNewTypeName.Value = selectedTypeName;

            Session["selectedTypeName"] = selectedTypeName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: ddlShowTypes_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateType_Click(object sender, EventArgs e)
    {
        lblTypeMessage.Text = null;
        UpdateType();
    }
    protected void bDeleteType_Click(object sender, EventArgs e)
    {
        lblTypeMessage.Text = null;
        DeleteType();
    }
    //==========================================================================//

    //Add, Update, Delete Gender
    //==========================================================================//
    protected void bAddGender_Click(object sender, EventArgs e)
    {
        lblGenderMessage.Text = null;
        AddGender();
    }
    protected void ddlShowGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblGenderMessage.Text = null;

            //On Item selected from Drop Down List get Item value "Gender Name"
            string selectedGenderName = ddlShowGender.SelectedItem.Value.ToString();
            txNewGenderName.Value = selectedGenderName;

            Session["selectedGenderName"] = selectedGenderName;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: ddlShowGender_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateGender_Click(object sender, EventArgs e)
    {
        lblGenderMessage.Text = null;
        UpdateGender();
    }
    protected void bDeleteGender_Click(object sender, EventArgs e)
    {
        lblGenderMessage.Text = null;
        DeleteGender();
    }
    //==========================================================================//

    //Add, Update, Delete Age
    //==========================================================================//
    protected void bAddAge_Click(object sender, EventArgs e)
    {
        lblAgeMessage.Text = null;
        AddAge();
    }
    protected void ddlShowAge_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblAgeMessage.Text = null;

            //On Item selected from Drop Down List get Item value "Age Range"
            string selectedAgeRange = ddlShowAge.SelectedItem.Value.ToString();
            txNewAgeRange.Value = selectedAgeRange;

            Session["selectedAgeRange"] = selectedAgeRange;
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Animal Class}: [Method: ddlShowAge_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateAge_Click(object sender, EventArgs e)
    {
        lblAgeMessage.Text = null;
        UpdateAge();
    }
    protected void bDeleteAge_Click(object sender, EventArgs e)
    {
        lblAgeMessage.Text = null;
        DeleteAge();
    }
    //==========================================================================//

    //Add, Update, Delete Animal
    //==========================================================================//
    protected void bAddAnimal_Click(object sender, EventArgs e)
    {
        lblNoAnimal.Text = null;
        lblAnimalMessage.Text = null;
        AddAnimal();
    }
    protected void ddlShowAnimals_SelectedIndexChanged(object sender, EventArgs e)
    {
        Animal animaTemp = null;
        try
        {
            lblNoAnimal.Text = null;
            lblAnimalMessage.Text = null;

            string countryName = null;
            string stateName = null;
            string countyName = null;

            string speciesName = null;
            string typeName = null;
            string genderName = null;
            string ageRange = null;

            //##########################################################################//
            //Split Text from ddlShowAnimals
            //=====================================================================//
            string selectedAnimalItem = ddlShowAnimals.SelectedItem.Value.ToString();

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
            //=====================================================================//

            //Display Species, Type, Gender and Age in Drop Down Lists
            //based on what was selected in ddlShowAnimals
            ddlSpecies.SelectedIndex = ddlSpecies.Items.IndexOf(ddlSpecies.Items.FindByValue(speciesName));
            ddlTypes.SelectedIndex = ddlTypes.Items.IndexOf(ddlTypes.Items.FindByValue(typeName));
            ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByValue(genderName));
            ddlAge.SelectedIndex = ddlAge.Items.IndexOf(ddlAge.Items.FindByValue(ageRange));

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
            animaTemp = (from a in mdolEntities.Animals
                         where a.Origin.Country.CountryName.ToLower().Equals(countryName.ToLower()) &&
                         a.Origin.State.StateName.ToLower().Equals(stateName.ToLower()) &&
                         a.Origin.County.CountyName.ToLower().Equals(countyName.ToLower()) &&
                         a.SpeciesID == speciesTemp.SpeciesID &&
                         a.TypeID == typeTemp.TypeID &&
                         a.GenderID == genderTemp.GenderID &&
                         a.AgeID == ageTemp.AgeID
                         select a).FirstOrDefault();

            //Display Origin in Drop Down Lists
            //based on what was selected in ddlShowAnimals
            ddlOrigins.SelectedIndex = ddlOrigins.Items.IndexOf(ddlOrigins.Items.FindByValue(animaTemp.Origin.Country.CountryName + "; " + animaTemp.Origin.State.StateName + "; " + animaTemp.Origin.County.CountyName));

            Session["animalTemp"] = animaTemp;
            //##########################################################################//
        }
        catch(Exception ex)
        {
            string str = "[1] Exaption in the: {Animal Class}: [Method: ddlShowAnimals_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }

        try
        {
            //Get all Requirements thet connected to the selected Animal
            HashSet<string> animalRequirementsList = new HashSet<string>();
            var animalRequirements = from ar in mdolEntities.AnimalRequirements
                                     where ar.AnimalID == animaTemp.AnimalID
                                     select ar;
            foreach (var ar in animalRequirements)
            {
                animalRequirementsList.Add(ar.Requirement.Name);
            }

            //Count Requirements thet connected to the selected Animal
            int counter = 0;
            counter = animalRequirementsList.Count;
            Label78.Text = "";
            Label78.Text = "This Animal has: " + counter + " Requirements";
        }
        catch (Exception ex)
        {
            string str = "[2] Exaption in the: {Animal Class}: [Method: ddlShowAnimals_SelectedIndexChanged()]";
            ExceptionsSaver(str);
        }
    }
    protected void bUpdateAnimal_Click(object sender, EventArgs e)
    {
        lblNoAnimal.Text = null;
        lblAnimalMessage.Text = null;
        UpdateAnimal();
    }
    protected void bDeleteAnimal_Click(object sender, EventArgs e)
    {
        lblNoAnimal.Text = null;
        lblAnimalMessage.Text = null;
        DeleteAnimal();
    }

    protected void bFindAnimal_Click(object sender, EventArgs e)
    {
        try
        {
            lblNoAnimal.Text = null;
            lblAnimalMessage.Text = null;

            //=========================================================================//
            //Get Selected Origin item from Drop Down List
            string sOrigin = ddlOrigins.SelectedValue.ToString();

            string sCountryName = null;
            string sStateName = null;
            string sCountyName = null;

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

            Session["sCountryName"] = sCountryName;
            Session["sStateName"] = sStateName;
            Session["sCountyName"] = sCountyName;
            //=========================================================================//

            //=========================================================================//
            string sSpecies = ddlSpecies.SelectedValue.ToString();
            Session["sSpecies"] = sSpecies;
            //=========================================================================//

            //=========================================================================//
            string sType = ddlTypes.SelectedValue.ToString();
            Session["sType"] = sType;
            //=========================================================================//

            //=========================================================================//
            string sGender = ddlGender.SelectedValue.ToString();
            Session["sGender"] = sGender;
            //=========================================================================//

            //=========================================================================//
            string sAge = ddlAge.SelectedValue.ToString();
            Session["sAge"] = sAge;
            //=========================================================================//

            SelectSpecificAnimal();
        }
        catch(Exception ex)
        {
            string str = "Exaption in the: {Origin Class}: [Method: AddCountry()]";
            ExceptionsSaver(str);
        }
    }


    //If some Exception occurs this method will be called, an Exception will be 
    //added into List after, this List will be saved in the Session.
    //In addition, all Exception will be displayed in the Drop Down Box
    private void ExceptionsSaver(string str)
    {
        if (Session["AnimalExceptionList"] != null)
        {
            exceptionList = (List<string>)Session["AnimalExceptionList"];
            exceptionList.Add(str);

            exceptionsTable.Visible = true;

            lbExceptions.Items.Clear();
            foreach (string s in exceptionList)
            {
                lbExceptions.Items.Add(s);
            }

            Session["AnimalExceptionList"] = exceptionList;
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

            Session["AnimalExceptionList"] = exceptionList;
        }
    }
    //==========================================================================//
    //####################################################################################//
}