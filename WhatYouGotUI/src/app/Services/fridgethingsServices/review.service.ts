import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Review } from '../../Models/fridgethingsModels/review';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private httpClient: HttpClient) { }

  reviewUrl = 'http://fridgethingsapi.azurewebsites.net/api/Reviews/' 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getReviews(): Promise<Review[]> {
    console.log(this.reviewUrl);
    return this.httpClient.get<Review[]>(this.reviewUrl).toPromise();
  }

  getReviewById(userId: number, recipeId: number): Promise<Review> {
    var completeUrl = `${this.reviewUrl}${userId}${recipeId}`;
    console.log(completeUrl);
    return this.httpClient.get<Review>(completeUrl).toPromise();
  }

  postReview(newReview: Review): Observable<Review> {
    console.log(this.reviewUrl);
    console.log(newReview);
    return this.httpClient.post<Review>(this.reviewUrl, newReview, this.httpOptions);
  }

  putReview(newReview: Review): Observable<any> {
    var completeUrl = `${this.reviewUrl}${newReview.userId}${newReview.recipeId}`;
    console.log(completeUrl);
    return this.httpClient.put(completeUrl, newReview, this.httpOptions);
  }

  deleteReview(id: number): Observable<Review> {
    var completeUrl = `${this.reviewUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.delete<Review>(completeUrl, this.httpOptions);
  }
}
