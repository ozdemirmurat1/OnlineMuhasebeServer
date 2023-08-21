﻿using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries
{
    public sealed record GetAllMainRoleAndRoleRLQueryResponse(
        List<MainRoleAndRoleRelationship> mainRoleAndRoleRelationships);

}
