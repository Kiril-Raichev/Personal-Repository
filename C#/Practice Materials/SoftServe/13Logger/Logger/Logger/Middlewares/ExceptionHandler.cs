namespace Logger.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandler> logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch(Exception ex) 
            {
                logger.LogError(ex, "An error occured");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Error: An error occured during proccesses");
            }
        }
    }
}
