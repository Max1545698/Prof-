using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeHistory
{
    public class HistoryItem
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public DateTime VisitedTime { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            string chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+ @"\Google\Chrome\User Data\Default\History";
            if (File.Exists(chromeHistoryFile))
            {
                SqliteConnection connection = new SqliteConnection
                ("Data Source=" + chromeHistoryFile + ";Version=3;New=False;Compress=True;");
                connection.Open();
                DataSet dataset = new DataSet();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter
                ("select * from urls order by last_visit_time desc", connection);
                adapter.Fill(dataset);
                if (dataset != null && dataset.Tables.Count > 0 & dataset.Tables[0] != null)
                {
                    DataTable dt = dataset.Tables[0];
                    allHistoryItems = new List<HistoryItem>();
                    foreach (DataRow historyRow in dt.Rows)
                    {
                        HistoryItem historyItem = new HistoryItem();
                        {
                            URL = Convert.ToString(historyRow["url"]),
Title = Convert.ToString(historyRow["title"])


                    };
                        // Chrome stores time elapsed since Jan 1, 1601 (UTC format) in microseconds
                        long utcMicroSeconds = Convert.ToInt64(historyRow["last_visit_time"]);
                        // Windows file time UTC is in nanoseconds, so multiplying by 10
                        DateTime gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds);
                        // Converting to local time
                        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);
                        historyItem.VisitedTime = localTime;
                        allHistoryItems.Add(historyItem);
                    }
                }
            }
        }
    }
}
