using MONTHSGET;
using System.Data.SqlClient;

namespace monthsGet
{
    internal class Program
    {
        static void Main()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // Замените на свою строку подключения


            Console.WriteLine(GetMonthNameById(connectionString, 2)); 
            Console.WriteLine(GetMonthNameById(connectionString, 11));
            Console.WriteLine(GetMonthNameById(connectionString, 13));
        }

        static string GetMonthNameById(string connectionString, int monthId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                // Создание команды SQL
                string sql = "SELECT name FROM Months WHERE id = @monthId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Добавление параметра
                    command.Parameters.AddWithValue("@monthId", monthId);

                    // Выполнение запроса
                    object result = command.ExecuteScalar();

                    // Проверка наличия результата
                    if (result! != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
    }
}