using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevConfGuid.Controllers
{
    public class ValuesController : ApiController
    {
        public string ConnectionString
        {
            get
            {
                return new Db().ConnectionString;
            }
        }

        // GET api/values/
        public string Get()
        {
            int result = 0;
            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "insert into Guids.dbo.guids (id) values('" + System.Guid.NewGuid().ToString() + "');";
                result = (int)command.ExecuteNonQuery();
            }

            List<string> res = new List<string>();
            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id from Guids.dbo.guids";
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res.Add((string)reader["id"]);
                        }
                    }
                }
            }

            return string.Join(",", res);
        }
    }
}
