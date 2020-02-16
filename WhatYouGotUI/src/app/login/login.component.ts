import { Component, OnInit } from '@angular/core';
import { AccountService } from '../Services/fridgethingsServices/account.service';
//import { FormBuilder } from '@angular/forms';
//import {LoginService} from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  
  //loginForm;  

  /*
  constructor(
    private loginService: LoginService,
    private formBuilder: FormBuilder,
  ) {
    this.loginForm = formBuilder.group({
      username: '',
      passphrase:''

    });
  }
  */
  constructor(private accountService: AccountService) { }
  /*
  getAccountByUsername(username: string, passphrase: string): void {
    this.accountService.getRecipeById(id)
        .then(response => this.recipeById = response);
  }
  */
 
  ngOnInit(): void {
  }


  
  /*
  onSubmit(loginInfo){ 
    console.warn("Validating")
  }
  */

}
