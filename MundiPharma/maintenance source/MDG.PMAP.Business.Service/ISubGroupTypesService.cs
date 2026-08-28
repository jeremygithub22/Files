using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Business.Service
{
    public interface ISubGroupTypesService
    {
        List<SubGroupTypes> GetAllSubGroupTypes();
        Task<SubGroupTypes> InsertSubGroupTypes(SubGroupTypes subGroupTypes);
        Task<bool> DeleteSubGroupTypes(int iD);
        Task<SubGroupTypes> UpdateSubGroupTypes(SubGroupTypes subGroupTypes);
        SubGroupTypes GetSubGroupTypes(int iD);
    }
}
