using MDG.Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Entity
{
    public class BusinessHoliday : EfEntity
    {
        public int Id { get; set; }
        [NotMapped]
        public int Year
        {
            get
            {
                return HolidayDate.Year;
            }
        }
        [NotMapped]
        public int Day
        {
            get
            {
                return HolidayDate.Day;
            }
        }
        [NotMapped]
        public int Month
        {
            get { return HolidayDate.Month; }
        }
        public DateTime HolidayDate { get; set; }
    }
}
