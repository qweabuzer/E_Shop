using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace E_Shop.API.Swagger
{
    public class DefaultValueSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
                return;

            var ctor = context.Type
                .GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault();

            if(ctor == null)
                return;

            foreach(var p in ctor.GetParameters())
            {
                if(!p.HasDefaultValue || p.Name == null)
                    continue;

                var key = char.ToLowerInvariant(p.Name[0]) + p.Name[1..];

                if(!schema.Properties.TryGetValue(key, out var value))
                    continue;

                if(p.DefaultValue == null)
                {
                    value.Default = new OpenApiNull();
                    continue;
                }

                var json = JsonSerializer.Serialize(p.DefaultValue);
                value.Default = OpenApiAnyFactory.CreateFromJson(json);
            }
        }
    }
}
