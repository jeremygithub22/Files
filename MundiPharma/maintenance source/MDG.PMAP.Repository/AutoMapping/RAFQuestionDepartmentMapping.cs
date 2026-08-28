using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Repository.AutoMapping
{
    public class RAFQuestionDepartmentMapping : EntityTypeConfiguration<RAFQuestionDepartment>
    {
        public RAFQuestionDepartmentMapping()
        {
            this.HasKey(x => x.QuestionDepartmentId);

            // Properties
            this.Property(t => t.Question)
                .IsRequired();

            this.Property(t => t.DepartmentCode)
                .IsRequired();

            this.ToTable("RAF_QuestionDepartment");
            this.Property(x => x.QuestionDepartmentId).HasColumnName("QuestionDepartmentId");
            this.Property(x => x.Question).HasColumnName("Question");
            this.Property(x => x.DepartmentCode).HasColumnName("DepartmentCode");
            this.Property(x => x.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(x => x.SubGroupTypeCode).HasColumnName("SubGroupTypeCode");
        }
    }
}
