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
    public class SubGroupTypesService : ISubGroupTypesService
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly IRepositoryAsync<SubGroupTypes> SubGroupTypesRepository;

        public SubGroupTypesService(IUnitOfWorkAsync unitOfWork,
            IRepositoryAsync<SubGroupTypes> subGroupTyesRepository)
        {
            UnitOfWork = unitOfWork;
            SubGroupTypesRepository = subGroupTyesRepository;
        }

        public List<SubGroupTypes> GetAllSubGroupTypes()
        {
            return SubGroupTypesRepository.Queryable().ToList();
        }

        public async Task<SubGroupTypes> InsertSubGroupTypes(SubGroupTypes subGroupTypes)
        {
            subGroupTypes.Id = 0;
            SubGroupTypesRepository.Insert(subGroupTypes);
            await UnitOfWork.SaveChangesAsync();
            return subGroupTypes;
        }

        public async Task<bool> DeleteSubGroupTypes(int iD)
        {
            SubGroupTypesRepository.Delete(GetSubGroupTypes(iD));
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<SubGroupTypes> UpdateSubGroupTypes(SubGroupTypes subGroupTypes)
        {
            SubGroupTypesRepository.Update(subGroupTypes);
            await UnitOfWork.SaveChangesAsync();
            return subGroupTypes;
        }

        public SubGroupTypes GetSubGroupTypes(int iD)
        {
            var items = SubGroupTypesRepository.Queryable().Where(x => x.Id == iD).ToList();

            SubGroupTypes subGroupTypesResult = new SubGroupTypes();
            if (items != null && items.Count > 0)
            {
                subGroupTypesResult = items[0];
            }
            return subGroupTypesResult;
        }
    }
}
