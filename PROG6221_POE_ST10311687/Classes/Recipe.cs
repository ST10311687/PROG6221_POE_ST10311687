using System;
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