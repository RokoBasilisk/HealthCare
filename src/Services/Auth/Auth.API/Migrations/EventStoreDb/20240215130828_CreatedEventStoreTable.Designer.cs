﻿// <auto-generated />
using System;
using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auth.API.Migrations.EventStoreDb
{
    [DbContext(typeof(EventStoreDbContext))]
    [Migration("20240215130828_CreatedEventStoreTable")]
    partial class CreatedEventStoreTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auth.Domain.Entities.ClientId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<string>("LoginId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClientId");
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

                    b.ToTable("Role");
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

            modelBuilder.Entity("Core.SharedKernel.EventBase", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClientIdId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedAt");

                    b.HasKey("AggregateId");

                    b.HasIndex("ClientIdId");

                    b.ToTable("EventBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EventBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Core.SharedKernel.EventStore", b =>
                {
                    b.HasBaseType("Core.SharedKernel.EventBase");

                    b.Property<string>("Data")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR(MAX)")
                        .HasComment("JSON serialized event");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasDiscriminator().HasValue("EventStore");
                });

            modelBuilder.Entity("ClientIdRole", b =>
                {
                    b.HasOne("Auth.Domain.Entities.ClientId", null)
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

            modelBuilder.Entity("Core.SharedKernel.EventBase", b =>
                {
                    b.HasOne("Auth.Domain.Entities.ClientId", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("ClientIdId");
                });

            modelBuilder.Entity("Auth.Domain.Entities.ClientId", b =>
                {
                    b.Navigation("DomainEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
