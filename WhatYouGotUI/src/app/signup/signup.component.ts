import { Component, OnInit } from '@angular/core';
import { AccountService } from '../Services/fridgethingsServices/account.service';
import { Account } from '../Models/fridgethingsModels/account';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private accountService: AccountService) { }

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
  }

}
