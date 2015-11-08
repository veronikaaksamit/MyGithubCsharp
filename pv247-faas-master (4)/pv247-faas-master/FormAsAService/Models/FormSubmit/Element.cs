using System.ComponentModel.DataAnnotations;

namespace FormAsAService.Models.FormSubmit
{
    public class Element
    {
        [Required]
        public int ElementTypeId { get; set; }

        public string Value { get; set; }


        public Model.Element ToDBModel()
        {
            return new Model.Element
            {
                TypeId = ElementTypeId,
                Value = Value,
            };
        }
    }
}
