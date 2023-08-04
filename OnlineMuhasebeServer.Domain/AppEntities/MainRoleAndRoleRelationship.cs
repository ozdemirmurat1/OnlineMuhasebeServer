using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.AppEntities
{
    public sealed class MainRoleAndRoleRelationship:Entity
    {
        [ForeignKey("AppRole")]
        public string RoleId { get; set; }

        public AppRole AppRole { get; set; }

        [ForeignKey("MainRole")]
        public string MainRoleId { get; set; }

        public MainRole MainRole { get; set; }
    }
}
