using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Data;


namespace WebAPI_ImobiliariaSantos.Models
{
    public class ConverterJsonparaDecimal{
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
      



       public void converetJson()
        {
            string fileName = "ConverterJsonparaDecimal.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            ConverterJsonparaDecimal converJs = JsonSerializer.Deserialize<ConverterJsonparaDecimal>(jsonString)!;

            Console.WriteLine($"Date: {converJs.Date}");
            Console.WriteLine($"TemperatureCelsius: {converJs.TemperatureCelsius}");
            Console.WriteLine($"Summary: {converJs.Summary}");
        }
        
    }

   
    
}