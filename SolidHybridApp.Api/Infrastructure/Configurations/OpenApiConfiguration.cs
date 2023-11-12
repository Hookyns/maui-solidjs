using Microsoft.OpenApi.Models;

namespace SolidHybridApp.Api.Infrastructure.Configurations;

public static class OpenApiConfiguration
{
	// private static readonly string ApiName = "Trainee TODO app";
	// private static IReadOnlyList<ApiVersionDescription>? apiVersionsDescription;

	public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services)
	{
		services.AddProblemDetails().AddHttpContextAccessor().AddEndpointsApiExplorer();

		services.AddSwaggerGen(options =>
		{
			options.SwaggerDoc("v1", new OpenApiInfo { Title = "TraineeApp.Todo.Api", Version = "v1" });

			// https://stackoverflow.com/a/58972781/7141090;
			// options.AddSecurityDefinition(
			// 	"Bearer",
			// 	new OpenApiSecurityScheme
			// 	{
			// 		Description = """
			// 		              JWT Authorization header using the Bearer scheme.<br>
			// 		              Template: 'Bearer {token}'<br>
			// 		              Example: 'Bearer eyJhbG.eyJJU3MjF9.u7_2W5SP-Z4xBm9yKNZ-Bi06Q'<br>
			// 		              Use /api/auth/login endpoint to get the Bearer token.
			// 		              """,
			// 		Name = "Authorization",
			// 		In = ParameterLocation.Header,
			// 		Type = SecuritySchemeType.ApiKey,
			// 		Scheme = JwtBearerDefaults.AuthenticationScheme
			// 	}
			// );

			// To show locks on endpoints in the UI. Currently it works even without this.
			// options.OperationFilter<SecurityRequirementsOperationFilter>();

			// options.AddSecurityRequirement(
			// 	new OpenApiSecurityRequirement()
			// 	{
			// 		{
			// 			new OpenApiSecurityScheme
			// 			{
			// 				Reference = new OpenApiReference
			// 				{
			// 					Type = ReferenceType.SecurityScheme,
			// 					Id = JwtBearerDefaults.AuthenticationScheme
			// 				},
			// 				Scheme = "oauth2",
			// 				Name = JwtBearerDefaults.AuthenticationScheme,
			// 				In = ParameterLocation.Header
			// 			},
			// 			new List<string>()
			// 		}
			// 	}
			// );

			// options.IncludeXmlComments(Path.Combine(
			//     AppContext.BaseDirectory,
			//     typeof(OpenApiConfiguration).Assembly.GetName().Name + ".xml"
			// ));
		});

		return services;
	}

	public static WebApplication UseOpenApiConfiguration(this WebApplication app)
	{
		if (app.Environment.IsDevelopment())
		{
			// app.UseSwagger();
			app.MapSwagger().AllowAnonymous();
			app.UseSwaggerUI();
		}

		return app;
	}

	// /// <summary>
	// /// Create information about the version of the API
	// /// </summary>
	// /// <param name="description"></param>
	// /// <returns>Information about the API</returns>
	// private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
	// {
	//     var info = new OpenApiInfo
	//     {
	//         Title = $"{ApiName} {description.GroupName} API v{description.ApiVersion}",
	//         Version = description.ApiVersion.ToString()
	//     };
	//
	//     if (description.IsDeprecated)
	//     {
	//         info.Description = "This API version has been deprecated." + info.Description;
	//     }
	//
	//     return info;
	// }
}
