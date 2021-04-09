using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace desafio.domain
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }


        public virtual bool isValid()
        { return true; }
    }
}
