import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RecipeComponent } from './recipe/recipe.component';
import { ReviewComponent } from './review/review.component';
import { InstructionsComponent } from './instructions/instructions.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RecipeComponent,
    ReviewComponent,
    InstructionsComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
