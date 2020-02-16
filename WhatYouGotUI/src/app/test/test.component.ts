import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { SpoonacularapiService } from '../Services/spoonacularServices/spoonacularapi.service';
import { Recipe } from '../Models/fridgethingsModels/recipe';
import { spRecipe } from '../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../Models/spoonacularModels/spInstructions';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {  
  spRecipes: spRecipe[] = null;
  spInstructions: spInstructions[] = null;

  recipes: Recipe[] = null;
  recipeById: Recipe = null;
  
  constructor(private recipeService: RecipeService, private spApi: SpoonacularapiService) { }

  //using fridgethingsapi.service
  getRecipes(): void {
    this.recipeService.getRecipes()
        .then(response => this.recipes = response);
  }

  getRecipeById(id: number): void {
    this.recipeService.getRecipeById(id)
        .then(response => this.recipeById = response);
  }

  postRecipe(recipeId: number, recipeTitle: string, recipeImageUrl: string): void {
    recipeTitle = recipeTitle.trim();
    recipeImageUrl = recipeImageUrl.trim();
    var newRecipe: Recipe = {
      id: +recipeId,
      title: recipeTitle,
      imageUrl: recipeImageUrl
    }
    this.recipeService.postRecipe(newRecipe).subscribe(
      (data: Recipe) => {console.log(data);},
      (error: any) => {console.log(error)}
      );
  }

  putRecipe(recipeId: number, recipeTitle: string, recipeImageUrl: string): void {
    recipeTitle = recipeTitle.trim();
    recipeImageUrl = recipeImageUrl.trim();
    var newRecipe: Recipe = {
      id: +recipeId,
      title: recipeTitle,
      imageUrl: recipeImageUrl
    }
    this.recipeService.putRecipe(newRecipe).subscribe(
      (data: Recipe) => {console.log(data);},
      (error: any) => {console.log(error)}
      );
  }

  deleteRecipe(id: number): void {
    id = +id;
    this.recipeService.deleteRecipe(id).subscribe();
  }

  // using spoonacularsapi.service
  getRecipesFromSpoonacular(): void {
    var tempIngredients = 'chicken,brocolli,pasta';
    this.spApi.getRecipesByIngredients(tempIngredients)
      .then(response => this.spRecipes = response);
  }

  getInstructionsFromSpoonacular(): void {
    var tempRecipeId = 1009580;
    this.spApi.getInstructionsByRecipeId(tempRecipeId)
      .then(response => this.spInstructions = response);
  }
  
  ngOnInit(): void {

  }

}
