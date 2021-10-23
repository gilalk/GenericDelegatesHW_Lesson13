using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GenericDelegatesHW_Lesson13
{
    class Program
    {

        #region Q1 - Smallest Number

        static Func<int, int, int, int> FindTheSmallestNumber = (x, y, z) =>
        {
            if (x <= y && x <= z) { return x; }
            else if (y <= x && y <= z) { return y; }
            else { return z; }
        };

        #endregion

        #region Q2 - AVG

        static Action<int, int, int> GetAverageOfThreeNumbers = (x, y, z) =>
        {
            Console.WriteLine(Convert.ToDouble(x + y + z) / 3);
        };

        #endregion

        #region Q3 - Middle Character

        static Action<string> GetMiddleCharacter = (str) =>
        {
            int len = str.Length;

            if (len % 2 == 0)
            {
                Console.WriteLine("{0}{1}", str[(len / 2) - 1], str[len / 2]);
            }
            else
            {
                Console.WriteLine(str[len / 2]);
            }
        };

        #endregion

        #region Q4 - Count The Vowels

        static Action<string> CountTheVowels = (str) =>
        {
            int counter = 0;
            var myPattern = @"[AOIUEaoiue]";
            var regex = new Regex(myPattern);

            foreach (var character in str)
            {
                if (regex.IsMatch(character.ToString()))
                {
                    counter++;
                }
            }
            Console.WriteLine($"Number Of Vowels in String is: {counter}");
        };

        #endregion

        #region Q5 - Count The Words

        static Func<string, int> CountTheWords = (str) =>
        {
            string[] words = str.Split(' ');
            return words.Length;
        };

        #endregion

        #region Q6 - Sum The Int Digits

        static Action<string> SumTheIntDigits = (num) =>
        {
            var pattern = @"^\d*$";
            var regex = new Regex(pattern);
            int counter = 0;
            if (regex.IsMatch(num))
            {
                foreach (var character in num)
                {
                    counter += int.Parse(character.ToString());
                }
                Console.WriteLine($"The sum of the digits is : {counter}");
            }
            else { Console.WriteLine("This is not a number!"); }
        };

        #endregion

        #region Q7 - Pentagonal Numbers

        static Action<int> GetPentagonalNumbers = (n) =>
        {
            int counter = 0;
            int[] PentNumbers = new int[n];
            for (int i = 1; i <= n; i++)
            {
                PentNumbers[i - 1] = (i * (3 * i - 1)) / 2;
            }

            for (int j = 0; j < n; j++)
            {
                Console.Write(PentNumbers[j] + "\t");
                counter++;
                if (counter % 10 == 0) { Console.WriteLine(); }
            }
            Console.WriteLine();
        };

        #endregion

        #region Q8 - Future Investments

        static Action<double, double, double> FutureValueByYear = (investAmount, interestRate, years) =>
        {
            for (int i = 1; i <= years; i++)
            {
                double val = investAmount * Math.Pow(1 + ((interestRate / 100) / 12), i * 12);
                Console.WriteLine($"Year number: {i} \t Future value: {val}");
            }
        };

        #endregion

        #region Q9 - Print The Chars

        static Action<char, char, int> PrintChars = (firstChacr, secondChar, n) =>
        {
            if (firstChacr <= secondChar)
            {
                for (int i = firstChacr; i < secondChar; i++)
                {
                    Console.Write(firstChacr++ + " ");
                    if ((i + 1) % n == 0) { Console.WriteLine(); }
                }
            }
            else
            {
                char temp = firstChacr;
                firstChacr = secondChar;
                secondChar = temp;
                for (int i = firstChacr; i < secondChar; i++)
                {
                    Console.Write(firstChacr++ + " ");
                    if ((i + 1) % n == 0) { Console.WriteLine(); }
                }
            }
        };

        #endregion

        #region Q10 - Check if The Year is Leap or Not

        static Predicate<int> CheckIfLeapYear = (year) =>
        {
            return DateTime.IsLeapYear(year);
        };

        #endregion

        #region Q11 - Validate Password

        static Action<string> ValidatePassword = (password) =>
        {
            var pattern = @"^[a-zA-Z0-9]{0,10}$";
            var regex = new Regex(pattern);

            if (regex.IsMatch(password))
            {
                Console.WriteLine("Password is Valid!");
            }
            else
            {
                Console.WriteLine("Invalid Password!");
            }
        };

        #endregion

        #region Q12 - nXn Matrix with Random (0,1)

        static Action<int> CreateMatrix = (n) =>
        {
            int[,] myMat = new int[n,n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    myMat[i, j] = random.Next(2);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(myMat[i,j] + "\t");
                }
                Console.WriteLine();
            }
        };

        #endregion

        #region Q13 - Get the Area of Triangle by Heron Formula

        static Func<double, double, double, double> GetTriangleAreaByHeron = (side1, side2, side3) =>
           {
               double s = (side1 + side2 + side3) / 2;
               double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
               return area;
           };

        #endregion

        #region Q14 - Get Equilateral Pentagon Area Two Ways

        static Action<double> GetEquilateralPentagonAreaBySideLength = (side) =>
        {
            double sidePoweredByTwo = Math.Pow(side, 2);
            double partOfTheFormula = Math.Sqrt(25 + 10 * Math.Sqrt(5));

            Console.WriteLine((sidePoweredByTwo / 4) * partOfTheFormula);
        };

        static Action<double> GetEquilateralPentagonAreaBySideAndApothem = (side) =>
        {
            double ang = (Math.PI / 180) * (54);
            double apothem = (side / 2) * Math.Tan(ang);
            double perimeter = side * 5;
            Console.WriteLine((apothem * perimeter) / 2);
        };

        #endregion

        #region Q15 - Get Today Date and Time

        static Func<DateTime> GetTodayDateAndTime = () =>
        {
            return DateTime.Now;
        };

        #endregion

        #region Q16 - Get Twin Prime Numbers from 1 to 100

        static Predicate<int> IsPrime = (num) =>
        {
            int div = (int)Math.Floor(Math.Sqrt(num));
            for (int i = div; i > 1; i--)
            {
                if (num % i == 0) { return false; }
            }
            return true;
        };

        static Action<int> GetTwinPrimeNumbers = (fromOneTo) =>
        {
            for (int i = 2; i <= fromOneTo; i++)
            {
                if(IsPrime(i) && IsPrime(i + 2))
                {
                    Console.WriteLine($"({i} , {i + 2})");
                }
            }
        };

        #endregion

        static void Main(string[] args)
        {
            // Q1 use

            Console.WriteLine(FindTheSmallestNumber(23, 45, 12));

            // Q2 use

            GetAverageOfThreeNumbers(20, 12, 30);

            // Q3 use

            GetMiddleCharacter("231");
            GetMiddleCharacter("231456");

            // Q4 use

            CountTheVowels("Gil");
            CountTheVowels("Avia");
            CountTheVowels("nkanewcpowe");
            CountTheVowels("l;wkenf2pf");

            // Q5 use

            Console.WriteLine(CountTheWords("The quick brown fox jumps over the lazy dog"));

            // Q6 use

            SumTheIntDigits("123");
            SumTheIntDigits("2345");
            SumTheIntDigits("123");
            SumTheIntDigits("f423");
            SumTheIntDigits("6056247356");

            // Q7 use

            GetPentagonalNumbers(5);
            Console.WriteLine();
            GetPentagonalNumbers(15);
            Console.WriteLine();
            GetPentagonalNumbers(25);
            Console.WriteLine();
            GetPentagonalNumbers(50);

            // Q8 use

            FutureValueByYear(1000, 10, 5);
            FutureValueByYear(10000, 10, 10);

            // Q9 use

            PrintChars('(', 'z', 20);

            // Q10 use

            Console.WriteLine();
            Console.WriteLine(CheckIfLeapYear(2010));
            Console.WriteLine(CheckIfLeapYear(2011));
            Console.WriteLine(CheckIfLeapYear(2012));

            // Q11 use

            ValidatePassword("434njln");
            ValidatePassword("434njlnfrs");
            ValidatePassword("434njln3hue");
            ValidatePassword("434njln$");

            // Q12 use

            CreateMatrix(10);
            CreateMatrix(5);

            // Q13 use

            Console.WriteLine(GetTriangleAreaByHeron(10, 15, 20));

            // Q14 use

            GetEquilateralPentagonAreaBySideLength(6);
            GetEquilateralPentagonAreaBySideAndApothem(6);

            // Q15 use

            Console.WriteLine(GetTodayDateAndTime());

            // Q16 use

            // Check if 'IsPrime' is working
            Console.WriteLine(IsPrime(12));
            Console.WriteLine(IsPrime(13));
            Console.WriteLine(IsPrime(25));
            Console.WriteLine(IsPrime(29));
            Console.WriteLine(IsPrime(341));

            GetTwinPrimeNumbers(100);
            GetTwinPrimeNumbers(300);
        }
    }
}
