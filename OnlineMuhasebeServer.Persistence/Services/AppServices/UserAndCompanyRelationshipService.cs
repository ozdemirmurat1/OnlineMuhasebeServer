﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public class UserAndCompanyRelationshipService : IUserAndCompanyRelationshipService
    {
        private readonly IUserAndCompanyRelationshipCommandRepository _commandRepository;
        private readonly IUserAndCompanyRelationshipQueryRepository _queryRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public UserAndCompanyRelationshipService(IUserAndCompanyRelationshipCommandRepository commandRepository, IUserAndCompanyRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship,CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(userAndCompanyRelationship, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserAndCompanyRelationship> GetByIdAsync(string id)
        {
            return await _queryRepository.GetById(id);
        }

        public async Task<UserAndCompanyRelationship> GetByUserIdAndCompanyId(string userId, string companyId,CancellationToken cancellationToken)
        {
            return await _queryRepository.GetFirstByExpression(p => p.AppUserId == userId && p.CompanyId == companyId, cancellationToken);
        }

        public async Task<IList<UserAndCompanyRelationship>> GetListByUserId(string userId)
        {
            return await _queryRepository.GetWhere(p=>p.AppUserId==userId).Include(p=>p.Company).ToListAsync();
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _commandRepository.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
