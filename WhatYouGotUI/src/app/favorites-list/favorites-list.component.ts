import { Component, OnInit } from '@angular/core';
import { FavoriteService } from '../Services/fridgethingsServices/favorite.service';
import { Favorite } from '../Models/fridgethingsModels/favorite';

@Component({
  selector: 'app-favorites-list',
  templateUrl: './favorites-list.component.html',
  styleUrls: ['./favorites-list.component.css']
})
export class FavoritesListComponent implements OnInit {

  favorites: Favorite[];

  constructor(private favoriteService: FavoriteService) { }

  ngOnInit(): void {
    this.getFavorites();
  }

  getFavorites(): void {
    this.favoriteService.getFavorites()
    .then(favorites => this.favorites = favorites);
  }

  deleteFavorite(userId: number, recipeId: number) {
    this.favoriteService.deleteFavorite(userId, recipeId);
  }

}
