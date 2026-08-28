using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Repository.AutoMapping
{
    public class RAFStatusTableMapping : EntityTypeConfiguration<RAFStatusTable>
    {
        public RAFStatusTableMapping()
        {
            // Primary Key
            this.HasKey(t => t.RAFStatusId);

            // Properties
            this.Property(t => t.StatusType)
                .IsRequired();


            // Table & Column Mappings
            this.ToTable("RAFStatus");
            this.Property(t => t.RAFStatusId).HasColumnName("RAFStatusId");
            this.Property(t => t.StatusCode).HasColumnName("StatusCode");
            this.Property(t => t.StatusType).HasColumnName("StatusType");
        }
    }
}
