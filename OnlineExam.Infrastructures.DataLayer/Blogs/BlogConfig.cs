using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Blogs
{
    internal class BlogConfig : IEntityTypeConfiguration<Blog>
    {

        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasOne(b => b.Course)
        .WithMany(c => c.Blogs)
        .HasForeignKey(c => c.CourseId)
        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
