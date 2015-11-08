using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Form
    {
        [Key]
        public int FormId { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual FormType Type { get; set; }

        public ICollection<Element> Elements { get; set; }

        public Form()
        {
            Elements = new List<Element>();
        }
    }
}
