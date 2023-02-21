using Newtonsoft.Json;
using SmartCard_API.Models;
using SmartCart_API.Models;
using System.Net.Http.Headers;

namespace SmartCard_API.Workers
{
    public class ConfirmWorker : BackgroundService
    {
        private HttpClient client;
        private readonly ILogger<ConfirmWorker> _logger;
        private readonly IConfiguration Configuration;
        private readonly HostSettingServices hostSettingServices;

        public ConfirmWorker(ILogger<ConfirmWorker> logger,
            IConfiguration configuration)

        {
            Configuration = configuration;

            _logger = logger;
            client = null!;
            hostSettingServices = new HostSettingServices()
            {
                Url = Configuration["HostSettingServices:Url"],
            };

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{hostSettingServices.Url}/api/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(5000);
            return;
            while (!stoppingToken.IsCancellationRequested)
            {
           
                try
                {
                    var data = new PartNumber()
                    {
                        PartNoSubAssy = "TG660145-7896",
                        LotId = "00001",
                        TimeStamp = "2022-04-03T13:40:00",
                    };


                    string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

                    StringContent httpcontent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    string uri = "/api/v1/stock/receive";

                    var timeRecordResp = await client.PostAsync(uri, httpcontent);

                    if (timeRecordResp.IsSuccessStatusCode)
                    {
                        var responseString = await timeRecordResp.Content.ReadAsStringAsync();

                        string result = timeRecordResp.StatusCode.ToString();

                        _logger.LogInformation(" OK !!");

                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError("The Website is down.{mess}", ex.Message);
                }


            }
        }



    }
}
