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
    public class EmailTemplateService : IEmailTemplateService
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly IRepositoryAsync<EmailTemplate> EmailTemplateRepository;

        public EmailTemplateService(IUnitOfWorkAsync unitOfWork,
            IRepositoryAsync<EmailTemplate> emailTemplateRepository)
        {
            UnitOfWork = unitOfWork;
            EmailTemplateRepository = emailTemplateRepository;
        }

        public List<EmailTemplate> GetAllEmailTemplate()
        {
            return EmailTemplateRepository.Queryable().ToList();
        }
        public async Task<EmailTemplate> InsertEmailTemplate(EmailTemplate emailTemplate)
        {
            EmailTemplateRepository.Insert(emailTemplate);
            await UnitOfWork.SaveChangesAsync();
            return emailTemplate;
        }

        public async Task<bool> DeleteEmailTemplate(string templateCode)
        {
            var item = GetEmailTemplate(templateCode);
            EmailTemplateRepository.Delete(item);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<EmailTemplate> UpdateEmailTemplate(EmailTemplate emailTemplate)
        {
            EmailTemplateRepository.Update(emailTemplate);
            await UnitOfWork.SaveChangesAsync();
            return emailTemplate;
        }

        public EmailTemplate GetEmailTemplate(string templateCode)
        {
            var items = EmailTemplateRepository.Queryable().Where(x => x.TemplateCode == templateCode).ToList();

            EmailTemplate emailTemplateResult = new EmailTemplate();
            if (items != null && items.Count > 0)
            {
                emailTemplateResult = items[0];
            }
            return emailTemplateResult;
        }
    }
}
