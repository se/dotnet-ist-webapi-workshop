using System.Collections.Generic;
using Newtonsoft.Json;

namespace OurApi
{
    public class Return : Return<object>
    {
    }
    
    public class Return<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public class ReturnError : Return
    {
        public List<ReturnErrorModel> Errors { get; set; }
        public string InternalMessage { get; set; }
    }

    public class ReturnErrorModel
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
    }
}