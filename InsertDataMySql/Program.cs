namespace ConsoleCrud
{
    class Program
    {
        static public void Main(string[] args)
        {
            string connString = "Server=localhost;Port=3306;Database=pessoas;Uid=root;Pwd=1234;";

            while (true)
            {
                Console.WriteLine("Choose a Option:");
                Console.WriteLine("[A]dd [R]emove [Update] [V]iew");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "A":
                        Operations.addToDataBase(connString);
                        break;

                    case "R":
                        Operations.deleteFromDataBase(connString);
                        break;
                    case "U":
                        Operations.updateDataBase(connString);
                        break;
                    case "V":
                        Operations.viewDataBase(connString);
                        break;

                }
            }

        }
    }
}