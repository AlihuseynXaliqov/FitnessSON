﻿using System.Reflection;
using FitnessApp.Core;
using FitnessApp.Core.Blog;
using FitnessApp.Core.Cart;
using FitnessApp.Core.Class;
using FitnessApp.Core.Contact;
using FitnessApp.Core.FeedBack;
using FitnessApp.Core.Plan;
using FitnessApp.Core.Products;
using FitnessApp.Core.Trainer;
using FitnessApp.Core.User;
using FitnessApp.Core.Wish;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.DAL;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Classes> Classes { get; set; }
    public DbSet<TrainersClasses> TrainersClasses { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<ClientFeedBack> FeedBacks { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<PricingPlan> PricingPlans { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TagProduct> TagProducts { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}