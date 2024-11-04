﻿using FluentValidation;
using MediatR;
using StudioVSA.Common.Helper;

namespace StudioVSA.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Entering ValidationBehavior for {RequestType}", typeof(TRequest).Name);

        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Any())
        {
            var responseType = typeof(TResponse);
            var errors = failures.Select(f => f.ErrorMessage).ToList();
            if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<,>))
            {
                var resultType = responseType.GetGenericArguments()[0];
                var errorType = responseType.GetGenericArguments()[1];

                if (errorType == typeof(List<string>))
                {
                    var method = typeof(Result<,>).MakeGenericType(resultType, typeof(List<string>)).GetMethod("Err");
                    return (TResponse)method!.Invoke(null, new object[] { errors })!;
                }
            }

            throw new ValidationException(failures);
        }

        return await next();
    }
}
