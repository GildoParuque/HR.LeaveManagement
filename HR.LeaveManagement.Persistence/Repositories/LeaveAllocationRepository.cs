using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HrLeaveManagementDbContext _context;
        public LeaveAllocationRepository(HrLeaveManagementDbContext context) : base(context)
        {

            _context = context; 

        }
        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
           var leaveAllocation = await _context.LeaveAllocations
                                                                .Include(c => c.LeaveType)
                                                                .FirstOrDefaultAsync(c => c.Id == id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                                                                .Include(c => c.LeaveType)   
                                                                .ToListAsync();      
            
            return leaveAllocations;
        }
    }
}
