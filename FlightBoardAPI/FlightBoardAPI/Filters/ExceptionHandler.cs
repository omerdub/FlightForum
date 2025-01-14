﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FlightBoardAPI.Entities.Responses;

namespace FlightBoardAPI.Filters
{
    public class ExceptionHandler : IExceptionFilter
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string message = "An error occurred while processing the request";
            _logger.LogError(context.Exception, message);

            var errorResponse = new ErrorResponse(message);
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
}
