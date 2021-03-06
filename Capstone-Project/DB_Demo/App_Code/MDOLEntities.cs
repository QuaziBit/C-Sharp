﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Age
{
    public Age()
    {
        this.Animals = new HashSet<Animal>();
    }

    public int AgeID { get; set; }
    public string AgeRange { get; set; }

    public virtual ICollection<Animal> Animals { get; set; }
}

public partial class Animal
{
    public Animal()
    {
        this.AnimalRequirements = new HashSet<AnimalRequirement>();
    }

    public int AnimalID { get; set; }
    public int GenderID { get; set; }
    public int TypeID { get; set; }
    public int SpeciesID { get; set; }
    public int AgeID { get; set; }
    public int OriginID { get; set; }

    public virtual Age Age { get; set; }
    public virtual ICollection<AnimalRequirement> AnimalRequirements { get; set; }
    public virtual Gender Gender { get; set; }
    public virtual Origin Origin { get; set; }
    public virtual Species Species { get; set; }
    public virtual Type Type { get; set; }
}

public partial class AnimalRequirement
{
    public int Animal_ReqID { get; set; }
    public int AnimalID { get; set; }
    public int RequirementID { get; set; }

    public virtual Animal Animal { get; set; }
    public virtual Requirement Requirement { get; set; }
}

public partial class Country
{
    public Country()
    {
        this.Origins = new HashSet<Origin>();
    }

    public int CountryID { get; set; }
    public string CountryName { get; set; }

    public virtual ICollection<Origin> Origins { get; set; }
}

public partial class County
{
    public County()
    {
        this.Origins = new HashSet<Origin>();
    }

    public int CountyID { get; set; }
    public string CountyName { get; set; }

    public virtual ICollection<Origin> Origins { get; set; }
}

public partial class Gender
{
    public Gender()
    {
        this.Animals = new HashSet<Animal>();
    }

    public int GenderID { get; set; }
    public string GenderName { get; set; }

    public virtual ICollection<Animal> Animals { get; set; }
}

public partial class Origin
{
    public Origin()
    {
        this.Animals = new HashSet<Animal>();
    }

    public int OriginID { get; set; }
    public int CountryID { get; set; }
    public int StateID { get; set; }
    public int CountyID { get; set; }

    public virtual ICollection<Animal> Animals { get; set; }
    public virtual Country Country { get; set; }
    public virtual County County { get; set; }
    public virtual State State { get; set; }
}

public partial class Requirement
{
    public Requirement()
    {
        this.AnimalRequirements = new HashSet<AnimalRequirement>();
    }

    public int RequirementID { get; set; }
    public int ReqType_ID { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public string Text { get; set; }
    public string HTML { get; set; }

    public virtual ICollection<AnimalRequirement> AnimalRequirements { get; set; }
    public virtual RequirementType RequirementType { get; set; }
}

public partial class RequirementType
{
    public RequirementType()
    {
        this.Requirements = new HashSet<Requirement>();
    }

    public int ReqType_ID { get; set; }
    public string Type { get; set; }

    public virtual ICollection<Requirement> Requirements { get; set; }
}

public partial class Species
{
    public Species()
    {
        this.Animals = new HashSet<Animal>();
    }

    public int SpeciesID { get; set; }
    public string SpeciesName { get; set; }

    public virtual ICollection<Animal> Animals { get; set; }
}

public partial class State
{
    public State()
    {
        this.Origins = new HashSet<Origin>();
    }

    public int StateID { get; set; }
    public string StateName { get; set; }

    public virtual ICollection<Origin> Origins { get; set; }
}

public partial class Type
{
    public Type()
    {
        this.Animals = new HashSet<Animal>();
    }

    public int TypeID { get; set; }
    public string TypeName { get; set; }

    public virtual ICollection<Animal> Animals { get; set; }
}

public partial class Vaccination
{
    public int VaccinationID { get; set; }
    public string VaccinationName { get; set; }
}
