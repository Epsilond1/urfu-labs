using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using HtmlAgilityPack;

namespace sem5_lab4
{
    class Weather
    {
        private string time_of_day;
        private int temperature;
        private string speed_of_wind;
        private string pressure;
        private string humidity;

        public Weather (string _time_of_day, string _temperature, string _speed_of_wind, 
            string _pressure, string _humidity)
        {
            time_of_day = _time_of_day;
            temperature = int.Parse(Normalize_string(_temperature));
            speed_of_wind = Normalize_string(_speed_of_wind);
            pressure = Normalize_string(_pressure);
            humidity = _humidity;
        }

        public string GetHumidity()
        {
            return humidity;
        }

        public string GetPressure()
        {
            return pressure;
        }

        public string GetWindSpeed()
        {
            return speed_of_wind;
        }

        public int GetTemperature()
        {
            return temperature;
        }

        public string GetTImeOfDay()
        {
            return time_of_day;
        }

        public string Normalize_string(string str)
        {
            List<string> result = new List<string>();
            string buffer = str.Replace("&nbsp", "").Replace("\n", "").Replace("&", "").Replace(";", "").Replace("\t", "");
            string buf = "";
            for (int index = 0; index < buffer.Length; ++index)
            {
                if (buffer[index] != ' ')
                {
                    buf += buffer[index];
                }
                else
                {
                    if (buf.Length > 0)
                    {
                        result.Add(buf.Replace("minus", "-"));
                        buf = "";
                    }
                } 
            }

            if (buffer.Length != 0)
            {
                result.Add(buf.Replace("minus", "-"));
            }

            return String.Join(" ", result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://pogoda.e1.ru/print/w3d/";
            HtmlWeb page = new HtmlWeb();
            var _document = page.Load(url);
            Dictionary<string, List<Weather>> forecast = new Dictionary<string, List<Weather>>();

            for (int index = 1; index <= 3; ++index)
            {
                int count_time = _document.DocumentNode.SelectNodes(string.Format("/html/body/div/div[2]/table[1]/tr[2]/td[{0}]/div", index)).Count;
                List<Weather> days_info = new List<Weather>();
                for (int time_of_days = 1; time_of_days <= count_time; ++time_of_days)
                {
                    Weather day_forecast = new Weather(
                    _document.DocumentNode.SelectNodes(string.Format("/html[1]/body[1]/div[1]/div[2]/table[1]/tr[{0}]/td[2]/div[{1}]", index, time_of_days))[0].InnerHtml,
                    _document.DocumentNode.SelectNodes(string.Format("/html[1]/body[1]/div[1]/div[2]/table[1]/tr[{0}]/td[3]/div[{1}]", index, time_of_days))[0].InnerHtml,
                    _document.DocumentNode.SelectNodes(string.Format("/html[1]/body[1]/div[1]/div[2]/table[1]/tr[{0}]/td[5]/div[{1}]", index, time_of_days))[0].InnerText,
                    _document.DocumentNode.SelectNodes(string.Format("/html[1]/body[1]/div[1]/div[2]/table[1]/tr[{0}]/td[6]/div[{1}]", index, time_of_days))[0].InnerHtml,
                     _document.DocumentNode.SelectNodes(string.Format("/html[1]/body[1]/div[1]/div[2]/table[1]/tr[{0}]/td[7]/div[{1}]", index, time_of_days))[0].InnerHtml
                    );
                    days_info.Add(day_forecast);
                }
                forecast.Add(_document.DocumentNode.SelectNodes(string.Format("/html[1]/body[1]/div[1]/div[2]/table[1]/tr[{0}]/td[1]/div/strong", index))[0].InnerHtml, days_info);
            }

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("forecast 3-days");
            worksheet.Cell("A1").Value = "Прогноз погоды на 3 дня";
            worksheet.Cell("A1").Style.Font.Bold = true;
            worksheet.Cell("A2").Value = "День недели";
            worksheet.Cell("B2").Value = "Время суток";
            worksheet.Cell("C2").Value = "Температура";
            worksheet.Cell("D2").Value = "Скорость и направление ветра";
            worksheet.Cell("E2").Value = "Атмосферное давление";
            worksheet.Cell("F2").Value = "Влажность";

            int row_number = 3;
            
            foreach (var key in forecast.Keys)
            {
                worksheet.Cell(string.Format("A{0}", row_number)).Value = key;
                for (int index = 0; index < forecast[key].Count; ++index, ++row_number)
                {
                    worksheet.Cell(string.Format("B{0}", row_number)).Value = forecast[key][index].GetTImeOfDay();
                    worksheet.Cell(string.Format("C{0}", row_number)).Value = forecast[key][index].GetTemperature();
                    worksheet.Cell(string.Format("D{0}", row_number)).Value = forecast[key][index].GetWindSpeed();
                    worksheet.Cell(string.Format("E{0}", row_number)).Value = forecast[key][index].GetPressure();
                    worksheet.Cell(string.Format("F{0}", row_number)).Value = forecast[key][index].GetHumidity();
                }
                row_number += 1;
            }

            workbook.SaveAs("forecast.xlsx");

            Console.WriteLine("Запись данных успешно соверешена.");
            Console.ReadLine();
        }
    }
}
