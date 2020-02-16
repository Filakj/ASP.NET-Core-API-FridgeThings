import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Recipe } from '../../Models/fridgethingsModels/recipe';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(private httpClient: HttpClient) { }

  recipeUrl = 'http://fridgethingsapi.azurewebsites.net/api/Recipes/' 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getRecipes(): Promise<Recipe[]> {
    console.log(this.recipeUrl);
    return this.httpClient.get<Recipe[]>(this.recipeUrl).toPromise();
  }

  getRecipeById(id: number): Promise<Recipe> {
    var completeUrl = `${this.recipeUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.get<Recipe>(completeUrl).toPromise();
  }

  postRecipe(newRecipe: Recipe): Observable<Recipe> {
    console.log(this.recipeUrl);
    console.log(newRecipe);
    return this.httpClient.post<Recipe>(this.recipeUrl, newRecipe, this.httpOptions);
  }

  putRecipe(newRecipe: Recipe): Observable<any> {
    var completeUrl = `${this.recipeUrl}${newRecipe.id}`;
    console.log(completeUrl);
    return this.httpClient.put(completeUrl, newRecipe, this.httpOptions);
  }

  deleteRecipe(id: number): Observable<Recipe> {
    var completeUrl = `${this.recipeUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.delete<Recipe>(completeUrl, this.httpOptions);
  }
}
