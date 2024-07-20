using System.Net;

namespace ILPManagementSystem.Models.DTO
{
    public class APIResponse
    {
        public APIResponse()
        {
            Message = new List<string>();
        }

        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public List<string> Message { get; set; }
    }
}

