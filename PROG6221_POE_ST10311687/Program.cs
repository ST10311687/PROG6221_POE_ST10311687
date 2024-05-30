using PROG6221_POE_ST10311687;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10311687
{
    internal class Program
    {
        // List of recipes
        public static List<Recipe> recipes = new List<Recipe>();
        // Delegate instance for calorie notification
        public static Recipe.CalorieNotificationHandler calorieNotifier = message => Console.WriteLine(message);

        static void Main(string[] args)
        {
            // Infinite loop to keep the program running until the user decides to exit
            while (true)
            {
                //Menu that allows user to enter a number coresponding to an action
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n1. Add a Recipe");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("2. Display a Recipe");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("3. Scale a Recipe");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("4. Reset a Quantities");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("5. Clear a Recipe");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("6. Exit");
                Console.ResetColor();

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                // Perform an action based on the user's choice
                switch (choice)
                {
                    case 1:
                        Recipe.EnterRecipeDetails(recipes);
                        break;
                    case 2:
                        Recipe.DisplayRecipe(recipes, calorieNotifier);
                        break;
                    case 3:
                        Recipe.ScaleRecipe(recipes);
                        break;
                    case 4:
                        Recipe.ResetQuantities(recipes);
                        break;
                    case 5:
                        Recipe.ClearRecipe(recipes);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}

#region Reference List
/* Troelsen, A.and Japikse, P. 2024. Pro C# 9 with .NET 5.
New York: Apress.

CamSoper, 2024. Unit testing C# in .NET. Unit testing C# in .NET, 7 March, p. 5.

Koshy, B., 2019. Stack overflow. [Online] 
Available at: https://stackoverflow.com/questions/2019402/when-why-to-use-delegates
[Accessed 28 May 2024].
*/

#endregion
//============================================================ EndOfProgram ============================================================//
