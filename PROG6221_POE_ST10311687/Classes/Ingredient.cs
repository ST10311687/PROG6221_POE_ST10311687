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
