using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblStaff
    {
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public string? WorkDescription { get; set; }
        public string? WorkName { get; set; }
        public string? Shift { get; set; }
        public string? WorkStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual TblUser User { get; set; } = null!;
    }
}
