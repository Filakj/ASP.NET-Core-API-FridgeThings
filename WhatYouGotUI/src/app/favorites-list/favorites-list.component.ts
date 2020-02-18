import { Component, OnInit } from '@angular/core';
import { FavoriteService } from '../Services/fridgethingsServices/favorite.service';
import { Favorite } from '../Models/fridgethingsModels/favorite';
import { ActivatedRoute } from '@angular/router';


import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { Recipe } from '../Models/fridgethingsModels/recipe';


@Component({
  selector: 'app-favorites-list',
  templateUrl: './favorites-list.component.html',
  styleUrls: ['./favorites-list.component.css']
})
export class FavoritesListComponent implements OnInit {

  favorites: Favorite[];
  favoriteRecipes: Recipe[]; 
  curRecipe: Recipe; 

  constructor(
    private favoriteService: FavoriteService,
    private recipeService: RecipeService,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.getFavorites(+localStorage.getItem('Account Id'));
    this.getAllRecipes();
  }

  getFavorites(userId: number): void {
    console.log(userId);
    const uid = +this.route.snapshot.paramMap.get('uid');
    this.favoriteService.getFavoritesByUserId(userId)
    .then(Response => this.favorites = Response);
  }
  //for each favorite find recipe by id 
  getAllRecipes(){ 
    this.favorites.forEach(rec => {
      this.getRecipeById(rec.recipeId);
      
    });
  }
  //get recipe by id 
  
  getRecipeById(id: number): void {
    //const id = + this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.recipeService.getRecipeById(id)
        .then(response => this.curRecipe = response);
    this.favoriteRecipes.push(this.curRecipe); 
    this.curRecipe = null; 
  }
  //add recipe to array 

  



  deleteFavorite(userId: number, recipeId: number) {
    this.favoriteService.deleteFavorite(userId, recipeId);
  }

}
