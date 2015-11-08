using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class ElementType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ElementHtmlTypeEnum ElementHtmlType { get; set; }
    }
}
