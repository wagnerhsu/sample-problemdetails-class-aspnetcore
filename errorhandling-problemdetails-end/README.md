## 2021-12-02

- Upgrade to .NET 6.0

## Features

- Don't include details

```csharp
services.AddProblemDetails(options=>options.IncludeExceptionDetails =((ctx,env)=> false));
```

```json
{
  "type": "https://httpstatuses.com/500",
  "title": "Internal Server Error",
  "status": 500,
  "traceId": "00-1515fff6189ab50b3e7134fb2716cb63-099fc6a24d51380d-00"
}
```

- Include details

```json
{
    "type": "https://httpstatuses.com/500",
    "title": "Internal Server Error",
    "status": 500,
    "detail": "There was an exception while fetching the product",
    "exceptionDetails": [
        {
            "message": "There was an exception while fetching the product",
            "type": "System.Exception",
            "raw": "System.Exception: There was an exception while fetching the product\r\n   at ErrorHandlingProblemDetails.Controllers.ProductController.GetByName(String name) in C:\\Github\\sample\\CodeMazeBlog\\sample-problemdetails-class-aspnetcore\\errorhandling-problemdetails-end\\Controllers\\ProductController.cs:line 40\r\n   at lambda_method47(Closure , Object )\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.AwaitableObjectResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()\r\n--- End of stack trace from previous location ---\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)\r\n   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)\r\n   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)\r\n   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)\r\n   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)\r\n   at Hellang.Middleware.ProblemDetails.ProblemDetailsMiddleware.Invoke(HttpContext context)",
            "stackFrames": [
                {
                    "filePath": "C:\\Github\\sample\\CodeMazeBlog\\sample-problemdetails-class-aspnetcore\\errorhandling-problemdetails-end\\Controllers\\ProductController.cs",
                    "fileName": "ProductController.cs",
                    "function": "ErrorHandlingProblemDetails.Controllers.ProductController.GetByName(string name)",
                    "line": 40,
                    "preContextLine": 34,
                    "preContextCode": [
                        "            return Ok(product);",
                        "        }",
                        "",
                        "        [HttpGet(\"byName/{name}\")]",
                        "        public async Task<ActionResult<Product>> GetByName(string name)",
                        "        {"
                    ],
                    "contextCode": [
                        "            throw new Exception(\"There was an exception while fetching the product\");"
                    ],
                    "postContextCode": [
                        "",
                        "            var product = await _productService.GetProductByName(name);",
                        "            if (product == null)",
                        "                return NotFound();",
                        "",
                        "            return Ok(product);"
                    ]
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "lambda_method47(Closure , object )",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor+AwaitableObjectResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, object controller, object[] arguments)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "System.Threading.Tasks.ValueTask<TResult>.get_Result()",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "System.Runtime.CompilerServices.ValueTaskAwaiter<TResult>.GetResult()",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask<IActionResult> actionResultValueTask)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, object state, bool isCompleted)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, object state, bool isCompleted)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Hellang.Middleware.ProblemDetails.ProblemDetailsMiddleware.Invoke(HttpContext context)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                }
            ]
        }
    ],
    "traceId": "00-333bf64839502cdccb8b2c95f512b233-b36f50cea7d6f1ac-00"
}
```

- Use customized exception

```json
{
    "additionalInfo": "Maybe you can try again in a bit?",
    "type": "product-custom-exception",
    "title": "Custom Product Exception",
    "status": 500,
    "detail": "There was an unexpected error while fetching the product.",
    "instance": "/api/product/1",
    "traceId": "00-de09ce4d7f830f50df50206a2d9abcf0-a3ad0a83986d3f2a-00"
}
```

```json
{
    "additionalInfo": "Maybe you can try again in a bit?",
    "type": "product-custom-exception",
    "title": "Custom Product Exception",
    "status": 500,
    "detail": "There was an unexpected error while fetching the product.",
    "instance": "/api/product/1",
    "exceptionDetails": [
        {
            "message": "Exception of type 'ErrorHandlingProblemDetails.CustomExceptions.ProductCustomException' was thrown.",
            "type": "ErrorHandlingProblemDetails.CustomExceptions.ProductCustomException",
            "raw": "ErrorHandlingProblemDetails.CustomExceptions.ProductCustomException: Exception of type 'ErrorHandlingProblemDetails.CustomExceptions.ProductCustomException' was thrown.\r\n   at ErrorHandlingProblemDetails.Controllers.ProductController.GetById(Int32 id) in C:\\Github\\sample\\CodeMazeBlog\\sample-problemdetails-class-aspnetcore\\errorhandling-problemdetails-end\\Controllers\\ProductController.cs:line 28\r\n   at lambda_method47(Closure , Object )\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.AwaitableObjectResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()\r\n--- End of stack trace from previous location ---\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)\r\n   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)\r\n   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)\r\n   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)\r\n   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)\r\n   at Hellang.Middleware.ProblemDetails.ProblemDetailsMiddleware.Invoke(HttpContext context)",
            "stackFrames": [
                {
                    "filePath": "C:\\Github\\sample\\CodeMazeBlog\\sample-problemdetails-class-aspnetcore\\errorhandling-problemdetails-end\\Controllers\\ProductController.cs",
                    "fileName": "ProductController.cs",
                    "function": "ErrorHandlingProblemDetails.Controllers.ProductController.GetById(int id)",
                    "line": 28,
                    "preContextLine": 22,
                    "preContextCode": [
                        "        [HttpGet]",
                        "        public async Task<IEnumerable<Product>> Get() => await _productService.GetAllPrpoducts();",
                        "",
                        "        [HttpGet(\"{id}\")]",
                        "        public async Task<ActionResult<Product>> GetById(int id)",
                        "        {"
                    ],
                    "contextCode": [
                        "            throw new ProductCustomException(Request.Path.Value);"
                    ],
                    "postContextCode": [
                        "",
                        "            var product = await _productService.GetProductById(id);",
                        "            if (product == null)",
                        "                return NotFound();",
                        "",
                        "            return Ok(product);"
                    ]
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "lambda_method47(Closure , object )",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor+AwaitableObjectResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, object controller, object[] arguments)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "System.Threading.Tasks.ValueTask<TResult>.get_Result()",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "System.Runtime.CompilerServices.ValueTaskAwaiter<TResult>.GetResult()",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask<IActionResult> actionResultValueTask)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, object state, bool isCompleted)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, object state, bool isCompleted)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                },
                {
                    "filePath": null,
                    "fileName": null,
                    "function": "Hellang.Middleware.ProblemDetails.ProblemDetailsMiddleware.Invoke(HttpContext context)",
                    "line": null,
                    "preContextLine": null,
                    "preContextCode": null,
                    "contextCode": null,
                    "postContextCode": null
                }
            ]
        }
    ],
    "traceId": "00-2ea7b52a849ff4199619e0ee20d859a1-312b6e32de362de7-00"
}
```

- Conclusions
  - Use exceptionDetails for development environment
  - Use customized exception to expose necessary information for production envioronment