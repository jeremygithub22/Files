using MDG.PMAP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.PMAP.Business.Service
{
    public interface IEmailTemplateService
    {
        List<EmailTemplate> GetAllEmailTemplate();
        Task<EmailTemplate> InsertEmailTemplate(EmailTemplate emailTemplate);
        Task<bool> DeleteEmailTemplate(string templateCode);
        Task<EmailTemplate> UpdateEmailTemplate(EmailTemplate emailTemplate);
        EmailTemplate GetEmailTemplate(string templateCode);

    }
}
