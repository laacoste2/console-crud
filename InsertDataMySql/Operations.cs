using MySql.Data.MySqlClient;

namespace ConsoleCrud
{
    internal class Operations
    {
        public static void addToDataBase(string connString)
        {
            Console.WriteLine("Type the person's name: ");
            string addPersonName = Console.ReadLine();

            Console.WriteLine("Type the person's surname: ");
            string addPersonSurname = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                
                conn.Open();

                string query = "INSERT INTO persons (name, surname) VALUES (@value1, @value2)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@value1", addPersonName);
                    cmd.Parameters.AddWithValue("@value2", addPersonSurname);

                    cmd.ExecuteNonQuery();
                }
            }
            Console.Clear();
        }

        public static void deleteFromDataBase(string connString) 
        {
            Console.WriteLine("Type the ID that you want to remove: ");
            int removePerson = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();

                string query = "DELETE from persons WHERE id=@value";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@value", removePerson);

                    cmd.ExecuteNonQuery();
                }
            }
            Console.Clear();
        }

        public static void updateDataBase(string connString)
        {
            Console.WriteLine("Type the ID that you want to update: ");
            int updatePerson = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the new name: ");
            string updateName = Console.ReadLine();

            Console.WriteLine("Type the new surname: ");
            string updateSurname = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE persons SET name=@name, surname=@surname WHERE id=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", updatePerson);
                    cmd.Parameters.AddWithValue("@name", updateName);
                    cmd.Parameters.AddWithValue("@surname", updateSurname);

                    cmd.ExecuteNonQuery();
                }
            }
            Console.Clear();
        }

        public static void viewDataBase(string connString)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM persons";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("id      name    surname\n");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"]}\t{reader["name"]}\t{reader["surname"]}");
                        }
                    }
                }
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
