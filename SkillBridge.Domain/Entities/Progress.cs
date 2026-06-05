using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBridge.Domain.Entities
{
    public class Progress
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public double CompletionPercentage { get; set; }
        public double Score { get; set; }
    }
}
