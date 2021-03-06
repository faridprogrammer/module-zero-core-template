﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Logs.Dto;

namespace AbpCompanyName.AbpProjectName.Logs
{
    [AbpAuthorize]
    public class LogsAppService : AsyncCrudAppService<Log, LogDto, int, GetAllLogsDto>
    {
        public LogsAppService(IRepository<Log, int> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
            GetAllPermissionName = PermissionNames.Pages_Logs;
        }

        protected override IQueryable<Log> CreateFilteredQuery(GetAllLogsDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(!input.Level.IsNullOrEmpty(), log => log.Level.ToLower() == input.Level.ToLower())
                .WhereIf(!input.Message.IsNullOrEmpty(), log => log.Message.ToLower().Contains(input.Message.ToLower()))
                .OrderByDescending(log => log.Id);
        }

        public override Task<LogDto> CreateAsync(LogDto input)
        {
            throw new NotSupportedException();
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            throw new NotSupportedException();
        }

        public override Task<LogDto> UpdateAsync(LogDto input)
        {
            throw new NotSupportedException();
        }
    }
}
