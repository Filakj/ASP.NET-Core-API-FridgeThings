import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { spRecipe } from '../../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../../Models/spoonacularModels/spInstructions';

@Injectable({
  providedIn: 'root'
})

export class SpoonacularapiService {
  constructor(private httpClient: HttpClient) { }
  
  apiKey = 'apiKey=683db520cb5443d595329feb7f9907bb';
  baseUrl = 'https://api.spoonacular.com/recipes/';
  
  //assumes that listOfIngredients will be a comma-separated list of ingredients
  getRecipesByIngredients(listOfIngredients: string): Promise<spRecipe[]> {
    var ingredientsUrlSegment = `findByIngredients?ingredients=${listOfIngredients}`;
    var rankingUrlSegment = `ranking=2`; // minimize missing ingredients first
    var completeUrl = `${this.baseUrl}${ingredientsUrlSegment}&${this.apiKey}&${rankingUrlSegment}`;
    
    console.log(completeUrl);
    return this.httpClient.get<spRecipe[]>(completeUrl).toPromise();
  }

  getInstructionsByRecipeId(id: number): Promise<spInstructions[]> {
    var idUrlSegment = `${id}/analyzedInstructions`;
    var completeUrl = `${this.baseUrl}${idUrlSegment}?${this.apiKey}`;

    console.log(completeUrl);
    return this.httpClient.get<spInstructions[]>(completeUrl).toPromise();
  }
}
