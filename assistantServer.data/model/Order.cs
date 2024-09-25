using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assistantServer.data.model
{
    public class Order : BaseModel
    {
        public string FirstLastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int AdvancePayment { get; set; }
        public int ProductionTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsOverdue { get; set; }
        public virtual User User { get; set; }
    }
}
