using System.Linq;
using System.Web.Http;
using System.Data.Entity;

using FormAsAService.Models.FormSubmit;

namespace FormAsAService.Controllers
{
    public class FormSubmitController : ApiController
    {
        Model.FormAsAServiceDbContext _dataProvider = new Model.FormAsAServiceDbContext();


        [HttpPost]
        public IHttpActionResult Submit([FromBody]Form form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formType = _dataProvider.FormTypes
                .Include(type => type.ElementTypes)
                .SingleOrDefault(type => type.Id == form.FormTypeId);

            if (formType == null)
            {
                return BadRequest($"Form type with {form.FormTypeId} not found");
            }

            if (form.Elements.Count != formType.ElementTypes.Count)
            {
                return BadRequest($"Wrong number of elements.");
            }

            foreach (var elementType in formType.ElementTypes)
            {
                if (form.Elements.Count(e => e.ElementTypeId == elementType.Id) != 1)
                {
                    return BadRequest($"Wrong element TypeId.");
                }
            }

            var dbForm = form.ToDBModel();
            _dataProvider.Forms.Add(dbForm);
            _dataProvider.SaveChanges();

            return Ok();
        }
    }
}