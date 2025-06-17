using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppTask.Libraries.Synchronizations
{
    public class SyncData
    {
        private static string _key = "sync.date";

        public static DateTimeOffset? GetLastSyncDate()
        {
            var jsonDate =  Preferences.Default.Get<string>(_key, null);

            return (string.IsNullOrEmpty(jsonDate))? null : JsonSerializer.Deserialize<DateTimeOffset?>(jsonDate);
        }

        public static void SetLastSyncDate(DateTimeOffset date)
        {
            var jsonDate = JsonSerializer.Serialize(date);
            Preferences.Default.Set(_key, jsonDate);
        }
    }
}
