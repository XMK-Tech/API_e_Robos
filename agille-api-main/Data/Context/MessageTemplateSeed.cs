using AgilleApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Data.ContextDb
{
    public class MessageTemplateSeed
    {
        public static void Seed(Context context, List<MessageTemplate> messages)
        {
            if (context != null && messages.Count > 0)
            {
                messages.ForEach(p =>
                {
                    if (!context.MessageTemplates.Any(e => e.Code == p.Code))
                    {
                        MessageTemplate messageTemplate = new MessageTemplate(p.Code, p.TemplateName, p.Subject, p.Message, p.SendCopyToMyself, p.Type);
                        context.MessageTemplates.Add(messageTemplate);
                    }
                });
            }

            context.SaveChanges();
        }
    }
}
