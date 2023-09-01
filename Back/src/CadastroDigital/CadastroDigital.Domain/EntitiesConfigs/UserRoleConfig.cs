using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using CadastroDigital.Domain.Entities;
using CadastroDigital.Domain.Identity;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class UserRoleConfig: IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole>builder){

            //Tabela
            builder.ToTable("UserRole");
            
            //Primary Key
            builder.HasKey(p => new {p.UserId, p.RoleId});

            //Foreign Key
            builder.HasOne(f => f.User)
            .WithMany(f => f.UserRoles)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("fk_user_role")
            .IsRequired();

            builder.HasOne(f => f.Role)
            .WithMany(f => f.UserRoles)
            .HasForeignKey(f => f.RoleId)
            .HasConstraintName("fk_role_user")
            .IsRequired();
            
        }
    }
}