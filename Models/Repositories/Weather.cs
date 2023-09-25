using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class Weather
    {
        [Key]
        public int WeatherTypeID { get; set; } 
        public string TypeOfWeather{ get; set; }
        
    }
}