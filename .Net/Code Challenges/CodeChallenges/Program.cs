using System;

class URI
{

    static void Main(string[] args)
    {

        try
        {

            string[] batata = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(batata[0]);
            int b = Convert.ToInt32(batata[1]);

            var c = Convert.ToString(a, 2);
            var d = Convert.ToString(b, 2);
            char[] resp = new char[32];
            char[] arr1 = new char[32];
            char[] arr2 = new char[32];


            for (int i = 0; i< 32; i++)
                resp[i] = '0';

            int num0 = c.Length;

            for (int i = 0; i < 32 - num0; i++)
            {
                c = "0" + c;
            }

            int num1 = d.Length;

            for (int i = 0; i < 32 - num1; i++)
            {
                d = "0" + d;
            }

            arr1 = c.ToCharArray();
            arr2 = d.ToCharArray();


            for (int i = 0;i < 32; i++) 
            {
                if (arr1[i] =='1'&& arr2[i] == '1') 
                {
                    resp[i] = '0';
                }
                else if (arr1[i] == '1' || arr2[i] == '1')
                {
                    resp[i] = '1';
                }
            }
            string aaaaa = "";
            for (int i = 0;i< 32; i++)
            {
               aaaaa = aaaaa + resp[i];
            }
            
            //Console.WriteLine(arr1);
            //Console.WriteLine(aaaaa);
            Console.WriteLine(Convert.ToInt32(aaaaa,2));


        }
        catch(Exception e) { Console.WriteLine(e.Message); }


    }
}