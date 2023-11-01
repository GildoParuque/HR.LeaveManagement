using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Request.Queries
{
    public class GetLeaveRequestDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
