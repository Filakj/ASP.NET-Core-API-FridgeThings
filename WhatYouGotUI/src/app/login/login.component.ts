import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { AccountService } from '../Services/fridgethingsServices/account.service';
import { AccountRetrived } from '../Models/fridgethingsModels/accountRetrived';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

 loginForm: FormGroup; 
 AccountsR: AccountRetrived[]; 


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
  this.getAccountsR();
}

onSubmit(form: FormGroup) {
  console.log('Valid?', form.valid); // true or false
  console.log('Username', form.value.username);
  console.log('Password', form.value.password);

  this.AccountsR.forEach(user => {
    var x = user.username; 
    var y = user.passphrase; 
    if(x == form.value.username && y == form.value.password){ 
      alert("Welcome " + user.firstName + " " + user.lastName);
      console.log("Hello" );
      localStorage.setItem("Account Id",user.id.toString()); 
      localStorage.setItem("Username",x); 
      localStorage.setItem("First Name", user.firstName);
      localStorage.setItem("Last Name", user.lastName);
      alert(localStorage.getItem("Account Id"));
    }
    
  });

}

getAccountsR(){ 
  this.accountService.getAccountsR()
  .then(response => this.AccountsR = response);
}

}
