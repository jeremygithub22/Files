using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Repository.AutoMapping
{
    public class ProductSubGroupMapping : EntityTypeConfiguration<ProductSubGroup>
    {
        public ProductSubGroupMapping()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SubGroupTypeCode)
                .IsRequired();

            this.Property(t => t.ProductCode)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ProductSubGroup");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SubGroupTypeCode).HasColumnName("SubGroupTypeCode");
            this.Property(t => t.ProductCode).HasColumnName("ProductCode");
        }
    }
}
