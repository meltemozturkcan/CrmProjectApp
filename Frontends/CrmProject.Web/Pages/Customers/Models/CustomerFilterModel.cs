using System.Text.Json.Serialization;
using System.Text.Json;

namespace CrmProject.Web.Pages.Customers.Models
{
    public class CustomerFilterModel
    {
        public string NameFilter { get; set; }
        public string RegionFilter { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? FromDate { get; set; }
        public string EmailFilter { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            try
            {
                return JsonSerializer.Serialize(this, options);
            }
            catch
            {
                return $"Name: {NameFilter ?? "none"}, Region: {RegionFilter ?? "none"}, FromDate: {FromDate?.ToString() ?? "none"}";
            }
        }
    }
}

