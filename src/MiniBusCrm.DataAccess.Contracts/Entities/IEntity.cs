using System;

namespace MiniBusCrm.DataAccess.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreateDate { get; set; }
        bool IsActive { get; set; }
    }
}