using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ShopProject.Models
{
    public class DataStorage
    {
        private string filePath;

        public DataStorage(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveToJson<T>(T data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine("Data saved to JSON file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to JSON file: {ex.Message}");
            }
        }

        public T LoadFromJson<T>()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    T data = JsonConvert.DeserializeObject<T>(jsonData);
                    Console.WriteLine("Data loaded from JSON file.");
                    return data;
                }
                else
                {
                    Console.WriteLine("JSON file not found. Returning default data.");
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from JSON file: {ex.Message}");
                return default(T);
            }
        }
    }
}
