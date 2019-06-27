using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            //solution version 1.1
            string[] a = equation.Split(new char[]{'*','='}); //To split the A B C

            if(a[0].Contains('?'))                                 //if A contains ?
            {
                int A=0,B=Int32.Parse(a[1]),  C=Int32.Parse(a[2]), index=a[0].IndexOf('?');
                try
                {
                    A=C/B;                                      //avoiding Divide by zero
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine($"Division of {C} by zero.");
                }
                var aa=A.ToString();
                if((aa.Length == a[0].Length)&&(C%B==0))      //Check of integer and length of integer
                    return (int)Char.GetNumericValue(aa[index]);
                else
                    return -1;
            }

            if(a[1].Contains('?'))                               //if B contains ?
            {
                int B=0,A=Int32.Parse(a[0]),C=Int32.Parse(a[2]),index=a[1].IndexOf('?');
                try
                {
                    B=C/A;
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine($"Division of {B} by zero.");
                }
                var b=B.ToString();
                if((b.Length == a[1].Length)&&(C%A==0))
                    return (int)Char.GetNumericValue(b[index]);
                else
                    return -1;
            }

            if(a[2].Contains('?'))                                   //if C contains ?
            {
                int C=0,A=Int32.Parse(a[0]),B=Int32.Parse(a[1]),index=a[2].IndexOf('?');
                C=A*B;
                var c=C.ToString();
                if(c.Length == a[2].Length)
                    return (int)Char.GetNumericValue(c[index]);
                else
                    return -1;
                
            }
            else                                                   //if ? not present at all.
            {
                return -1;
            }
            
        }
    }
}
