using System;
using System.Collections.Generic;
using System.Linq;



namespace recipe poe
{
    //delegate displays a notification to the user when user exceeds 300 calories

    public delegate void delDisplayNotification();


    //manages the recipe where you can modify recipes
    public class RecipeManager
    {

        public int calorie;

     
    private List<Recipe> recipes;
    
    private List<RecipeCopy> copiedRecipes;


        int choice = 0;




        public RecipeManager()
        {
            
            recipes = new List<Recipe>();
            copiedRecipes = new List<RecipeCopy>();/

        }
    //method will notify if user exceeds 300 calories 
    public static void DisplayNotification()
        {
           Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Attention!!! The recipe exceeds 300 calories!" + "\n" + "This means that the recipe is high in calories compared to other recipes." + "\n" + "Please consider portion sizes and overall dietary balance when consuming high-calorie recipes");
            Console.ForegroundColor = ConsoleColor.White;
        }


    //method for when the user enters a recipe
        public void EnterRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\t\tENTER RECIPE");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;





           
            bool addingRecipe = false;

            while (addingRecipe == false)
            {
                Recipe recipe = new Recipe();
                RecipeCopy recipe2 = new RecipeCopy();




                bool isRecipeNameValid = false;

           
            while (isRecipeNameValid.Equals(false))
                {
                    Console.WriteLine("Enter recipe name:");
                    recipe.Name = Console.ReadLine();
                //This also applies to exception handling, these conditions need to be met for ingredient name which includes values not to be null/empty, should only contain letters 
                if (recipe.Name.Any(x => char.IsDigit(x)) || String.IsNullOrEmpty(recipe.Name))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!Invalid input, Please Re-enter the name of recipe");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        isRecipeNameValid = true;
                        break;
                    }
                }
                recipe2.Name = recipe.Name;


                recipe.Ingredients = new List<Ingredient>();
                recipe2.Ingredient2 = new List<IngredientCopy>();
                recipe.Instructions = new List<Step>();



                bool addingIngredients = true;



