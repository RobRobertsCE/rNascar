using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace NascarApi.Simulation.Adapters
{
    abstract class JsonRepository<T, Key> : Repository<T, Key> where T : IKeyedItem<Key>, new()
    {
        private string _filepath;

        protected JsonRepository(string fileName)
            : base()
        {

            _filepath = GetFilePath(fileName);
            _items = Load();
        }

        protected override List<T> Load()
        {
            if (!File.Exists(_filepath))
                return new List<T>();

            var json = File.ReadAllText(_filepath);

            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        protected override void SaveChanges()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var content = JsonConvert.SerializeObject(
                    _items,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(_filepath, content);
        }

        private static string GetFilePath(string fileName)
        {
            return $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\{fileName}";
        }
    }
}
