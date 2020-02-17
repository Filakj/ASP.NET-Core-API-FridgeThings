import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Account } from '../../Models/fridgethingsModels/account';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) { }

  accountUrl = 'http://fridgethingsapi.azurewebsites.net/api/Accounts/' 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getAccounts(): Promise<Account[]> {
    console.log(this.accountUrl);
    return this.httpClient.get<Account[]>(this.accountUrl).toPromise();
  }

  getAccountById(id: number): Promise<Account> {
    var completeUrl = `${this.accountUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.get<Account>(completeUrl).toPromise();
  }

  /*
  getAccountByUsername(username: String): Promise<Account> {
    var completeUrl = `${this.accountUrl}${username}`;
    console.log(completeUrl);
    return this.httpClient.get<Account>(completeUrl).toPromise();
  }
  */
  

  postAccount(newAccount: Account): Observable<Account> {
    console.log(this.accountUrl);
    console.log(newAccount);
    return this.httpClient.post<Account>(this.accountUrl, newAccount, this.httpOptions);
  }
  /*
  putAccount(newAccount: Account): Observable<any> {
    var completeUrl = `${this.accountUrl}${newAccount.id}`;
    console.log(completeUrl);
    return this.httpClient.put(completeUrl, newAccount, this.httpOptions);
  }
  */
  deleteAccount(id: number): Observable<Account> {
    var completeUrl = `${this.accountUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.delete<Account>(completeUrl, this.httpOptions);
  }
}
