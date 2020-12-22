﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Invoices.Dto;

namespace AbpCompanyName.AbpProjectName.Invoices
{
    [AbpAuthorize]
    public class InvoiceItemsAppService : AsyncCrudAppService<InvoiceItem, InvoiceItemDto, Guid, GetAllInvoiceItemDto>
    {
        public InvoiceItemsAppService(IRepository<InvoiceItem, Guid> repository) : base(repository)
        {
            GetAllPermissionName = PermissionNames.Pages_Invoices;
            CreatePermissionName = PermissionNames.Pages_Invoices_Create;
            UpdatePermissionName = PermissionNames.Pages_Invoices_Edit;
            DeletePermissionName = PermissionNames.Pages_Invoices_Delete;
        }

        protected override IQueryable<InvoiceItem> CreateFilteredQuery(GetAllInvoiceItemDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.InvoiceId != null, ff => ff.InvoiceId == input.InvoiceId)
                ;
        }
    }
}
