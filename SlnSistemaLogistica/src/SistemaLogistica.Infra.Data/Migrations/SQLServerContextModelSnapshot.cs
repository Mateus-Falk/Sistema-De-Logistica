// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaLogistica.Infra.Data.Context;

#nullable disable

namespace SistemaLogistica.Infra.Data.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    partial class SQLServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Suco"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Refrigerante"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cerveja"
                        });
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.InOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("InOrOut")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("InOut", t =>
                        {
                            t.HasTrigger("TGR_UPDATE_QUANTITY");
                        });
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighbourhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityMinimun")
                        .HasColumnType("int");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("PersonId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Client", b =>
                {
                    b.HasOne("SistemaLogistica.Domain.Entities.Person", "Person")
                        .WithMany("ClientList")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("SistemaLogistica.Domain.Entities.Person", "Person")
                        .WithMany("FornecedorList")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.InOut", b =>
                {
                    b.HasOne("SistemaLogistica.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("SistemaLogistica.Domain.Entities.Person", null)
                        .WithMany("InOutList")
                        .HasForeignKey("PersonId");

                    b.HasOne("SistemaLogistica.Domain.Entities.Product", "Product")
                        .WithMany("InOutList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Product", b =>
                {
                    b.HasOne("SistemaLogistica.Domain.Entities.Category", "Category")
                        .WithMany("ProductList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaLogistica.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.HasOne("SistemaLogistica.Domain.Entities.Person", null)
                        .WithMany("ProductList")
                        .HasForeignKey("PersonId");

                    b.Navigation("Category");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Category", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Person", b =>
                {
                    b.Navigation("ClientList");

                    b.Navigation("FornecedorList");

                    b.Navigation("InOutList");

                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("SistemaLogistica.Domain.Entities.Product", b =>
                {
                    b.Navigation("InOutList");
                });
#pragma warning restore 612, 618
        }
    }
}
