using MDG.Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Entity
{
    public class RAFQuestions : EfEntity
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
    }
}
