using MDG.Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Entity
{
    public class ProductSubGroup : EfEntity
    {
        public int Id { get; set; }
        public string SubGroupTypeCode { get; set; }
        public string ProductCode { get; set; }
    }
}
