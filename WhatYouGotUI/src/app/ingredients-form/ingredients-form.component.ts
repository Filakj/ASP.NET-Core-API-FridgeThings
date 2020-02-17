import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { SpoonacularapiService } from '../Services/spoonacularServices/spoonacularapi.service';

import { Recipe } from '../Models/fridgethingsModels/recipe';
import { spRecipe } from '../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../Models/spoonacularModels/spInstructions';

import { Ingredient } from '../Models/fridgethingsModels/ingredient';
import {IngredientService} from '../Services/fridgethingsServices/ingredient.service';


@Component({
  selector: 'app-ingredients-form',
  templateUrl: './ingredients-form.component.html',
  styleUrls: ['./ingredients-form.component.css']
})


export class IngredientsFormComponent implements OnInit {

  ingredientsForm: FormGroup;

  spRecipes: spRecipe[] = null;
  spInstructions: spInstructions[] = null;

  recipes: Recipe[] = null;
  recipeById: Recipe = null;
  //ingredientsString: string;

  constructor(
    private fb: FormBuilder,
    private spApi: SpoonacularapiService,
    private recipeService: RecipeService,
    private ingredientService: IngredientService
    ) 
    { }

  ngOnInit(): void {

    this.ingredientsForm = this.fb.group({
      ingredientsString: ''
    });

    //this.ingredientsString = "";


    /*
    this.ingredientsForm = new FormGroup({
      ingredientsString: new FormControl('') 
    });
    */



    /*
    this.ingredientsForm = this.fb.group({
      ingredients: this.fb.array([this.fb.group({ingredient: ''})])
    });
    */
  }//ngInit

  onSubmit(form: FormGroup) {
    console.log('Valid?', form.valid); // true or false
    console.log('Name', form.value.ingredientsString);

    var tempIngredients = form.value.ingredientsString;
    this.spApi.getRecipesByIngredients(tempIngredients)
      .then(response => this.spRecipes = response);
      
    console.log("posting recipies");
    console.log(this.spRecipes)
    console.log("values")
    //console.log(this.spRecipes.values)
    //this.postRecipes();
  }

  postRecipes(){ 

    this.spRecipes.forEach(recipe => {

      var newId = recipe.id;
      var newTitle = recipe.title;  
      var newImg = recipe.image; 
      this.postRecipe(newId, newTitle, newImg ); 

    });

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

  postIngredient(ingredientId: number, recipeId: number, ImageUrl: string, ingredientName: string, amount: number, unit: string): void {
    ingredientId = ingredientId;
    recipeId = recipeId; 
    ImageUrl = ImageUrl.trim(); 
    ingredientName = ingredientName.trim(); 
    amount = amount; 
    unit = unit.trim(); 
    var newIngredient: Ingredient = {
      id: +ingredientId,
      recipeId: +recipeId, 
      imageUrl: ImageUrl, 
      ingredientName: ingredientName, 
      amount: +amount,
      unit: unit
    }
    this.ingredientService.postIngredient(newIngredient).subscribe(
      (data: Ingredient) => {console.log(data);},
      (error: any) => {console.log(error)}
      );
  }


  get ingredientsList() {
    return this.ingredientsForm.get('ingredients') as FormArray;
  }

  addIngredient(){
    this.ingredientsList.push(this.fb.group({ingredient: ''}));
  }

  deleteIngredient(index){
    this.ingredientsList.removeAt(index);
  }

  retrieveRecipes(){


    

    

     // this.ingredientsForm.keys( this.ingredientsForm.controls).forEach(key => {
       // this.ingredientsString + key.valueOf(); 
        //this.ingredientsForm.controls[key].markAsDirty();
     }






    }



