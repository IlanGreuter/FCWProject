using System.Net.Http.Headers;

namespace FCWProject.API
{
    /// <summary>
    /// This background service will continuously attempt to fetch from the API endpoint, sleeping for 10 seconds in between requests.
    /// </summary>
    public class APICaller : BackgroundService
    {
        private const string API_END_POINT = "https://wa-assignmet-hyh4arb9dadfbvc3.westeurope-01.azurewebsites.net/";
        private const string X_API_KEY = "1d1642ed200a036c982cc19d9989d51ad81ed3c6b882ffe111a53d1a37e4ef6f";
        private const int SLEEP_TIME = 10000;

        private ResponseHandler responseHandler;
        private HttpClient client;

        public APICaller(ResponseHandler responseHandler)
        {
            Console.WriteLine("Start");
            this.responseHandler = responseHandler;

            client = new HttpClient();
            client.BaseAddress = new Uri(API_END_POINT);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-API-KEY", X_API_KEY);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Poll");
                try
                {
                    HttpResponseMessage response = await client.GetAsync("data");
                    if (response.IsSuccessStatusCode)
                    {
                        responseHandler.Process(response);
                    } 
                    else
                    {
                        Console.WriteLine($"ERROR: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
                }


                await Task.Delay(SLEEP_TIME, stoppingToken);
            }
        }
    }
}
