using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Globalization;

namespace ReadHuaweiHealth
{
    public class DateTimeConverterUsingDateTimeParse : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                var x = reader.GetInt64();
                return epoch.AddMilliseconds(x);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.Converters.Add(new DateTimeConverterUsingDateTimeParse());
                var jsonString = File.ReadAllText("data/health detail data.json");
                var measurements = JsonSerializer.Deserialize<List<HealthData>>(jsonString, options);
                var hr = measurements
                 .Where(m => m.type == 7)
                 .Select(m => new Tuple<DateTime, double>(m.startTime, double.Parse(m.samplePoints[0].value)))
                 .OrderBy(m => m.Item1)
                 .ToList();
                 hr.ForEach(h=> Console.WriteLine($"{h.Item1.ToString("s",DateTimeFormatInfo.InvariantInfo)}\t{h.Item2}"));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
