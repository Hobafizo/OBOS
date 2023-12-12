using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OBOS.Models.Users;
using OBOS.Models.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OBOS.Database
{
    public static class Settings
    {
        public const string SettingFile = "settings.json";

        private static JsonSerializer GetSerializer()
        {
            JsonSerializer serializer = new JsonSerializer();

            serializer.Formatting = Formatting.Indented;
            serializer.DateFormatString = "dd/MM/yyyy hh:mm:ss";
            serializer.TypeNameHandling = TypeNameHandling.Objects;
            serializer.NullValueHandling = NullValueHandling.Ignore;

            return serializer;
        }

        public static bool Load()
        {
            bool result = false;

            JsonSerializer serializer = GetSerializer();

            using (StreamReader sw = new StreamReader(SettingFile))
            {
                using (JsonReader reader = new JsonTextReader(sw))
                {
                    Shop.SetInstance(serializer, reader);
                    result = true;
                }

                sw.Close();
            }

            return result;
        }

        public static bool Save()
        {
            bool result = false;

            JsonSerializer serializer = GetSerializer();

            using (StreamWriter sw = new StreamWriter(SettingFile))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, Shop.GetInstance());
                    result = true;
                }

                sw.Close();
            }

            return result;
        }
    }
}
