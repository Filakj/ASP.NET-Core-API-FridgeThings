import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { SpoonacularapiService } from '../Services/spoonacularServices/spoonacularapi.service';

import { Recipe } from '../Models/fridgethingsModels/recipe';
import { spRecipe } from '../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../Models/spoonacularModels/spInstructions';


@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})


export class RecipeComponent implements OnInit {

  recipeById: Recipe = null;
  spInstructions: spInstructions[] = null;

  constructor(
    private route: ActivatedRoute, 
    private location: Location,
    private spApi: SpoonacularapiService,
    private recipeService: RecipeService
  ) { }

  ngOnInit(): void {
    this.getInstructionsById(); 
    this.getRecipeById();
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

  

}
