using BlogModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository.MySQL
{
    public class BlogRepository
    {
        private string connectionString = "server=192.168.1.156;user=root;database=my_blog;port=3306;password=123456";

        public List<Post> GetAll()
        {
            string sql = "select id,title,content from posts";
            var result = new List<Post>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Post()
                        {
                            id = int.Parse(reader["id"].ToString()),
                            Title = reader["title"].ToString(),
                            Content = reader["content"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
                finally {
                    connection.Close();
                }
            }
            return result;
        }
    }
}
