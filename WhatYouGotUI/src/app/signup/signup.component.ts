import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { AccountService } from '../Services/fridgethingsServices/account.service';
import { Account } from '../Models/fridgethingsModels/account';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  registerForm: FormGroup; 
  constructor(
    private accountService: AccountService,
    private fb: FormBuilder,
    ) { }

  /*
  postAccount(username: string, passphrase: string, firstName: string,lastName: string, email: string): void {
    username = username.trim();
    passphrase = passphrase.trim();
    firstName = firstName.trim(); 
    lastName = lastName.trim(); 
    email = email.trim(); 

    var newAccount: Account = {
      id: null,
      username: username, 
      passphrase: passphrase, 
      firstName: firstName,
      lastName: lastName, 
      email: email
    }
    
    this.accountService.postAccount(newAccount).subscribe(
      (data: Account) => {console.log(data);},
      (error: any) => {console.log(error)}
      );
  }
*/
  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: '', 
      password: '',
      firstname: '',
      lastname: '',
      email: ''
  });

}

onSubmit(form: FormGroup) {
  console.log('Valid?', form.valid); // true or false
  console.log('Username', form.value.username);
  console.log('Password', form.value.password);
  console.log('First Name', form.value.firstname);
  console.log('Last Name', form.value.lastname);
  console.log('Email', form.value.email);

  //make account object 
  var newAccount: Account = {  
    username: form.value.username, 
    passphrase: form.value.password, 
    firstName: form.value.firstname, 
    lastName: form.value.lastname, 
    email: form.value.email
  }
  this.accountService.postAccount(newAccount).subscribe(
    (data: Account) => {console.log(data);},
    (error: any) => {console.log(error)}
    );
}


}
