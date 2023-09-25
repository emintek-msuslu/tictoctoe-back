using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Core.Abstract;

namespace TicTocToe.Model.Core.Concrete
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid SecretId { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
