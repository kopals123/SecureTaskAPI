namespace SecureTaskAPI.Middleware
{
    public class CustomHeaderMiddleWare
    {
        private readonly RequestDelegate _requestDelegate;

        public CustomHeaderMiddleWare(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                context.Response.Headers.Append("X-Api-Version", "v1.0");
                await _requestDelegate(context);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
