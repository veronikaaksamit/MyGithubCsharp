using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class FormType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ElementType> ElementTypes { get; set; }

        public FormType()
        {
            ElementTypes = new List<ElementType>();
        }
    }
}
