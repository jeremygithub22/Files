using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Repository.AutoMapping
{
    public class RAFQuestionMapping: EntityTypeConfiguration<Entity.RAFQuestions>
    {
        public RAFQuestionMapping()
        {
            HasKey(x => x.QuestionId);

            ToTable("RAF_Questions");
            Property(x => x.QuestionId).HasColumnName("QuestionId");
            Property(x => x.Question).HasColumnName("Question");
            Property(x => x.IsActive).HasColumnName("IsActive");
        }
    }
}
