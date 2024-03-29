﻿// <auto-generated />
using System;
using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auth.API.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientId", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientInformationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientPasswordId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientInformationId")
                        .IsUnique();

                    b.HasIndex("ClientPasswordId")
                        .IsUnique();

                    b.ToTable("ClientIds");
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("boolean");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClientInformations");
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("ClientPasswords");
                });

            modelBuilder.Entity("Auth.Domain.Entities.EntityAggregate.ClientRole", b =>
                {
                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("ClientId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("clientRoles");
                });

            modelBuilder.Entity("Auth.Domain.Entities.RoleAggregate.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ClientIdRole", b =>
                {
                    b.Property<Guid>("ClientIdsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.HasKey("ClientIdsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("ClientIdRole");
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientId", b =>
                {
                    b.HasOne("Auth.Domain.Entities.ClientAggregate.ClientInformation", "ClientInformation")
                        .WithOne("Client")
                        .HasForeignKey("Auth.Domain.Entities.ClientAggregate.ClientId", "ClientInformationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Auth.Domain.Entities.ClientAggregate.ClientPassword", "ClientPassword")
                        .WithOne("Client")
                        .HasForeignKey("Auth.Domain.Entities.ClientAggregate.ClientId", "ClientPasswordId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Auth.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClientIdId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(256)
                                .IsUnicode(false)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("Email");

                            b1.HasKey("ClientIdId");

                            b1.HasIndex("Address")
                                .IsUnique();

                            b1.ToTable("ClientIds");

                            b1.WithOwner()
                                .HasForeignKey("ClientIdId");
                        });

                    b.Navigation("ClientInformation");

                    b.Navigation("ClientPassword");

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientInformation", b =>
                {
                    b.OwnsOne("Auth.Domain.Entities.ClientAggregate.Enums.EGender", "Gender", b1 =>
                        {
                            b1.Property<Guid>("ClientInformationId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .HasColumnType("integer")
                                .HasColumnName("Gender");

                            b1.HasKey("ClientInformationId");

                            b1.ToTable("ClientInformations");

                            b1.WithOwner()
                                .HasForeignKey("ClientInformationId");
                        });

                    b.Navigation("Gender")
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.Domain.Entities.EntityAggregate.ClientRole", b =>
                {
                    b.HasOne("Auth.Domain.Entities.ClientAggregate.ClientId", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Auth.Domain.Entities.RoleAggregate.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ClientIdRole", b =>
                {
                    b.HasOne("Auth.Domain.Entities.ClientAggregate.ClientId", null)
                        .WithMany()
                        .HasForeignKey("ClientIdsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Auth.Domain.Entities.RoleAggregate.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientInformation", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientAggregate.ClientPassword", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
