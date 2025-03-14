﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys.AbstractRepositories;

public interface IBusinessRepository: IRepository<Business>
{
    Task<int> CountAsync();
    Task<List<Business>> GetByTagAsync(string tag);
    Task<List<Business>> SearchAsync(string searchTerm);
    Task<IEnumerable<Business>> FindByApprovalStatusAsync(bool approvalStatus);
    Task<Business> GetBusinessWithDetailsAsync(int businessId);
    Task <Business> UpdateBusinessBasicInfoAsync(Business entity);
    Task UpdateApprovalStatusAsync(int businessId, bool approvalStatus);

}
