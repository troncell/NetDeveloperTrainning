using Microsoft.AspNetCore.Mvc;

namespace WebApiHello.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};
        private static string[] Summaries = new[]{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast //返回5条天气数据
            {
                Date = DateTime.Now.AddDays(index), //获取当前日期
                TemperatureC = Random.Shared.Next(-20, 55), //随机生成温度
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] //随机生成天气情况
            })
            .ToArray();
        }

        [HttpPost]
        public void AddWeatherSummaries(string summaries)
        {
            int length = Summaries.Length;
            Summaries[length] = summaries;
        }

        [HttpPatch]
        public void UpdateWeatherSummaries(string summaries,string newSummaries)
        {
            List<string> list = new List<string>();
            list = Summaries.ToList();
            int index = list.IndexOf(summaries);
            list[index] = newSummaries;
            //list.Remove(summaries);
            //AddWeatherSummaries(newSummaries);
            //int index = 0;
            //summaries[index] = newSummaries;
            //Summaries = list.ToArray();
        }

        [HttpDelete]
        public void DeleteWeatherSummaries(string summaries)
        {
            List<string> list = new List<string>();
            list = Summaries.ToList();
            foreach (string s in list)
            {
                if(s == summaries)
                {
                    list.Remove(s);
                    break;
                }
            }
            Summaries = list.ToArray();
        }


    }
}