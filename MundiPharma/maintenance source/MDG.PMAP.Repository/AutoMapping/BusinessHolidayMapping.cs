using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Repository.AutoMapping
{
    public class BusinessHolidayMapping : EntityTypeConfiguration<BusinessHoliday>
    {
        public BusinessHolidayMapping()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.HolidayDate)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("BusinessHolidays");
            this.Property(t => t.Id).HasColumnName("BusinessHolidayId");
            this.Property(t => t.HolidayDate).HasColumnName("HolidayDate");
        }
    }
}
