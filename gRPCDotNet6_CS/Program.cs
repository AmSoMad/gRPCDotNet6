using gRPCDotNet6_CS.Services;

var builder = WebApplication.CreateBuilder(args);

//GrpcServices.Startup.Run(builder);

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<GrpcServices.ServerLoggerInterceptor>();
});

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc - status", "Grpc - Message", "Grpc - Encoding", "Grpc - Accept - Encoding");
}));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.UseEndpoints(endpoints =>
{
    GrpcBindServer.GrpcBindService.UseEndpoints(endpoints);
});


// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
