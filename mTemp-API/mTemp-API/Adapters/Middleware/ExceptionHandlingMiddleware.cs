namespace mTemp_API.Adapters.Middleware;

using mTemp_API.Domain.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Continue to the next middleware/controller
        }
        catch (PatientNotFoundException ex)
        {
            context.Response.StatusCode = 404; // Not Found
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (InvalidTemperatureMeasurementDataException ex)
        {
            context.Response.StatusCode = 400; // Bad Request
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (InvalidPatientDataException ex)
        {
            context.Response.StatusCode = 400; // Bad Request
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Default exception handling
            _logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = 500; // Internal Server Error
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message = "An unexpected error occurred." });
        }
    }
}
