using OnlineMuhasebeServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.AppEntities
{
    public sealed class MainRole:Entity
    {
        public string Title { get; set; }      
        public bool IsRoleCreatedByAdmin { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
