using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
