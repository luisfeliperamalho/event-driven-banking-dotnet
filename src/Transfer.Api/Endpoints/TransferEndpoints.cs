using Transfer.Api.Application;

namespace Transfer.Api.Endpoints;

public static class TransferEndpoints
{
    public static IEndpointRouteBuilder MapTransferEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/transfers", async (
            CreateTransferRequest request,
            CreateTransferHandler handler,
            CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return Results.Problem(
                    title: "Validation failed",
                    detail: result.Error,
                    statusCode: StatusCodes.Status400BadRequest);
            }

            var response = new CreateTransferResponse(result.TransferId!.Value);
            return Results.Accepted($"/transfers/{result.TransferId}", response);
        })
        .WithName("CreateTransfer")
        .Produces<CreateTransferResponse>(StatusCodes.Status202Accepted)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        return app;
    }
}
