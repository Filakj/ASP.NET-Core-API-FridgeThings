import { Component, OnInit } from '@angular/core';
import { FavoriteService } from '../Services/fridgethingsServices/favorite.service';
import { Favorite } from '../Models/fridgethingsModels/favorite';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-favorites-list',
  templateUrl: './favorites-list.component.html',
  styleUrls: ['./favorites-list.component.css']
})
export class FavoritesListComponent implements OnInit {

  favorites: Favorite[];

  constructor(
    private favoriteService: FavoriteService,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.getFavorites(+localStorage.getItem('Account Id'));
  }

  getFavorites(userId: number): void {
    const uid = +this.route.snapshot.paramMap.get('uid');
    this.favoriteService.getFavoritesById(userId)
    .then(favorites => this.favorites = favorites);
  }

  deleteFavorite(userId: number, recipeId: number) {
    this.favoriteService.deleteFavorite(userId, recipeId);
  }

}
