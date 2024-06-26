using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ResumeAPI.Models;

public class HealthChecksFilter : IDocumentFilter

{
  public const string HealthCheckEndpoint = @"/healthcheck";

  public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)

  {
    var pathItem = new OpenApiPathItem();

    var operation = new OpenApiOperation();

    operation.Tags.Add(new OpenApiTag { Name = "ApiHealth" });

    var properties = new Dictionary<string, OpenApiSchema>();

    properties.Add("status", new OpenApiSchema() { Type = "string" });

    var response = new OpenApiResponse();
    response.Description = "";

    response.Content.Add("application/json", new OpenApiMediaType

    {
      Schema = new OpenApiSchema
      {
        Type = "object",

        AdditionalPropertiesAllowed = true,

        Properties = properties
      }
    });

    operation.Responses.Add("200", response);
    operation.Description = "Health check endpoint";

    pathItem.AddOperation(OperationType.Get, operation);

    swaggerDoc?.Paths.Add(HealthCheckEndpoint, pathItem);
  }
}
