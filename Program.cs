using backward_chainalgo;
using forward_chainalgo;
namespace aiproject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("*    Expert System for Career Advising        * ");
            Console.WriteLine("*********************************************** ");
            int op;//variable for switch case
            // Main program
            string profession = "", area = "";
            int flag = 1;
            backward_chain obj1 = new backward_chain();
            forward_chain obj2 = new forward_chain();

            while (flag != 0)
            {
                Console.WriteLine("Enter an option: 1. Recommend a Profession and area  2. Stop Program");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Starting the system to detemine the profession ... ");
                        Console.WriteLine("Enter YES or NO for each question asked.. ");
                        profession = obj1.ProfessionBW();
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("Recommended Profession is: " + profession);
                        Console.WriteLine("------------------------------------------------------- ");
                        Console.WriteLine("Starting system to determine AREA for the profession: " + profession);
                        Console.WriteLine("Enter YES or NO for each question asked.. ");
                        area = obj2.AreaFW(profession);
                        if (area != "")
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("Recommended area is: " + area);
                            Console.WriteLine("------------------------------------------------------- ");
                            Console.WriteLine("Program exited.. ");
                            flag = 0;
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("Sorry could not determine the area" + area);
                            Console.WriteLine("------------------------------------------------------- ");
                            Console.WriteLine("Program exited.. ");
                            flag = 0;
                        }

                        break;

                    case 2:
                        flag = 0;
                        break;
                    default:
                        Console.WriteLine("Invalid choice entered. ");
                        flag = 0;
                        break;
                }
            }
        }
    }
}