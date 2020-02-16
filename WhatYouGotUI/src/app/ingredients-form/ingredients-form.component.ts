import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { SpoonacularapiService } from '../Services/spoonacularServices/spoonacularapi.service';

import { Recipe } from '../Models/fridgethingsModels/recipe';
import { spRecipe } from '../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../Models/spoonacularModels/spInstructions';


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

  constructor(private fb: FormBuilder, private spApi: SpoonacularapiService) { }

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



