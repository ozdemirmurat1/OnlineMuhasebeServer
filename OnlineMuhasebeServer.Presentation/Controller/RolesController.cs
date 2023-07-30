﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public sealed class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand request)
        {
            CreateRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRolesRequest request = new();
            GetAllRolesResponse response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
        {
            UpdateRoleResponse response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            DeleteRoleCommand request = new(id)
            {
                Id = id
            };

            DeleteRoleCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }
    }
}
