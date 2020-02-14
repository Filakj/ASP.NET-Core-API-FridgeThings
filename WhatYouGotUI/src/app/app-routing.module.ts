import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipeComponent } from './recipe/recipe.component';
import { InstructionsComponent } from './instructions/instructions.component';
import { ReviewComponent } from './review/review.component';
import { ReviewListComponent } from './review-list/review-list.component';
import { FavoritesListComponent } from './favorites-list/favorites-list.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';

const routes: Routes = [
  { path: 'recipe', component: RecipeComponent },
  { path: 'instructions', component: InstructionsComponent },
  { path: 'review', component: ReviewComponent },
  { path: 'reviews', component: ReviewListComponent },
  { path: 'favorites', component: FavoritesListComponent },
  { path: 'recipes', component: RecipeListComponent }
];



@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})
export class AppRoutingModule { }
