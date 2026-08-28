using MDG.Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Entity
{
    public class EmailTemplate: EfEntity
    {
        public string TemplateCode { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