            //This will make the user being constantly prompted to enter the ingredients until the user wishes to exit
            while (addingIngredients)
                {
                    Ingredient ingredient = new Ingredient();
                    IngredientCopy ingredient2 = new IngredientCopy();


                    Console.WriteLine("Enter ingredient name (or 'done' to finish):");
                    string ingredientName = Console.ReadLine();

                    
                    if (ingredientName.ToLower().Equals("done"))
                    {
                        addingIngredients = false;
                        break;
                    }

                    ingredient.Name = ingredientName;
                    ingredient2.Name = ingredientName;

                    bool isQuantityValid = false;
                    while (isQuantityValid.Equals(false))

                    {

                     
                        try
                        {
                        //This is the quantity of ingredient
                            Console.WriteLine("Enter quantity:");
                            ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                            ingredient2.Quantity = ingredient.Quantity;
                            isQuantityValid = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reenter quantities.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    bool isUnitValid = false;
                    while (isUnitValid.Equals(false))

                    {
                        try
                        {
                            Console.WriteLine("Please select the unit of measurement:" + "\n" + "1. Pinch" + "\n" + "2. Teaspoon" + "\n" + "3. Tablespoon" + "\n" + "4. Cup" + "\n" + "5. Pint\n" + "6. Quarts");
                            int choice1 = Convert.ToInt32(Console.ReadLine());
                            if (choice1 == 1)
                            {
                                ingredient.UnitOfMeasurement = "Pinch";
                                ingredient2.UnitOfMeasurement = "Pinch";
                            }

                            if (choice1 == 2)
                            {
                                ingredient.UnitOfMeasurement = "Teaspoon";
                                ingredient2.UnitOfMeasurement = "Teaspoon";
                            }
                            if (choice1 == 3)
                            {
                                ingredient.UnitOfMeasurement = "Tablespoon";
                                ingredient2.UnitOfMeasurement = "Tablespoon";

                            }
                            if (choice1 == 4)
                            {
                                ingredient.UnitOfMeasurement = "Cup";
                                ingredient2.UnitOfMeasurement = "Cup";
                            }
                            if (choice1 == 5)
                            {
                                ingredient.UnitOfMeasurement = "Pint";
                                ingredient2.UnitOfMeasurement = "Pint";
                            }
                            if (choice1 == 6)
                            {
                                ingredient.UnitOfMeasurement = "Quart";
                                ingredient2.UnitOfMeasurement = "Quart";
                            }
                            isUnitValid = true;
                        }

                    //Checks and catches any possible exceptions that will arise
                    catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reselect unit of measurement.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    bool isCaloriesValid = false;

                //This will result in the user being constantly prompted to enter the appropriate value
                while (isCaloriesValid.Equals(false))
                    {
                    //Overall this will try the following prompts and if it catches an exception/error, it will display the appropriate message and will let the user re-enter the value
                    try
                    {
                        //This is the calories for the ingredient
                            Console.WriteLine("Enter food calories:");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("This is the amount of energy released when your body breaks down the food you have eaten. The more calories a food has, the more energy it can provide to your body throughout the day but when you eat more calories than you need, your body stores the extra calories as body fat" + "\n" + "So be careful of how many calories your recipe has.");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Enter food calories here:");
                            ingredient.Calories = Convert.ToInt32(Console.ReadLine());
                            isCaloriesValid = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reenter calories.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    calorie = ingredient.Calories;
                    ingredient2.Calories = ingredient.Calories;

                    bool isFoodGroupValid = false;

                //This will result in the user being constantly prompted to enter the appropriate value
                while (isFoodGroupValid.Equals(false))
                    {

                    //Overall this will try the following prompts and if it catches an exception/error, it will display the appropriate message and will let the user re-enter the value
                    try
                    {
                            Console.WriteLine("Please select the food group:" + "\n" + "1. Starchy foods" + "\n" + "2. Vegetable and fruits" + "\n" + "3. Dry beans, peas, lentils and soya" + "\n" + "4. Chicken, fish, meat and eggs" + "\n" + "5. Milk and dairy products" + "\n" + "6. Fats and oil" + "\n" + "7. Water");
                            int choice3 = Convert.ToInt32(Console.ReadLine());

                            if (choice3 == 1)
                            {
                            //for all these if statements below, when the user selects a food group, the selected value gets assigned to the food group property
                            ingredient.FoodGroup = "Starchy foods";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }

                            if (choice3 == 2)
                            {
                                ingredient.FoodGroup = "Vegetable and fruits";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            if (choice3 == 3)
                            {
                                ingredient.FoodGroup = "Dry beans, peas, lentils and soya";

                            }
                            if (choice3 == 4)
                            {
                                ingredient.FoodGroup = "Chicken, fish, meat and eggs";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            if (choice3 == 5)
                            {
                                ingredient.FoodGroup = "Milk and dairy products";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            if (choice3 == 6)
                            {
                                ingredient.FoodGroup = "Fats and oil";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }

                            if (choice3 == 7)
                            {
                                ingredient.FoodGroup = "Water";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            isFoodGroupValid = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reselect food group.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    recipe.Ingredients.Add(ingredient);
                    recipe2.Ingredient2.Add(ingredient2);
                    int totalCalories = CalculateTotalCalories(recipe.Ingredients);


                }



                bool addingInstructions = true;
                while (addingInstructions)
                {


                    Step instruction = new Step();
                    bool isInstructionValid = false;

                //results in users being constantly prompted to enter correct values
                while (isInstructionValid.Equals(false))
                    {
                        Console.WriteLine(" Kindly Enter instructions or enter done to complete:");
                        string instructions = Console.ReadLine();
                        if (instructions.ToLower().Equals("done"))
                        {
                            addingInstructions = false;
                            break;
                        }
                    //This also applies to exception handling, these conditions need to be met for ingredient name which includes values not to be null/empty, should only contain letters
                    if (instructions.Any(x => char.IsDigit(x)) || String.IsNullOrEmpty(instructions))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Kindly Re-enter the instructions ");
                            Console.ForegroundColor = ConsoleColor.White;
                            isInstructionValid = true;
                        }
                        else
                        {
                            isInstructionValid = true;
                            break;
                        }

                       
                        instruction.Steps = instructions;
                        recipe.Instructions.Add(instruction);

                    }
                }

                recipes.Add(recipe);
                copiedRecipes.Add(recipe2);
               //Used to sort the recipe names in alphabetical order
               recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.OrdinalIgnoreCase));


              

                Console.WriteLine("INGREDIENTS ENTERED ARE CORRECT");

                Console.WriteLine("Press 1 to enter another recipe or any key to continue to main menu");
                string choice4 = Console.ReadLine();

                if (choice4.Equals("1"))
                {
                    addingRecipe = false;
                    addingInstructions = true;
                    addingIngredients = true;
                }
                else
                {
                    addingRecipe = true;
                    addingInstructions = false;
                    addingIngredients = false;
                }

            }







        }
        public int CalculateTotalCalories(List<Ingredient> ingredients)
        {
            delDisplayNotification printDelegate = new delDisplayNotification(DisplayNotification);

            int total = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                total += ingredient.Calories;
            }

            if (total > 300)
            {

                printDelegate();

            }



            return total;
        }
         //This method is to amend the quantity of ingredients by scaling, converting units of measurement
         public void AlterQuantity()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\t\tSCALE QUANTITY");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------");
            Console.Clear();
            Console.WriteLine("List of recipes:");
            int recipeIndex = 1;

            foreach (Recipe recipe in recipes)
            {

                Console.WriteLine($"{recipeIndex}. {recipe.Name}");
                recipeIndex++;
            }

            Console.Write("Select a recipe (enter the corresponding number): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedRecipeIndex))
            {
                if (selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)
                {

              
                Recipe recipeToScale = recipes[selectedRecipeIndex - 1];
                    double comma;
                    foreach (Ingredient ingredient in recipeToScale.Ingredients)
                    {
                        Console.WriteLine("Please select if you wish to:" + "\n" + "1. Half the quantity" + "\n" + "2. Double the quantity" + "\n" + "3. Triple the quantity" + "\n" + "4. Reset to defaut values");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 1)
                        {
                        //if user chooses 1 to half the ingredients, the quanity of the ingredient will be halfed with this arithemtic operation
                        ingredient.Quantity = ingredient.Quantity * 0.5;

                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Pinch"))
                            {
                                comma = ingredient.Quantity / 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";


                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity * 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pinch";
                            }
                            if (ingredient.Quantity >= 3 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity / 3;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity * 3;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";
                            }
                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity / 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity * 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity / 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            if ((ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Pint")))
                            {
                                comma = ingredient.Quantity * 
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Pint"))
                            {
                                comma = ingredient.Quantity / 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Quart";
                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Quart"))
                            {
                                comma = ingredient.Quantity * 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            Console.Clear();
                            Console.WriteLine("Recipe scaled successfully");


                            
                            return;
                        }

                        if (choice == 2)
                        {

                            ingredient.Quantity = ingredient.Quantity * 2;


                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Pinch"))
                            {
                                comma = ingredient.Quantity / 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";


                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity * 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pinch";
                            }
                            if (ingredient.Quantity >= 3 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity / 3;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity * 3;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";
                            }
                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity / 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity * 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity / 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            if ((ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Pint")))
                            {
                                comma = ingredient.Quantity * 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Pint"))
                            {
                                comma = ingredient.Quantity / 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Quart";
                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Quart"))
                            {
                                comma = ingredient.Quantity * 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                           
                        }
                        if (choice == 3)
                        {

                            ingredient.Quantity = ingredient.Quantity * 3; 


                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Pinch"))
                            {
                                comma = ingredient.Quantity / 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";


                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity * 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pinch";
                            }
                            if (ingredient.Quantity >= 3 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity / 3;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity * 3;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";
                            }
                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity / 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity * 16;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity / 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            if ((ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Pint")))
                            {
                                comma = ingredient.Quantity * 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Pint"))
                            {
                                comma = ingredient.Quantity / 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Quart";
                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Quart"))
                            {
                                comma = ingredient.Quantity * 2;
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }

                            Console.Clear();
                            Console.WriteLine("Recipe is scaled successfully");


                            return;
                        


                        }

                        if (choice == 4)
                        {
                            if (selectedRecipeIndex > 0 && selectedRecipeIndex <= copiedRecipes.Count)
                            {
                                Recipe recipeToReset = recipes[selectedRecipeIndex - 1];
                                RecipeCopy recipe2 = copiedRecipes[selectedRecipeIndex - 1];
                                foreach (Ingredient ingredient1 in recipeToReset.Ingredients)
                                    recipeToReset.Ingredients = recipe2.Ingredient2.Select(Ingredient2 => new Ingredient
                                    {
                                        Name = Ingredient2.Name,
                                        Quantity = Ingredient2.Quantity,
                                        UnitOfMeasurement = Ingredient2.UnitOfMeasurement,
                                        Calories = Ingredient2.Calories,
                                        FoodGroup = Ingredient2.FoodGroup,
                                    }).ToList();
                            }
                            Console.Clear();
                            Console.WriteLine("Recipe reset successfully");


                           
                            return;
                        }
                     
                    }
                    Console.Clear();
                    Console.WriteLine("Recipe scaled successfully");



                    return;
                }
            }


            else
            {
                Console.WriteLine("Recipe is not found.");
            }
        }

        public void DisplayAllRecipes()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\t\tDISPLAY RECIPE");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            string input = null;
            foreach (Recipe recipe in recipes)//It gets the recipe instance in the recipe class to view the recipe
            {
                if (recipe.Name.Equals(null))
                {

                    break;

                }

                else
                {
                    int recipeIndex = 1;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("List of recipes:");
                     
                    Console.WriteLine($"{recipeIndex}. {recipe.Name}");
                    recipeIndex++;
                    Console.WriteLine("----------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Select a recipe (enter the corresponding number): ");//Use a number to slect the recipes displayed
                    input = Console.ReadLine();
                }
            }



            if (int.TryParse(input, out int selectedRecipeIndex))
            {
            //Checks to see if the recipe is identified and exists
            if (selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)
                {
                //Fetch the recipe based its position searched for
                    Recipe selectedRecipe = recipes[selectedRecipeIndex - 1];
                    int totalCalories = CalculateTotalCalories(selectedRecipe.Ingredients);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Clear();    
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"\t\t\tRecipe: {selectedRecipe.Name.ToUpper()}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("----------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("INGREDIENTS:");
                    Console.ForegroundColor = ConsoleColor.White;

                    foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                    {
                        if (ingredient.Quantity > 1 && ingredient.UnitOfMeasurement.EndsWith("ch")) that it represents a plural, this is for pinches
                        {
                            Console.WriteLine(ingredient.Quantity + " " + ingredient.UnitOfMeasurement + "es " + "of " + ingredient.Name);
                        }
                        else if (ingredient.Quantity > 1)
                        {

                            Console.WriteLine("- " + ingredient.Quantity + " " + ingredient.UnitOfMeasurement + "s " + "of " + ingredient.Name);


                        }
                        else if (ingredient.Quantity <= 1) it represents a plural, this is for pinches
                        {


                            Console.WriteLine("- " + ingredient.Quantity + " " + ingredient.UnitOfMeasurement + " of " + ingredient.Name);

                        }



                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("INSTRUCTIONS:");
                    Console.ForegroundColor = ConsoleColor.White;
                    int index = 1;

                    foreach (Step instruction in selectedRecipe.Instructions)
                    {
                        index++;
                        Console.WriteLine("Step " + index + " " + instruction.Steps);
                    }

                //Uses a total calories variable that was assigned the total calories method to determine the calorie range for the total calories
                Console.WriteLine("Total calories is: " + totalCalories);

                    if (totalCalories < 100)
                    {
                        Console.WriteLine("Calorie Range: Low (< 100)");
                    }
                    else if (totalCalories >= 100 && totalCalories < 300)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Calorie Range: Medium (100 - 299)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (totalCalories >= 300 && totalCalories < 500)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    //displays the calorie range
                    Console.WriteLine("Calorie Range: High (300 - 499)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (totalCalories >= 500)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Calorie Range: Very High (500 or more)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    Console.WriteLine("Press ENTER to continue to main menu");

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                    //when the user press ENTER the application returns to the main menu screen
                    return;
                       

                    }

                }

                else
                {
                    Console.WriteLine("Invalid recipe selection.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found, please enter recipe from the main menu.");
            }



        }

        public void DeleteRecipe()
        {
            Console.Clear();
            Console.WriteLine("List of recipes:");
            int recipeIndex = 1;

            foreach (Recipe recipe in recipes)
            {

                Console.WriteLine($"{recipeIndex}. {recipe.Name}");
                recipeIndex++;
            }

            Console.Write("Select a recipe (enter the corresponding number): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedRecipeIndex))
            {
                if (selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)
                {

                    Recipe recipeToRemove = recipes[selectedRecipeIndex - 1];
                    Console.WriteLine("Are you sure you want to remove recipe??" + "\n" + "Press 1 for yes and 2 for no");
                    int choice3 = Convert.ToInt32(Console.ReadLine());

                    if (choice3 > 1)
                    {
                        recipes.Remove(recipeToRemove);
                        Console.Clear();

                        Console.WriteLine("Recipe cleared successfully.");
                        return;
                    }
                    if (choice3 > 1)
                    {
                        return;
                    }
                }
            }
        }
    }
}
