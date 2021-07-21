namespace Test_InterView.Models
{
    public class DetailData
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string weatherMain { get; set; }
        public string weatherDescription { get; set; }
        public string weatherIcon { get; set; } = "http://openweathermap.org/img/wn/codeIcon@2x.png";
        public double MainTemp { get; set; }
        public int MainHumidity { get; set; }
    }
}