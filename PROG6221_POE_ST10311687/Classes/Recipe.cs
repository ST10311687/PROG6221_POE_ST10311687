﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Unit { get; set; }

    /// <summary>
    /// Getters and setters for each ingredient
    /// </summary>
    /// <param name="name"></param>
    /// <param name="Quantity"></param>
    /// <param name="Unit"></param>
    public Ingredient(string name, float Quantity, String Unit)
    {
        this.Name = name;
        this.Quantity = Quantity;
        this.Unit = Unit;

    }
}

class Step
{
    public string Description { get; set; }

    public Step(string description)
    {
        Description = description;
    }
}

public class Recipe
{
    private Ingredient[] ingredients;
    private Step[] steps;
    private static string recipeName;
    private static char response;
    private float PreviousScale = 1;

    /// <summary>
    /// This method allows the user to enter information about a recipe. This includes the recipes name, amount of ingredients, details of ingredients and the amount of steps in the recipe
    /// </summary>
    public void EnterRecipeDetails()
    {
        Console.WriteLine("What would you like to call your recipe: ");
        recipeName = Console.ReadLine();
        Console.WriteLine("Enter the number of ingredients: ");
        int ingredientCount = int.Parse(Console.ReadLine());
        ingredients = new Ingredient[ingredientCount];
        //Loop for user to enter ingredient information
        for (int i = 0; i < ingredientCount; i++)
        {
            Console.WriteLine($"Enter details for ingredient " + (i + 1) + ":");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Quantity of " + name + ": ");
            float quantity = float.Parse(Console.ReadLine());

            Console.Write("Unit of measure for " + name + ": ");
            string unit = Console.ReadLine();
            //Storing ingredients into an array
            ingredients[i] = new Ingredient(name, quantity, unit);
        }
        Console.WriteLine("How many steps are in the " + recipeName + " recipe?");

        //Storing the amount of steps into an array
        int stepCount = int.Parse(Console.ReadLine());
        steps = new Step[stepCount];

        for (int i = 0; i < stepCount; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            string description = Console.ReadLine();
            steps[i] = new Step(description);
        }
        Console.Clear();
    }
    /// <summary>
    /// This method allows the user to diplay all the detail they have entered for a recipe
    /// </summary>
    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe: " + recipeName);

        Console.WriteLine("Ingredients: ");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i].Description}");
        }
        Console.WriteLine("\n===============================================================");
    }

    /// <summary>
    /// This method is used to change the scale factor of the quantity of ingredients
    /// </summary>
    /// <param name="Scalefactor"></param>
    /// <exception cref="Exception"></exception>
    public void ScaleRecipe(char Scalefactor)
    {
        float Scale;
        if (Scalefactor == 'a')
        {
            Scale = 0.5f;
        }
        else if (Scalefactor == 'b')
        {
            Scale = 2;
        }
        else if (Scalefactor == 'c')
        {
            Scale = 3;
        }
        else
        {
            throw new Exception("Invalid scale factor!");
        }
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].Quantity *= Scale;
        }
        PreviousScale = Scale;
        Console.WriteLine("Scaled recipe by a factor of: " + Scale);
        Console.Clear();
    }

    /// <summary>
    /// This method is used to set any previously scaled ingredients back to their original values.
    /// </summary>
    public void ResetQuantities()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].Quantity /= PreviousScale;
        }
        Console.WriteLine("Quantities have been reset by " + PreviousScale);
        Console.Clear();
    }

    /// <summary>
    /// This method simply clears all the values of ingredients and steps
    /// </summary>
    public void ClearRecipe()
    {
        ingredients = null;
        steps = null;
    }

}