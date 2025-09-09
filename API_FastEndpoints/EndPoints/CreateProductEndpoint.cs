using API_FastEndpoints.Results;
using Com.Dal.Models;
using FastEndpoints;

namespace API_FastEndpoints.EndPoints
{
    public class CreateProductEndpoint: Endpoint<Request,Response>
    {
        EcommContext _ctx;
        public CreateProductEndpoint(EcommContext ctx)
        {
            _ctx = ctx;
        }

        public override void Configure()
        {
            Post("/api/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            try
            {
                await _ctx.ProductInfos.AddAsync(req.Product!, ct);
                await _ctx.SaveChangesAsync(ct);
                await HttpContext.Response.SendOkAsync(new Response { Product = req.Product, Message = "Product created successfully" });
            }
            catch (Exception ex)
            {
                await HttpContext.Response.SendErrorsAsync(
                    new List<FluentValidation.Results.ValidationFailure>
                    {
                        new("Exception", ex.Message)
                    },
                    500
                );
            }
        }
    }
}
