using API_FastEndpoints.Results;
using Com.Dal.Models;
using FastEndpoints;

namespace API_FastEndpoints.EndPoints
{
    public class GetProductsEndpoint :Endpoint<Request, Response>
    {
        EcommContext _ctx;
        public GetProductsEndpoint(EcommContext ctx)
        {
            _ctx = ctx;
        }
         
        public override void Configure()
        {
            Get("/api/products/{ProductId?}");
            AllowAnonymous();
            Description(b => b
                .Produces<Response>()
                .Produces(404)
                .WithTags("Products"));
        }
        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(req.ProductId))
            {
                var products = _ctx.ProductInfos.ToList();
               await HttpContext.Response.SendOkAsync(products, cancellation: ct);
                return;
            }
            var product = _ctx.ProductInfos.Find(req.ProductId);
            if (product == null)
            {
                await HttpContext.Response.SendNotFoundAsync(cancellation: ct);
                return;
            }
            await HttpContext.Response.SendOkAsync(new Response { Product = product }, cancellation: ct);
        }

    }
}
