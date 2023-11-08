using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceCore.ElasticSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceCore.CrossCuttingConserns.Exceptions
{ 
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger; 
        public ExceptionMiddleware(RequestDelegate next,   ILogger<ExceptionMiddleware> logger)
        {
            _next = next; 
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            return CreateInternalException(context, exception);
        }
        private Task CreateInternalException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            var jsonResponse = JsonSerializer.Serialize(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/probs/internal",
                Title = "Internal exceptions",
                Detail = exception.Message,
                Instance = ""
            });
            _logger.LogError(exception,"General Error");
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
