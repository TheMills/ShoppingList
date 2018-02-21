﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShoppingList.API.Data;
using System;

namespace ShoppingList.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ShoppingList.API.Models.ListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ActiveOnList");

                    b.Property<string>("Name");

                    b.Property<int?>("ShopListId");

                    b.HasKey("Id");

                    b.HasIndex("ShopListId");

                    b.ToTable("ListItems");
                });

            modelBuilder.Entity("ShoppingList.API.Models.ShopList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("TimeCreated");

                    b.Property<DateTime>("TimeModified");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("ShoppingList.API.Models.ListItem", b =>
                {
                    b.HasOne("ShoppingList.API.Models.ShopList")
                        .WithMany("ListItems")
                        .HasForeignKey("ShopListId");
                });
#pragma warning restore 612, 618
        }
    }
}
