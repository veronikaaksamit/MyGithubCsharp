using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace FormAsAService.Models.FormSubmit
{
    public class Form
    {
        [Required]
        public int FormTypeId { get; set; }

        [Required]
        public ICollection<Element> Elements { get; set; }

        public Form()
        {
            Elements = new List<Element>();
        }


        public Model.Form ToDBModel()
        {
            return new Model.Form
            {
                TypeId = FormTypeId,
                Elements = Elements.Select(e => e.ToDBModel()).ToList(),
            };
        }
    }
}
