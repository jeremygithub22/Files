using MDG.Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Entity
{
    public class RAFQuestionDepartment: EfEntity
    {
        public int QuestionDepartmentId { get; set; }
        public int Question { get; set; }
        public string DepartmentCode { get; set; }
        public int DisplayOrder { get; set; }
        public string SubGroupTypeCode { get; set; }
    }
}
