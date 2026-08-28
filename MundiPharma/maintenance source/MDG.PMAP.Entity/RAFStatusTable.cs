using MDG.Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Entity
{
    public class RAFStatusTable: EfEntity
    {
        public int RAFStatusId { get; set; }
        public string StatusCode { get; set; }
        public string StatusType { get; set; }
    }
}
