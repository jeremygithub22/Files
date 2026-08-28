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
    public class RAFStatusService : IRAFStatusService
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly IRepositoryAsync<RAFStatusTable> RAFStatusRepository;

        public RAFStatusService(IUnitOfWorkAsync unitOfWork,
            IRepositoryAsync<RAFStatusTable> rafStatusRepository)
        {
            UnitOfWork = unitOfWork;
            RAFStatusRepository = rafStatusRepository;
        }

        public List<RAFStatusTable> GetAllRAFStatus()
        {
            return RAFStatusRepository.Queryable().ToList();
        }

        public async Task<RAFStatusTable> InsertRAFStatus(RAFStatusTable rafStatus)
        {
            rafStatus.RAFStatusId = 0;
            RAFStatusRepository.Insert(rafStatus);
            await UnitOfWork.SaveChangesAsync();
            return rafStatus;
        }

        public async Task<bool> DeleteRAFStatus(int rafStatusId)
        {
            RAFStatusRepository.Delete(GetRAFStatus(rafStatusId));
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<RAFStatusTable> UpdateRAFStatus(RAFStatusTable rafStatus)
        {
            RAFStatusRepository.Update(rafStatus);
            await UnitOfWork.SaveChangesAsync();
            return rafStatus;
        }

        public RAFStatusTable GetRAFStatus(int rafStatusId)
        {
            var items = RAFStatusRepository.Queryable().Where(x => x.RAFStatusId == rafStatusId).ToList();

            RAFStatusTable rafStatusResult = new RAFStatusTable();
            if (items != null && items.Count > 0)
            {
                rafStatusResult = items[0];
            }

            return rafStatusResult;
        }
    }
}
