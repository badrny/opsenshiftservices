using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BiblioWebServicesCore.Model;

namespace BiblioWebServicesCore.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20170828193510_InitDataBook")]
    partial class InitDataBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BiblioWebServicesCore.Model.Book", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("CoverSrc");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Format");

                    b.Property<bool>("IsRead");

                    b.Property<string>("Note");

                    b.Property<string>("Title");

                    b.HasKey("Key");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BiblioWebServicesCore.Model.BookType", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BookID");

                    b.Property<long>("TypeID");

                    b.HasKey("Key");

                    b.HasIndex("BookID");

                    b.HasIndex("TypeID");

                    b.ToTable("BookType");
                });

            modelBuilder.Entity("BiblioWebServicesCore.Model.Type", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Key");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("BiblioWebServicesCore.Model.BookType", b =>
                {
                    b.HasOne("BiblioWebServicesCore.Model.Book", "Book")
                        .WithMany("Types")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BiblioWebServicesCore.Model.Type", "Type")
                        .WithMany("Types")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
