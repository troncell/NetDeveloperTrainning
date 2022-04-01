// See https://aka.ms/new-console-template for more information
using Common;

Console.WriteLine("Welcome Weather");

//调用webapi下的方法
string sUrl = "https://localhost:44347/WeatherForecast/GetWeatherForecast";
string sReturnValue = HTTPHelper.GetHttp(sUrl);
Console.WriteLine(sReturnValue);

/// <summary>
/// 新增
/// </summary>
//sUrl = "https://localhost:44347/WeatherForecast/AddWeatherSummaries";
//sReturnValue = HTTPHelper.PostHttp(sUrl);

//sUrl = "https://localhost:44347/WeatherForecast/UpdateWeatherSummaries";
//sReturnValue = HTTPHelper.PatchHttp(sUrl);

//sUrl = "https://localhost:44347/WeatherForecast/DeleteWeatherSummaries";
//sReturnValue = HTTPHelper.DeleteHttp(sUrl);

