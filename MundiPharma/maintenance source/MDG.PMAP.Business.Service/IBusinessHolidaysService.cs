using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Business.Service
{
    public interface IBusinessHolidaysService
    {
        List<BusinessHoliday> GetBusinessHolidays();
        Task<BusinessHoliday> InsertBusinessHoliday(BusinessHoliday dateofHoliday);
        Task<bool> DeleteBusinessHoliday(int holidayId);
        Task<BusinessHoliday> UpdateBusinessHoliday(BusinessHoliday dateofHoliday);
        BusinessHoliday GetBusinessHolidayById(int holidayId);
    }
}
