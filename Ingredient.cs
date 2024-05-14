using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe poe
{
    //holds properties that represent the ingredients of a recipe
    public class Ingredient 
    {


    
    public string Name { get; set; } 
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }

        public string FoodGroup { get; set; }

    }
}
