using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace ATS.DatabaseAdds
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("--路線情報取得完了--");

            var railData = new RailTableController();
            await railData.TimeScheduleDatabaseFetch();
        }
    }

    public class RailTableController
    {
        public IMobileServiceTable<Rail_Easy_Table> RailTable
        {
            get;
            set;
        }

        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://kyotonagoyamobileapp.azurewebsites.net"
        );

        public RailTableController()
        {
            RailTable = MobileService.GetTable<Rail_Easy_Table>();            
        }   

        public async Task TimeScheduleDatabaseFetch() 
        {
            var ts_items = await RailTable.Take(20).ToListAsync();

            foreach (var item in ts_items)
            {
                Console.WriteLine(item.Latitude);

            }

        }
    }

    public class Rail_Easy_Table
    {
        public string Id
        {
            get;
            set;
        }

        public string Company
        {
            get;
            set;
        }

        public string Line
        {
            get;
            set;
        }

        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }
    }
}
