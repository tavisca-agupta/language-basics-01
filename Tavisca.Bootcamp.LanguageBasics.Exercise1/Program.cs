using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
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
            // Add your code here.
            string[] a = equation.Split(new char[]{'*','='}); //To split the A B C
            if(a[0].Contains('?')) //if A contains ?
            {
                int B=Int32.Parse(a[1]),C=Int32.Parse(a[2]),index=a[0].IndexOf('?');
                var A1=C/B;
                var aa=A1.ToString();
                if((aa.Length == a[0].Length)&&(C%B==0))
                    return (int)Char.GetNumericValue(aa[index]);
                else
                    return -1;
            }
            if(a[1].Contains('?')) //if B contains ?
            {
                int A=Int32.Parse(a[0]),C=Int32.Parse(a[2]),index=a[1].IndexOf('?');
                var B=C/A;
                var b=B.ToString();
                if((b.Length == a[1].Length)&&(C%A==0))
                    return (int)Char.GetNumericValue(b[index]);
                else
                    return -1;
            }
            else //if C contains ?
            {
                int A=Int32.Parse(a[0]),B=Int32.Parse(a[1]),index=a[2].IndexOf('?');
                var C=A*B;
                var c=C.ToString();
                if(c.Length == a[2].Length)
                    return (int)Char.GetNumericValue(c[index]);
                else
                    return -1;
                
            }
            
            throw new NotImplementedException();
        }
    }
}
