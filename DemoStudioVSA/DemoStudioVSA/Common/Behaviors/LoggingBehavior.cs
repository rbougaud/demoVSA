using MediatR;
using StudioVSA.Common.Helper;
using System.Reflection;
using FluentValidation;

namespace StudioVSA.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse, ValidationException>>
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<Result<TResponse, ValidationException>> Handle(TRequest request,
        RequestHandlerDelegate<Result<TResponse, ValidationException>> next, CancellationToken cancellationToken)
    {
        //Request
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        Type myType = request.GetType();
        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
        foreach (PropertyInfo prop in props)
        {
            object? propValue = prop.GetValue(request, null);
            _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
        }
        var response = await next();

        LogResponse(response);
        return response;
    }

    private void LogResponse(Result<TResponse, ValidationException> response)
    {
        if (response.IsSuccess)
        {
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
        }
        else
        {
            _logger.LogError(response.Error.Message);
        }
    }
}
