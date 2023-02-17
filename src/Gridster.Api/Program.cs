// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Core.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices();

builder.Services.AddInfrastructureServices("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Gridster;Integrated Security=SSPI;");

builder.Services.AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.MapHub<GridsterHub>("/hub");

app.Run();
