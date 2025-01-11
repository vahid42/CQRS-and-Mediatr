using CQRS_and_mediatr.Domain;
using CQRS_and_mediatr.Features.Products.Commands.Create;
using CQRS_and_mediatr.Features.Products.Commands.Delete;
using CQRS_and_mediatr.Features.Products.Commands.Update;
using CQRS_and_mediatr.Features.Products.Dtos;
using CQRS_and_mediatr.Features.Products.Notifications;
using CQRS_and_mediatr.Features.Products.Queries.Get;
using CQRS_and_mediatr.Features.Products.Queries.List;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using   MediatR;


namespace CQRS_and_mediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        [HttpGet("GetById/id")]
        public async Task<ActionResult<ProductDto>> GetByIdAsync( Guid id, ISender mediatr)
        {
            ProductDto dto = await mediatr.Send(new GetProductQuery(id));
            if (dto == null) return null;
            return Ok(dto);
        }


        [HttpGet(Name = "List")]
        public async Task<ActionResult<List<ProductDto>>> GetListAsync(MediatR.ISender mediatr)
        {
            var list = await mediatr.Send(new ListProductsQuery());
            if (list == null) return null;
            return Ok(list);
        }


        [HttpPost(Name = "Add")]
        public async Task<ActionResult<Guid>> AddAsync(CreateProductCommand createProductCommand, IMediator mediatr)
        {
            var guid = await mediatr.Send(createProductCommand);
            await mediatr.Publish(new ProductCreatedNotification(guid));

            return Ok(guid);
        }


        [HttpPut(Name = "Edit")]
        public async Task<ActionResult<bool>> EditAsync(UpdateProductCommand updateProductCommand, ISender mediatr)
        {
            var result = await mediatr.Send(updateProductCommand);
            if (result) return Ok(true);
            return false;
        }


        [HttpDelete(Name = "Delete")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, ISender mediatr)
        {
            var result = await mediatr.Send(new DeleteProductCommand(id));
            if (result) return Ok(true);
            return false;
        }
    }
}
