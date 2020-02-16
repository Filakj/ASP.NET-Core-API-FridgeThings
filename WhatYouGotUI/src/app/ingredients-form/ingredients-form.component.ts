import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

@Component({
  selector: 'app-ingredients-form',
  templateUrl: './ingredients-form.component.html',
  styleUrls: ['./ingredients-form.component.css']
})
export class IngredientsFormComponent implements OnInit {

  ingredientsForm: FormGroup;
  ingredientsString: string;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {

    this.ingredientsForm = this.fb.group({
      ingredients: this.fb.array([this.fb.group({ingredient: ''})])
    });
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
    {

    }

    }
  }

}
