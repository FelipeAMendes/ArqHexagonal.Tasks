﻿using ArqHexagonal.Tasks.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqHexagonal.Tasks.Persistence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> TaskItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>()
                    .Property(t => t.Id)
                    .ValueGeneratedOnAdd();

        modelBuilder.Entity<TaskItem>()
                    .Property(t => t.Title)
                    .IsRequired()
                    .HasMaxLength(100);

        base.OnModelCreating(modelBuilder);
    }
}
