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
          
             //splitting the given equation string
            string firstArg = equation.Split('*')[0];
            string secondArg = equation.Split('*')[1].Split('=')[0];
            string result = equation.Split('=')[1];

            //conditions to fulfill:
            //  1. No Integer value possible
            //  2. size is not equal(leading zeros)
            //  3. else return missing one digit


            //checking which one is faulty
            bool flag_firstArg = Int32.TryParse(firstArg, out int int_firstArg);
            bool flag_secondArg = Int32.TryParse(secondArg, out int int_secondArg);
            bool flag_result = Int32.TryParse(result, out int int_result);

            
            string updatedEquation = "";

            if(flag_firstArg == false){
                if(int_result % int_secondArg==0){                              //condtion 1
                    string temp = (int_result / int_secondArg) + "";
                    updatedEquation += temp + "*" + secondArg + "=" +result;
                }else 
                    return -1;
            }

            if(flag_secondArg == false){
                if(int_result % int_firstArg == 0){
                string temp = (int_result / int_firstArg) + "";
                updatedEquation += firstArg + "*" + temp + "=" +result;
                }else
                    return -1;
            }

            if(flag_result == false){
                string temp = (int_firstArg * int_secondArg) + "";
                updatedEquation += firstArg + "*" + secondArg + "=" +temp;
            }


            //condition 2
            if (equation.Length != updatedEquation.Length){
                return -1;
	        }else{
                //condition 3
                for (int i = 0; i < updatedEquation.Length; i++)
			    {
                    if(updatedEquation[i] != equation[i] && equation[i]=='?')
                        return (int)(updatedEquation[i] - '0');
			    }
            }
            throw new NotImplementedException();
        }
    }
}
