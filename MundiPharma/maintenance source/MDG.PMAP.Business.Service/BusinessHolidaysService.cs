using MDG.PMAP.Entity;
using MDG.Repository.Pattern.Repositories;
using MDG.Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Business.Service
{
    public class BusinessHolidaysService : IBusinessHolidaysService
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly IRepositoryAsync<BusinessHoliday> BusinessHolidayRepository;

        public BusinessHolidaysService(IUnitOfWorkAsync unitOfWork,
            IRepositoryAsync<BusinessHoliday> businessHolidayRepository)
        {
            UnitOfWork = unitOfWork;
            BusinessHolidayRepository = businessHolidayRepository;
        }


        public List<BusinessHoliday> GetBusinessHolidays()
        {
            return BusinessHolidayRepository.Queryable().ToList();
        }

        public async Task<BusinessHoliday> InsertBusinessHoliday(BusinessHoliday dateofHoliday)
        {
            dateofHoliday.Id = 0;

            BusinessHolidayRepository.Insert(dateofHoliday);
            
            await UnitOfWork.SaveChangesAsync();
            return dateofHoliday;
        }

        public async Task<bool> DeleteBusinessHoliday(int holidayId)
        {
            var entity = GetHolidayId(holidayId);
            BusinessHolidayRepository.Delete(entity);
            await UnitOfWork.SaveChangesAsync();

            return true;
        }

        private BusinessHoliday GetHolidayId(int id)
        {
            var resultList = BusinessHolidayRepository.Queryable().Where(x => x.Id == id).ToList();
            var result = new BusinessHoliday() { Id = 0, HolidayDate = DateTime.Now };

            if (resultList.Count > 0)
            {
                result = resultList[0];
            }

            return result;
        }

        public BusinessHoliday GetBusinessHolidayById(int holidayId)
        {
            return this.GetHolidayId(holidayId);
        }

        public async Task<BusinessHoliday> UpdateBusinessHoliday(BusinessHoliday dateofHoliday)
        {
            var holiday = GetHolidayId(dateofHoliday.Id);
            holiday.HolidayDate = dateofHoliday.HolidayDate;
            BusinessHolidayRepository.Update(holiday);
            await UnitOfWork.SaveChangesAsync();

            return dateofHoliday;

        }
    } 
}
