﻿namespace CleanArchMVC.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }

        public ProductUpdateCommand(int id)
        {
            Id = id;
        }
    }
}