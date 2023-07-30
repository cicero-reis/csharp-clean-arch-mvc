using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid Parameters Result Object Valid State")]
        public void Create_Category_With_Valid_Parameters_Result_Object_Valid_State()
        {
            Action action = () => new Category(1, "Category One");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Negative Id Valid Parameters Result Object Valid State")]
        public void Create_Category_Negative_Id_Valid_Parameters_Result_Object_Valid_State()
        {
            Action action = () => new Category(-1, "Category One");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category Short Name Value Domain Exception Short Name")]
        public void Create_Category_Short_Name_Value_Domain_Exception_Short_Name()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name is too short, minimun 3 charecters.");
        }

        [Fact(DisplayName = "Create Category Missing Name Value Domain Exception Required Name")]
        public void Create_Category_Missing_Name_Value_Domain_Exception_Required_Name()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name is required.");
        }

        [Fact(DisplayName = "Create Category With Null Name Value Domain Exception Invalid Name")]
        public void Create_Category_With_Null_Name_Value_Domain_Exception_Invalid_Name()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
