using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public interface IModel
    {
        Guid Id { get; set; }
        DateTime CreateDate { get; set; }
        bool IsActive { get; set; }
    }
}
