using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class Entity //objeto de uso comum
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; } // aceita null, por isso coloca '?'
        public bool IsDeleted { get; set; }

    }
}
