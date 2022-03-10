using Application.Commands.Create;
using Application.Commands.Delete;
using Application.Commands.Edit;
using Application.Common;
using Application.Queries.Common;
using Application.Queries.Details;
using Application.Queries.Search;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Common;

namespace Web.Controllers
{
	public class ContactsController : ApiController
	{
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ContactOutputModel>> Details(
            [FromRoute] ContactDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateContactOutputModel>> Create(
           CreateContactCommand command)
           => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditContactCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(
          [FromRoute] DeleteContactCommand command)
          => await this.Send(command);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactOutputModel>>> Search(
            [FromQuery] ContactsSearchQuery query)
            => await this.Send(query);
    }
}
