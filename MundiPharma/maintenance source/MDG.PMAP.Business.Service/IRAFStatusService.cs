using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Business.Service
{
    public interface IRAFStatusService
    {
        List<RAFStatusTable> GetAllRAFStatus();
        Task<RAFStatusTable> InsertRAFStatus(RAFStatusTable rafStatus);
        Task<bool> DeleteRAFStatus(int rafStatusId);
        Task<RAFStatusTable> UpdateRAFStatus(RAFStatusTable rafStatus);
        RAFStatusTable GetRAFStatus(int rafStatusId);
    }
}
