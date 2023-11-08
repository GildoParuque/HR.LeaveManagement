using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository) 
        {

            _leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(p => p.NumberOfDays)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveAllocationRepository.Exists(id);

                    return !leaveTypeExists;
                });

            RuleFor(p => p.Period)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .NotNull();
        }
    }
}
