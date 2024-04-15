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
    /// 
    /// </summary>
    public void EnterRecipeDetails()
    {
        Console.WriteLine("What would you like to call your recipe: ");
        recipeName = Console.ReadLine();
        Console.WriteLine("Enter the number of ingredients: ");
        int ingredientCount = int.Parse(Console.ReadLine());
        ingredients = new Ingredient[ingredientCount];

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
    }
}