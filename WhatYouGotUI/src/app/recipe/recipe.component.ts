import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { SpoonacularapiService } from '../Services/spoonacularServices/spoonacularapi.service';

import { Recipe } from '../Models/fridgethingsModels/recipe';
import { spRecipe } from '../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../Models/spoonacularModels/spInstructions';

import { Ingredient } from '../Models/fridgethingsModels/ingredient';
import {IngredientService} from '../Services/fridgethingsServices/ingredient.service';

import { Favorite } from '../Models/fridgethingsModels/favorite';
import { FavoriteService } from '../Services/fridgethingsServices/favorite.service';


@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})


export class RecipeComponent implements OnInit {
  recipeId = +this.route.snapshot.paramMap.get('id');
  recipeById: Recipe = null;
  spInstructions: spInstructions[] = null;

  ingredients: Ingredient[] = null;

  role: number;


  constructor(
    private route: ActivatedRoute, 
    private location: Location,
    private spApi: SpoonacularapiService,
    private recipeService: RecipeService,
    private ingredientService: IngredientService,
    private favoriteService: FavoriteService
  ) { }

  ngOnInit(): void {
    this.getInstructionsById(); 
    this.getRecipeById();
    this.getIngredientsByRecipeId();

    localStorage.setItem('recipeId', `${this.recipeId}`);
    this.role = +localStorage.getItem('Account Id');

  }

  getIngredientsByRecipeId(): void{ 
  const id = + this.route.snapshot.paramMap.get('id');
  console.log(id);
  this.ingredientService.getIngredientByRecipeId(id)
    .then(response => this.ingredients = response);
  }

  getInstructionsById(): void {
    const id = + this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.spApi.getInstructionsByRecipeId(id)
      .then(response => this.spInstructions = response);
  }

  getRecipeById(): void {
    const id = + this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.recipeService.getRecipeById(id)
        .then(response => this.recipeById = response);
  }

  addToFavorites(userId: number, recipeId: number) {

    let fave: Favorite = {userId: userId, recipeId: recipeId }

    this.favoriteService.postFavorite(fave).subscribe();
  }

  readLocalStorageValue(key: string): string {
    return localStorage.getItem(key);
}

}
