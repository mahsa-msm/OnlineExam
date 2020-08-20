using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Choices
{
    internal class ChoiceConfig : IEntityTypeConfiguration<Choice>
    {


        public void Configure(EntityTypeBuilder<Choice> builder)
        {

        }
    }
}
