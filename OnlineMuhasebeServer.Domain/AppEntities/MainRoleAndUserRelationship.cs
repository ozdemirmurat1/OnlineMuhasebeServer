﻿using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.AppEntities
{
    public sealed class MainRoleAndUserRelationship:Entity
    {
        [ForeignKey("AppUser")]
        public string UserId { get; set; }

        public AppUser AppUser { get; set; }

        [ForeignKey("MainRole")]
        public string MainRoleId { get; set; }

        public MainRole MainRole { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}