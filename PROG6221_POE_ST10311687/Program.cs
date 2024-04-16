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
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipeDetails();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.Write("Enter scaling factor (a = 0.5, b = 2, or c = 3): ");
                        char factor = char.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        recipe.ClearRecipe();
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
         New York: Apress.*/
#endregion
//============================================================ EndOfProgram ============================================================//
