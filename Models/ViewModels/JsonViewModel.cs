using Newtonsoft.Json;

namespace rar.Models
{
    [Serializable]
    public class JsonViewModel
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }
}