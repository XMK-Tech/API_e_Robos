using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{
  public class AttachmentParams
  {
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Owner { get; set; }
    public string OwnerId { get; set; }
    public string DisplayName { get; set; }
  }
  public class AttachmentViewModel
  {
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Owner { get; set; }
    public string OwnerId { get; set; }
    public string Url { get; set; }
    public string ExternalId { get; set; }
    public string DisplayName { get; set; }
  }
  public class AttachmentInsertUpdateViewModel
  {
    [Required]
    public IFormFile Attachment { get; set; }
    [Required]
    public string Owner { get; set; }
    [Required]
    public string OwnerId { get; set; }
  }

  //public class AttachmentUpdateViewModel
  //{
  //  public IFormFile Attachment { get; set; }
  //  public string Owner { get; set; }
  //  public string OwnerId { get; set; }
  //}
}
