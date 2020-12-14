﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Addresses;
using AbpCompanyName.AbpProjectName.Locations.Dto;

namespace AbpCompanyName.AbpProjectName.Locations
{
    public class AddressesAppService : AsyncCrudAppService<Address, AddressDto, int, GetAllAddressesDto>
    {
        public AddressesAppService(IRepository<Address, int> repository) : base(repository)
        {
        }

        protected override IQueryable<Address> CreateFilteredQuery(GetAllAddressesDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.CityId != null, address => address.CityId == input.CityId)
                    .WhereIf(input.CountryId != null, address => address.CountryId == input.CountryId)
                ;
        }
    }
}
