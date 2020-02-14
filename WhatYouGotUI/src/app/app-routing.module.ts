import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipeComponent } from './recipe/recipe.component';
import { InstructionsComponent } from './instructions/instructions.component';
import { ReviewComponent } from './review/review.component';

const routes: Routes = [
  { path: 'recipe', component: RecipeComponent },
  { path: 'instructions', component: InstructionsComponent },
  { path: 'review', component: ReviewComponent }
];



@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})
export class AppRoutingModule { }
