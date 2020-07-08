using System;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreateDate { get; set; }
        bool IsActive { get; set; }
    }
}