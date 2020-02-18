import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RecipeComponent } from './recipe/recipe.component';
import { ReviewComponent } from './review/review.component';
import { InstructionsComponent } from './instructions/instructions.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { ReviewListComponent } from './review-list/review-list.component';
import { FavoritesListComponent } from './favorites-list/favorites-list.component';
import { TestComponent } from './test/test.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { IngredientsFormComponent } from './ingredients-form/ingredients-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserReviewsComponent } from './user-reviews/user-reviews.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RecipeComponent,
    ReviewComponent,
    InstructionsComponent,
    RecipeListComponent,
    ReviewListComponent,
    FavoritesListComponent,
    TestComponent,
    LoginComponent,
    SignupComponent,
    IngredientsFormComponent,
    UserReviewsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
