using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class BaseModel : IModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
