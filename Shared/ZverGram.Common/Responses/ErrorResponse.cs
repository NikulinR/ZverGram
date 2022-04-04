namespace ZverGram.Common.Responses
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<ErrorResponseInfo> Errors { get; set; }
    }

    public class ErrorResponseInfo
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
