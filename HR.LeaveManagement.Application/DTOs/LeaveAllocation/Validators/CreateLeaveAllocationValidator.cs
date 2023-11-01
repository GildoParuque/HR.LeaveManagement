using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationValidator() 
        {
            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(p => p.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .NotNull();

            RuleFor(p => p.Period)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .NotNull();
        }
    }
}
