using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionServices _services;

        public PermissionController(PermissionServices services)
        {
            _services = services;
        }
        //private readonly Context context;

        //public PermissionController(Context context)
        //{
        //    this.context = context;
        //}

        //[HttpGet]
        //public ActionResult<Result<PermissionViewListModel>> GetPermissions()
        //{
        //    try
        //    {
        //        PermissionViewListModel result = new PermissionViewListModel();
        //        System.Collections.Generic.List<Domain.Entities.Permission> list = context.Permissions.ToList();
        //        foreach (Domain.Entities.Permission item in list)
        //        {
        //            result.Permissions.Add(new PermissionModel(item.Id, item.Code));
        //        }
        //        return Ok(new Result<PermissionViewListModel>(200, result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new Result<WithOutContent>(500, ex));
        //    }
        //}
        [HttpGet]
        public ActionResult<Result<List<PermissionViewListModel>>> GetPermissions([FromQuery] MetadataParams metadataViewModel)
        {
            try
            {
                var metadata = metadataViewModel.ViewModelFromEntity();
                List<PermissionViewListModel> content = _services.List(metadata);

                if (!_services.Valid)
                    return BadRequest(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));

                return Ok(new Result<List<PermissionViewListModel>>(200, content, metadata));
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<WithOutContent>(500, ex));
            }
        }
    }
}
