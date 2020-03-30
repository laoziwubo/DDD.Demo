using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Mapping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnType("varchar(100)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .HasColumnType("datetime");

            builder.OwnsOne(p => p.Address);
        }
    }
}
