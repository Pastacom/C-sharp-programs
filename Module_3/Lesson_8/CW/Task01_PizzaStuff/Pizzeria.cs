using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStuff
{
    public class Pizzeria
    {
        // Склад для ингредиентов. Хранит количество каждого ингредиента.
        private Dictionary<Ingredients, int> storage = new();

        public Pizzeria()
        {
            foreach (Ingredients ingredient in Enum.GetValues(typeof(Ingredients)))
            {
                storage.Add(ingredient, 0);
            }
        }
        /// <summary>
        /// Привозит новые ингредиенты на склад.
        /// Увеличивает количество ингредиента ingredients на значение amount.
        /// </summary>
        /// <param name="ingredients"> Ингредиент, который будет привезен на склад. </param>
        /// <param name="amount"> Количество ингредиента. </param>
        public void DeliverIngredient(Ingredients ingredients, int amount)
        {
            storage[ingredients] += amount;
        }

        /// <summary>
        /// Возвращет информацию о количестве каждого ингредиента на складе.
        /// </summary>
        public (string name, int amount)[] GetStorage()
        {
            var arr = new (string name, int amount)[storage.Keys.Count];
            int counter = 0;
            foreach (Ingredients ingredient in Enum.GetValues(typeof(Ingredients)))
            {
                arr[counter] = (ingredient.ToString(), storage[ingredient]);
                counter++;
            }
            return arr;
        }

        /// <summary>
        /// Готовит пиццу по рецепту.
        /// </summary>
        /// <param name="recipe"> Рецепт пиццы. </param>
        /// <returns> Приготовленная пицца. </returns>
        /// <exception cref="PizzaException"> Если на складе не хватает ингредиентов, чтобы приготовить пиццу по рецепту.</exception>
        public Pizza MakePizza(PizzaRecipe recipe)
        {
            if(HasIngredients(recipe))
            {
                UseIngredients(recipe);
                return new Pizza(recipe);
            }
            else
            {
                throw new PizzaException($"Not enough ingredients to make {recipe.Name}");
            }
        }

        public Pizza[] CompleteOrder(PizzaRecipe[] recipes)
        {
            List<Pizza> pizzas = new();
            foreach (PizzaRecipe recipe in recipes)
            {
                if (HasIngredients(recipe))
                {
                    UseIngredients(recipe);
                    pizzas.Add(new Pizza(recipe));
                }
                else
                {
                    throw new PizzaException($"Not enough ingredients to make {recipe.Name}");
                }
            }
            return pizzas.ToArray();
        }

        /// <summary>
        /// Проверяет, есть ли на складе ингредиенты для рецепта.
        /// </summary>
        /// <param name="recipe"> Рецепт, наличие ингредиентов необходимо проверить. </param>
        /// <returns> true, если все ингредиенты есть на складе, false иначе. </returns>
        private bool HasIngredients(PizzaRecipe recipe)
        {
            Ingredients ingredients = recipe.Ingredients;
            foreach(Ingredients ingredient in Enum.GetValues(typeof(Ingredients)))
            {
                if((ingredient & ingredients) != 0 && storage[ingredient] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Удаляет со склада по одному ингредиенту из рецепта.
        /// </summary>
        /// <param name="recipe"></param>
        private void UseIngredients(PizzaRecipe recipe)
        {
            Ingredients ingredients = recipe.Ingredients;
            foreach (Ingredients ingredient in Enum.GetValues(typeof(Ingredients)))
            {
                if ((ingredient & ingredients) != 0)
                {
                    storage[ingredient]--;
                }
            }
        }
    }
}
