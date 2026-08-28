using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Repository.AutoMapping
{
    public class EmailTemplateMapping : EntityTypeConfiguration<EmailTemplate>
    { 
        public EmailTemplateMapping()
        {
            // Primary Key
            this.HasKey(t => t.TemplateCode);

            // Properties
            this.Property(t => t.Subject)
                .IsRequired();

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EmailTemplate");
            this.Property(t => t.TemplateCode).HasColumnName("TemplateCode");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Body).HasColumnName("Body");
        }
    }
}
