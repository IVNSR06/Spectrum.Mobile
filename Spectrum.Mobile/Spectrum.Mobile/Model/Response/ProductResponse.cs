using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectrum.Mobile.Model.Response
{
    public class ProductResponse
    {
        [JsonProperty("products")] public List<Product> Products { get; set; }
        [JsonProperty("total")] public int Total { get; set; }
        [JsonProperty("skip")] public int Skip { get; set; }
        [JsonProperty("limit")] public int Limit { get; set; }
    }
}