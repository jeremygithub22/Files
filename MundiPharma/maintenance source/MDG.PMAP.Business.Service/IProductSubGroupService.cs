using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Business.Service
{
    public interface IProductSubGroupService
    {
        List<ProductSubGroup> GetAllProductSubGroup();
        Task<ProductSubGroup> InsertProductSubGroup(ProductSubGroup productSubGroup);
        Task<bool> DeleteProductSubGroup(int iD);
        Task<ProductSubGroup> UpdateProductSubGroup(ProductSubGroup productSubGroup);
        ProductSubGroup GetProductSubGroupById(int iD);
    }
}
