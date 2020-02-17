import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Favorite } from '../../Models/fridgethingsModels/favorite';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FavoriteService {

  constructor(private httpClient: HttpClient) { }

  favoriteUrl = 'http://fridgethingsapi.azurewebsites.net/api/Favorites/' 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getFavorites(): Promise<Favorite[]> {
    console.log(this.favoriteUrl);
    return this.httpClient.get<Favorite[]>(this.favoriteUrl).toPromise();
  }

  getFavoriteById(id: number): Promise<Favorite> {
    var completeUrl = `${this.favoriteUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.get<Favorite>(completeUrl).toPromise();
  }

  postFavorite(newFavorite: Favorite): Observable<Favorite> {
    console.log(this.favoriteUrl);
    console.log(newFavorite);
    return this.httpClient.post<Favorite>(this.favoriteUrl, newFavorite, this.httpOptions);
  }

  putFavorite(newFavorite: Favorite): Observable<any> {
    var completeUrl = `${this.favoriteUrl}${newFavorite.id}`;
    console.log(completeUrl);
    return this.httpClient.put(completeUrl, newFavorite, this.httpOptions);
  }

  deleteFavorite(id: number): Observable<Favorite> {
    var completeUrl = `${this.favoriteUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.delete<Favorite>(completeUrl, this.httpOptions);
  }
}