using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Request.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;


namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries
{

    public class GetLeaveAllocationDetailsRequestHandler : IRequestHandler<GetLeaveAllocationDetailsRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailsRequest request, CancellationToken cancellationToken)
        {
            var leavaAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

            return _mapper.Map<LeaveAllocationDto>(leavaAllocation);
        }
    }
}
