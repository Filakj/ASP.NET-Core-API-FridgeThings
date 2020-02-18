import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../Services/fridgethingsServices/review.service';
import { Review } from '../Models/fridgethingsModels/review';


@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  constructor(private reviewService: ReviewService) { }

  ngOnInit(): void {
  }

  recipeId = +localStorage.getItem('recipeId');
  userId = +localStorage.getItem('Account Id');
  addReview(rating: number, comment: string) {
    console.log(`User Id: ${this.userId}`);
    console.log(`Recipe Id: ${this.recipeId}`);
    var review: Review = {userId: this.userId, recipeId: this.recipeId, rating: +rating, comment: comment}
    console.log(review);
    this.reviewService.postReview(review).subscribe();
  }
}
