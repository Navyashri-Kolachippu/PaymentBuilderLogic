using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBuilderDataObjects
{
    public class PaymentType
    {
        public string PaymentValue { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsVideo { get; set; }
        public bool LearningToSki { get; set; }
        public bool NewMember { get; set; }
        public string AgentId { get; set; }
    }
}
