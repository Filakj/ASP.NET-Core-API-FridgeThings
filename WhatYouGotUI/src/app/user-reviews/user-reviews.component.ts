import { Component, OnInit } from '@angular/core';
import { Review } from '.././Models/fridgethingsModels/review';
import { ReviewService } from '../Services/fridgethingsServices/review.service';
import { RecipeService } from '../Services/fridgethingsServices/recipe.service';
import { ReviewWithTitles } from '../Models/uiModels/reviewWithTitle';

@Component({
  selector: 'app-user-reviews',
  templateUrl: './user-reviews.component.html',
  styleUrls: ['./user-reviews.component.css']
})
export class UserReviewsComponent implements OnInit {
  constructor(private reviewService: ReviewService, private recipeService: RecipeService) { }

  username = localStorage.getItem('Username');
  userId = +localStorage.getItem('Account Id');
  
  reviews: Review[] = null;
  recipeTitles: string[] = null;

  reviewsWithTitle: ReviewWithTitles[] = null;

  ngOnInit(): void {
    this.getReviewsByUserId();  
  }

  getReviewsByUserId(): void {
    this.reviewService.getReviewsByUserId(this.userId)
      .then(reviews => this.reviews = reviews);
  }
}
