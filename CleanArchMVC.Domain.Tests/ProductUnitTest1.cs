using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid Parameters Result Object Valid State")]
        public void Create_Product_With_Valid_Parameters_Result_Object_Valid_State()
        {
            Action action = () => new Product(1, "Product 1", "New Product", 50.0m, 10, "produc_1_image.png");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product Negative Id Valid Parameters Result Object Valid State")]
        public void Create_Product_Negative_Id_Valid_Parameters_Result_Object_Valid_State()
        {
            Action action = () => new Product(-1, "Product 1", "New Product", 50.0m, 10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product Short Name Value Domain Exception Short Name")]
        public void Create_Product_Short_Name_Value_Domain_Exception_Short_Name()
        {
            Action action = () => new Product(1, "Pr", "New Product", 50.0m, 10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name is too short, minimun 3 charecters.");
        }

        [Fact(DisplayName = "Create Product Missing Name Value Domain Exception Required Name")]
        public void Create_Product_Missing_Name_Value_Domain_Exception_Required_Name()
        {
            Action action = () => new Product(1, "", "New Product", 50.0m, 10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name is required.");
        }

        [Fact(DisplayName = "Create Product With Null Description Value Domain Exception Invalid Description")]
        public void Create_Product_With_Null_Description_Value_Domain_Exception_Invalid_Name()
        {
            Action action = () => new Product(1, "Product 1", null, 50.0m, 10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product Short Description Value Domain Exception Short Description")]
        public void Create_Product_Short_Description_Value_Domain_Exception_Short_Description()
        {
            Action action = () => new Product(1, "Product 1", "New", 50.0m, 10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description is too short, minimun 3 charecters.");
        }

        [Fact(DisplayName = "Create Product Price Invalid Value Domain Exception Price")]
        public void Create_Product_Price_Invalid_Value_Domain_Exception_Price()
        {
            Action action = () => new Product(1, "Product 1", "New Product 1", -1, 10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Create Product Stock Invalid Value Domain Exception Stock")]
        public void Create_Product_Stock_Invalid_Value_Domain_Exception_Stock()
        {
            Action action = () => new Product(1, "Product 1", "New Product 1", 50.0m, -10, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Theory(DisplayName = "CreateProduct Invalid Stock Value Exception Domain Negative Value")]
        [InlineData(-5)]
        public void CreateProduct_Invalid_Stock_Value_Exception_Domain_Negative_Value(int value)
        {
            Action action = () => new Product(1, "Product 1", "New Product 1", 50.0m, value, "produc_1_image.png");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Fact(DisplayName = "Create Product Missing Image Value Domain Exception Required Image")]
        public void Create_Product_Missing_Image_Value_Domain_Exception_Required_Image()
        {
            Action action = () => new Product(1, "Product 1", "New Product", 50.0m, 10, "");
            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Value Domain Exception Invalid Image")]
        public void Create_Product_With_Null_Image_Value_Domain_Exception_Invalid_Image()
        {
            Action action = () => new Product(1, "Product 1", "New Product 1", 50.0m, 10, null);
            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Value Null Reference Exception Image")]
        public void Create_Product_With_Null_Image_Value_Null_Reference_Exception_Image()
        {
            Action action = () => new Product(1, "Product 1", "New Product 1", 50.0m, 10, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create_Product_Short_Image_Value_Domain_Exception_Short_Image")]
        public void Create_Product_Short_Image_Value_Domain_Exception_Short_Image()
        {
            Action action = () => new Product(1, "Product 1", "New Product 1", 50.0m, 10, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximun 250 caracters.");
        }
    }
}
