import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { spRecipe } from '../../Models/spoonacularModels/spRecipe';
import { spInstructions } from '../../Models/spoonacularModels/spInstructions';
import { ErrorService } from 'src/app/error.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SpoonacularapiService {
  constructor(private httpClient: HttpClient, private errorHandler: ErrorService) { }

  //apiKey = 'apiKey=683db520cb5443d595329feb7f9907bb'; rodney
  //apiKey = 'apiKey=76aa18cfa10048aebc2fa569d3738526'

  //apiKey = 'apiKey=683db520cb5443d595329feb7f9907bb';
  // apiKey = 'apiKey=76aa18cfa10048aebc2fa569d3738526';
  apiKey = 'apiKey=dd43c4c314084e53a2f2581a986f48ac';
  baseUrl = 'https://api.spoonacular.com/recipes/';
  
  //assumes that listOfIngredients will be a comma-separated list of ingredients
  getRecipesByIngredients(listOfIngredients: string): Promise<spRecipe[]> {
    var ingredientsUrlSegment = `findByIngredients?number=12&ignorePantry=false&ingredients=${listOfIngredients}`;
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
