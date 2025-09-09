using Com.Dal.Models;

namespace API_FastEndpoints.Results
{
    public class Response
    {
        public List<ProductInfo>? Products { get; set; }
        public ProductInfo? Product { get; set; }
        public string? Message { get; set; }
    }
}
