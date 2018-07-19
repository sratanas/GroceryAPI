using GroceryAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GroceryAPI.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {

        private readonly IConfiguration _configuration;

        public GroceryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetAllItems()
        {

            var connectionstring = _configuration.GetConnectionString("SqlServerConnection");
            //var connectionstring = "Data Source=L-SRATANAS;Initial Catalog=Grocery;Integrated Security=False";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Items";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    List<Item> response = new List<Item>();

                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new Item();

                            item.Id = Int32.Parse(reader["Id"].ToString());
                            item.ItemName = reader["ItemName"].ToString();

                            response.Add(item);

                            
                        }
                    }

                    var json = JsonConvert.SerializeObject(response);
                    return json;
                        

                }
            }

        }

        
    }
}
