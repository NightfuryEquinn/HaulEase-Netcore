namespace HaulEaseNetcore;

public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
{
  protected override void Init(IWebHostBuilder builder)
  {
    builder
      .UseStartup<Startup>();
  }

  protected override void Init(IHostBuilder builder)
  {
    
  }
}