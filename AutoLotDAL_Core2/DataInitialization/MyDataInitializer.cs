﻿using AutoLotDAL_Core2.EF;
using AutoLotDAL_Core2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace AutoLotDAL_Core2.DataInitialization
{
    public static class MyDataInitializer
    {
        public static void InitializeData(AutoLotContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {FirstName = "Dave", LastName = "Brenner"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Bad", LastName = "Customer"}
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
            var cars = new List<Inventory>
            {

                new Inventory {Make = "VW", Color = "Black", PetName = "Zippy" },
                new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
                new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
                new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
                new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
                new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
                new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
                new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
                new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();
            var orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0] } ,
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
        public static void RecreateDatabase(AutoLotContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }
        public static void ClearData(AutoLotContext context)
        {
            ExecuteDeleteSql(context, "Orders");
            ExecuteDeleteSql(context, "Customers");
            ExecuteDeleteSql(context, "Inventory");
            ResetIdentity(context);
        }
        public static void ExecuteDeleteSql(AutoLotContext context, string tableName)
        {
            context.Database.ExecuteSqlInterpolated($"Delete from dbo.{tableName}");
        }
        public static void ResetIdentity(AutoLotContext context)
        {
            var tables = new[] { "Inventory", "Orders", "Customers"};
            foreach (var itm in tables)
            {
                context.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT (\"dbo.{itm}\", RESEED, -1);");
            }
        }
    }
}
