using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public CreateLeaveAllocationValidator(ILeaveAllocationRepository leaveAllocationRepository) 
        {
            _leaveAllocationRepository = leaveAllocationRepository;
           Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));
        }
    }
}
