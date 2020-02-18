import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../Services/fridgethingsServices/review.service';
import { Review } from '../Models/fridgethingsModels/review';
import { ReviewComponent } from '../review/review.component';
import { RecipeService } from '../Services/fridgethingsServices/recipe.service';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {
  recipeId = +localStorage.getItem('recipeId');
  recipeTitle: string;
  reviews: Review[] = null;

  constructor(private reviewService: ReviewService, private recipeService: RecipeService) { }

  ngOnInit(): void {
    this.getReviewsByRecipeId();
    this.getRecipeTitle();
  }

  getReviewsByRecipeId(): void {
    this.reviewService.getReviewsByRecipeId(this.recipeId)
      .then(reviews => this.reviews = reviews);  // getReviews() should be an observable (or maybe not)
  }

  deleteReview(id: number): void {
    this.reviewService.deleteReview(id);
  }

  getRecipeTitle(): void {
    this.recipeService.getRecipeById(this.recipeId)
      .then(recipe => this.recipeTitle = recipe.title);
  }

}
