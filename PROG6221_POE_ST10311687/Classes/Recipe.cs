using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Recipe
{
    private List<Ingredient> ingredients;
    private List<Step> steps;
    public string recipeName { get; set; }
    private static char response;
    private float PreviousScale = 1;
    public delegate void CalorieNotificationHandler(string message);

    public Recipe()
    {
        ingredients = new List<Ingredient>();
        steps = new List<Step>();
    }
    /// <summary>
    /// This method allows the user to enter information about a recipe. This includes the recipes name, amount of ingredients, details of ingredients and the amount of steps in the recipe
    /// </summary>
    public static void EnterRecipeDetails(List<Recipe> recipes)
    {
        Recipe recipe = new Recipe();
        Console.WriteLine("What would you like to call your recipe: ");
        recipe.recipeName = Console.ReadLine();
        Console.WriteLine("Enter the number of ingredients: ");
        int ingredientCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < ingredientCount; i++)
        {
            Console.WriteLine($"Enter details for ingredient " + (i + 1) + ":");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Quantity of " + name + ": ");
            float quantity = float.Parse(Console.ReadLine());

            Console.Write("Unit of measure for " + name + ": ");
            string unit = Console.ReadLine();

            Console.Write("Number of calories for " + name + ": ");
            int calories = int.Parse(Console.ReadLine());

            Console.Write("Food group for " + name + ": ");
            string foodGroup = Console.ReadLine();

            recipe.ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        }

        Console.WriteLine("How many steps are in the " + recipe.recipeName + " recipe?");
        int stepCount = int.Parse(Console.ReadLine());
        recipe.steps = new List<Step>(stepCount);

        for (int i = 0; i < stepCount; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            string description = Console.ReadLine();
            recipe.steps.Add(new Step(description));
        }
        recipes.Add(recipe);
        Console.Clear();
    }
    /// <summary>
    /// This method allows the user to diplay all the detail they have entered for a recipe
    /// </summary>
    /// 


    public static void DisplayRecipe(List<Recipe> recipes, CalorieNotificationHandler calorieNotifier)
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes to display. Please add a recipe first.");
            return;
        }

        // Sort the recipes in alphabetical order
        var sortedRecipes = recipes.OrderBy(r => r.recipeName).ToList();

        Console.WriteLine("Select a recipe to display:");
        for (int i = 0; i < sortedRecipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedRecipes[i].recipeName}");
        }

        int recipeChoice;
        if (!int.TryParse(Console.ReadLine(), out recipeChoice) || recipeChoice < 1 || recipeChoice > sortedRecipes.Count)
        {
            Console.WriteLine("Invalid choice. Please select a valid recipe number.");
            return;
        }

        Recipe selectedRecipe = sortedRecipes[recipeChoice - 1];

        if (selectedRecipe.ingredients == null || selectedRecipe.steps == null)
        {
            Console.WriteLine($"No details to display for recipe: {selectedRecipe.recipeName}. Please enter recipe details first.");
            return;
        }

        Console.WriteLine("Recipe: " + selectedRecipe.recipeName);

        Console.WriteLine("\nIngredients: ");
        float totalCalories = 0;
        foreach (var ingredient in selectedRecipe.ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}\nCalories: {ingredient.Calories}\nFood Group: {ingredient.FoodGroup}");
            totalCalories += ingredient.Calories * ingredient.Quantity;
        }

        Console.WriteLine($"Total Calories: {totalCalories}");

        // Notify if total calories exceed 300
        if (totalCalories > 300)
        {
            calorieNotifier?.Invoke($"The total calories for {selectedRecipe.recipeName} exceed 300 calories.");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < selectedRecipe.steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {selectedRecipe.steps[i].Description}");
        }
        Console.WriteLine("\n===============================================================");
    }




    /// <summary>
    /// This method is used to change the scale factor of the quantity of ingredients
    /// </summary>
    /// <param name="Scalefactor"></param>
    /// <exception cref="Exception"></exception>
    public static void ScaleRecipe(List<Recipe> recipes)
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes to scale. Please add a recipe first.");
            return;
        }

        Console.WriteLine("Select a recipe to scale:");
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].recipeName}");
        }

        int recipeChoice;
        if (!int.TryParse(Console.ReadLine(), out recipeChoice) || recipeChoice < 1 || recipeChoice > recipes.Count)
        {
            Console.WriteLine("Invalid choice. Please select a valid recipe number.");
            return;
        }

        Recipe selectedRecipe = recipes[recipeChoice - 1];

        Console.Write("Enter scaling factor (a = 0.5, b = 2, or c = 3): ");
        char factor = char.Parse(Console.ReadLine());

        float Scale;
        if (factor == 'a')
        {
            Scale = 0.5f;
        }
        else if (factor == 'b')
        {
            Scale = 2;
        }
        else if (factor == 'c')
        {
            Scale = 3;
        }
        else
        {
            Console.WriteLine("Invalid scale factor!");
            return;
        }

        if (selectedRecipe.ingredients == null)
        {
            Console.WriteLine("No ingredients to scale. Please enter recipe details first.");
            return;
        }

        for (int i = 0; i < selectedRecipe.ingredients.Count; i++)
        {
            selectedRecipe.ingredients[i].Quantity *= Scale;
        }

        selectedRecipe.PreviousScale = Scale;
        Console.WriteLine("Scaled recipe by a factor of: " + Scale);
        Console.Clear();
    }

    /// <summary>
    /// This method is used to set any previously scaled ingredients back to their original values.
    /// </summary>
    public static void ResetQuantities(List<Recipe> recipes)
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes to reset. Please add a recipe first.");
        }
        else
        {
            Console.WriteLine("Select a recipe to reset:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].recipeName}");
            }
            int recipeChoice = int.Parse(Console.ReadLine());
            Recipe selectedRecipe = recipes[recipeChoice - 1];

            if (selectedRecipe.ingredients == null)
            {
                Console.WriteLine("No ingredients to reset. Please enter recipe details first.");
                return;
            }

            for (int i = 0; i < selectedRecipe.ingredients.Count; i++)
            {
                selectedRecipe.ingredients[i].Quantity /= selectedRecipe.PreviousScale;
            }
            Console.WriteLine("Quantities have been reset by " + selectedRecipe.PreviousScale);
            Console.Clear();
        }
    }


    /// <summary>
    /// This method simply clears all the values of ingredients and steps
    /// </summary>
    public static void ClearRecipe(List<Recipe> recipes)
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes to clear. Please add a recipe first.");
        }
        else
        {
            Console.WriteLine("Select a recipe to clear:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].recipeName}");
            }
            int recipeChoice = int.Parse(Console.ReadLine());
            Recipe selectedRecipe = recipes[recipeChoice - 1];

            if (selectedRecipe.ingredients == null && selectedRecipe.steps == null)
            {
                Console.WriteLine("No recipe to clear.");
                return;
            }

            Console.WriteLine("Are you sure you want to clear the recipe? (Y/N)");
            char response = Console.ReadKey().KeyChar;
            if (response == 'Y' || response == 'y')
            {
                selectedRecipe.ingredients = null;
                selectedRecipe.steps = null;
                Console.WriteLine("\nRecipe cleared.");
            }
            else
            {
                Console.WriteLine("\nOperation cancelled.");
            }
        }
    }


}

//============================================================ EndOfProgram ============================================================//