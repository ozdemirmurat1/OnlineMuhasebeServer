﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistence.Constants;

namespace OnlineMuhasebeServer.Persistence.Configuration
{
    public sealed class UCAFConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
    {
        public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
        {
            builder.ToTable(TableNames.UniformChartOfAccounts);
            builder.HasKey(p=> p.Id);
        }
    }
}
