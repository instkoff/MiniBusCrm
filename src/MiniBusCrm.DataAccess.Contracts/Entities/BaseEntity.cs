using System;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}