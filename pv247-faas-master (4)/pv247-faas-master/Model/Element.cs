using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Element
    {
        [Key]
        public int Id { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual ElementType Type { get; set; }

        public string Value { get; set; }
    }
}
