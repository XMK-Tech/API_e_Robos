using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgilleApi.Domain.Shared;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.Entities;

public class NoticeTemplate : Entity
{
    public NoticeTemplate(){}
    public NoticeTemplate(string template, string name, int daysToExpire)
    {
        Template = template;
        Name = name;
        DaysToExpire = daysToExpire;
    }
    public NoticeTemplate(string template, string name, NoticeType type, int daysToExpire, Module module)
    {
        Template = template;
        Name = name;
        Type = type;
        DaysToExpire = daysToExpire;
        Module = module;
    }

    public void Update(string template)
    {
      Template = template;
    }

    public string Template { get; set; }
    public string Name {get;set;}
    public NoticeType Type { get; set; }
    public int DaysToExpire { get; set; }
    public Module Module { get; set; }
}
public class NoticeTemplateMap : IEntityTypeConfiguration<NoticeTemplate>
{
    public void Configure(EntityTypeBuilder<NoticeTemplate> builder)
    {
      builder.ToTable("NoticeTemplates");
      builder.HasKey(h => h.Id);

      builder.Property(e => e.Template).IsRequired();
    }
}