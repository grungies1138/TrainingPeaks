using System.Text.Json;
using TrainingPeaks.Models;
using TrainingPeaks.Utility;

namespace TrainingPeaks.Data;

internal static class ImportData 
{
    public static List<T> ImportDataFile<T>(string file)
    {
        
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.Converters.Add(new DateTimeConverter());

        using (StreamReader r = new StreamReader(file))
        {
            string json = r.ReadToEnd();
            List<T> data = JsonSerializer.Deserialize<List<T>>(json, options);
            return data;
        }
    }
}