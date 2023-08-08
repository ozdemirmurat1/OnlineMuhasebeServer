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
        public MainRole(string id, string title, bool ısRoleCreatedByAdmin=false, string companyId=null):base(id)
        {
            Title = title;
            IsRoleCreatedByAdmin = ısRoleCreatedByAdmin;
            CompanyId = companyId;
        }

        public string Title { get; set; }      
        public bool IsRoleCreatedByAdmin { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
