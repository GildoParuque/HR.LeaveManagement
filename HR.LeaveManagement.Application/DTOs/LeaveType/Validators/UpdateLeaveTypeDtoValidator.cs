﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator() 
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
