using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Test_InterView.Models;

namespace Test_InterView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Baitap1Controller : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;
        public Baitap1Controller(IHttpClientFactory httpContextFactory)
        {
            _httpClient = httpContextFactory;
        }
        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            var client = _httpClient.CreateClient();

            
            var respones = await client.GetAsync("http://api.openweathermap.org/data/2.5/group?id=1580578,1581129,1581297,1581188,1587923&units=metric&appid=91b7466cc755db1a94caf6d86a9c788a");
            var jsonWeather = await respones.Content.ReadAsStringAsync();
            var listWeather = JToken.Parse(jsonWeather);
            var list = listWeather.Root.SelectTokens("list").ToList();
            var getListWeather = new List<Parentweather>();
            foreach (JObject item in list[0])
            {
                var wearther = new Parentweather();
                wearther.Data = new List<DetailData>();
                var detailData = new DetailData();
                foreach (JProperty i in item.Properties())
                {
                   if(i.Name== "weather")
                    {
                         wearther.Message = i.First.Values<string>("main").ToArray()[0];
                        detailData.weatherMain= i.First.Values<string>("main").ToArray()[0];
                        detailData.weatherDescription = i.First.Values<string>("description").ToArray()[0];
                        detailData.weatherIcon = detailData.weatherIcon.Replace("codeIcon", i.First.Values<string>("icon").ToArray()[0]);
                    }
                   if(i.Name == "main")
                    {
                        detailData.MainHumidity = int.Parse(i.First.Value<string>("humidity"));
                        detailData.MainTemp =double.Parse((i.First.Value<string>("temp")));
                        
                    }
                    if (i.Name == "id")
                         detailData.CityId = int.Parse(i.Value.ToString());
                    if (i.Name == "name")
                        detailData.CityName = i.Value.ToString();
                }
                 wearther.Data.Add(detailData);
                getListWeather.Add(wearther);
            }
           

            return Ok(JsonConvert.SerializeObject(getListWeather));
        }
    }
}
