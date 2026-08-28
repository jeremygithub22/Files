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
    public class ProductSubGroupService : IProductSubGroupService
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly IRepositoryAsync<ProductSubGroup> ProductSubGroupRepository;

        public ProductSubGroupService(IUnitOfWorkAsync unitOfWork,
            IRepositoryAsync<ProductSubGroup> productSubGroupRepository)
        {
            UnitOfWork = unitOfWork;
            ProductSubGroupRepository = productSubGroupRepository;
        }

        public List<ProductSubGroup> GetAllProductSubGroup()
        {
            return ProductSubGroupRepository.Queryable().ToList();
        }

        public async Task<ProductSubGroup> InsertProductSubGroup(ProductSubGroup productSubGroup)
        {
            productSubGroup.Id = 0;
            ProductSubGroupRepository.Insert(productSubGroup);
            await UnitOfWork.SaveChangesAsync();
            return productSubGroup;
        }

        public async Task<bool> DeleteProductSubGroup(int iD)
        {
            ProductSubGroupRepository.Delete(GetProductSubGroupById(iD));
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ProductSubGroup> UpdateProductSubGroup(ProductSubGroup productSubGroup)
        {
            ProductSubGroupRepository.Update(productSubGroup);
            await UnitOfWork.SaveChangesAsync();
            return productSubGroup;
        }

        public ProductSubGroup GetProductSubGroupById(int iD)
        {
            var items = ProductSubGroupRepository.Queryable().Where(x => x.Id == iD).ToList();

            ProductSubGroup productSubGroupResult = new ProductSubGroup();

            if (items != null && items.Count > 0)
            {
                productSubGroupResult = items[0];
            }

            return productSubGroupResult;
        }

    }
}
