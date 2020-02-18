import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { AccountService } from '../Services/fridgethingsServices/account.service';
import { Account } from '../Models/fridgethingsModels/account';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

 loginForm: FormGroup; 
 Accounts: Account[]; 


 constructor(
   private accountService: AccountService,
   private fb: FormBuilder,
   ) { }
  /*
  getAccountByUsername(username: string, passphrase: string): void {
    this.accountService.getRecipeById(id)
        .then(response => this.recipeById = response);
  }
  */
 ngOnInit(): void {


  this.loginForm = this.fb.group({
    username: '', 
    password: '',
});
  this.getAccounts();
}

onSubmit(form: FormGroup) {
  console.log('Valid?', form.valid); // true or false
  console.log('Username', form.value.username);
  console.log('Password', form.value.password);

  this.Accounts.forEach(user => {
    var x = user.username; 
    var y = user.passphrase; 
    if(x == form.value.username && y == form.value.password){ 
      alert("Welcome " + user.firstName + " " + user.lastName);
      console.log("Hello" );
      
    }
    
  });

}

getAccounts(){ 
  this.accountService.getAccounts()
  .then(response => this.Accounts = response);
}

}
