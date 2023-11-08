using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository) 
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
