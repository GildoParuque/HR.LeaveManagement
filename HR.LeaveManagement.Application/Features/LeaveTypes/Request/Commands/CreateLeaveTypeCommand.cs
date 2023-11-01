﻿using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Request.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
