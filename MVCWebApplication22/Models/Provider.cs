using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using jsonN = Newtonsoft.Json;

namespace MVCWebApplication22.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public String State { get; set; }

        //private static string connectionString = @"Data Source=DESKTOP-37UDTFK\VIKASSQL;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing";
        //public static DataSet GetProviderData()
        //{

        //    SqlConnection conn = new SqlConnection(connectionString);


        //    conn.Open();
        //    SqlCommand command = new SqlCommand("select * from Provider", conn);
        //    SqlDataAdapter adaptor = new SqlDataAdapter(command);
        //    DataSet ds = new DataSet();
        //    adaptor.Fill(ds);
        //    return ds;
        //}


        private static string connectionString = @"Data Source=DESKTOP-37UDTFK\VIKASSQL;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing";
        private const string baseAddress = "http://localhost/FirstWebApi/";

        public static List<Provider> GetProviderDataAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/FirstWebApi/");
            var response = client.GetAsync("api/provider");                       // create a call to api
            var value = response.Result.Content.ReadAsStringAsync().Result;       // getting response i.e value


            var providerResult = jsonN.JsonConvert.DeserializeObject<List<Provider>>(value);

            return providerResult;
        }

        public static Provider GetProviderDataByProviderId(int id)
        {

            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand command = new SqlCommand($"select * from Provider where providerid = {id}", conn);
            //SqlDataAdapter adaptor = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();
            //adaptor.Fill(ds);
            //return ds;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/FirstWebApi/");

            var response = client.GetAsync("api/provider/" + id);

            var providerResult = jsonN.JsonConvert.DeserializeObject<Provider>(response.Result.Content.ReadAsStringAsync().Result);

            return providerResult;
        }


        internal void InsertProvider(Provider p)
        {

            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"insert into Provider (ProviderName, ProviderType) values ('{p.ProviderName}','{p.ProviderType}')";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/FirstWebApi/");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.PostAsJsonAsync<Provider>("api/provider", p);
        }

        internal void UpdateProvider(Provider p)
        {
          
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"update provider set providertype='{p.ProviderType}', providername='{p.ProviderName}' where providerid={p.ProviderId}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal static void DeleteProvider(int p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"Delete provider where providerid={p}";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/FirstWebApi/");

            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DeleteAsync("api/provider"+p);


        }

        internal static string GetValues()                      
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost/FirstWebApi/ValueApi/SearchOrders/12");
            return result.Result.Content.ReadAsStringAsync().Result;
        }               
    }
}