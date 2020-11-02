using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.Choices;

namespace OnlineExam.Infrastructures.DataLayer.Choices
{
    internal class ChoiceConfig : IEntityTypeConfiguration<Choice>
    {


        public void Configure(EntityTypeBuilder<Choice> builder)
        {

        }
    }
}
