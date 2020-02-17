import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../Services/fridgethingsServices/review.service';
import { Review } from '../Models/fridgethingsModels/review';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {

  reviews: Review[];

  constructor(private reviewService: ReviewService ) { }

  ngOnInit(): void {
    this.getReviews();
  }

  getReviews(): void {
    this.reviewService.getReviews()
      .subscribe(reviews => this.reviews = reviews);  //getReviews() should be an observable
  }

  //deleteReview(id: number): void {}

  //addReview(){}
