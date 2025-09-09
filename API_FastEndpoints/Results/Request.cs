using Com.Dal.Models;

namespace API_FastEndpoints.Results
{
    public class Request
    {
        public ProductInfo? Product { get; set; }
        public string? ProductId { get; set; }
    }
}
