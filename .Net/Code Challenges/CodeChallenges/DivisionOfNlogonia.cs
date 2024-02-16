namespace CodeChallenges
{
    public class DivisionOfNlogonia
    {

        public void Location()
        {

            while (true)
            {
                try
                {

                    int vezes = Convert.ToInt32(Console.ReadLine());

                    if (vezes == 0) { break; }

                    string[] batata = Console.ReadLine().Split(' ');

                    int a = Convert.ToInt32(batata[0]);
                    int b = Convert.ToInt32(batata[1]);

                    for (int i = 0; i < vezes; i++)
                    {
                        string[] batata2 = Console.ReadLine().Split(' ');
                        int x = Convert.ToInt32(batata2[0]);
                        int y = Convert.ToInt32(batata2[1]);
                        if (x == a || y == b)
                        {
                            Console.WriteLine("divisa");
                        }
                        if (x < a && y < b)
                        {
                            Console.WriteLine("SO");
                        }
                        if (x > a && y < b)
                        {
                            Console.WriteLine("SE");
                        }
                        if (x < a && y > b)
                        {
                            Console.WriteLine("NO");
                        }
                        if (x > a && y > b)
                        {
                            Console.WriteLine("NE");
                        }

                    }
                }
                catch { }

            }
        }
    }
}
