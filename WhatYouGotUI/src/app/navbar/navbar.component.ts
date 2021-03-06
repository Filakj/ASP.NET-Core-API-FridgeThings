import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  role: string; 
  signedin: undefined;

  constructor() { }

  ngOnInit(): void {
    this.role = this.readLocalStorageValue('Account Id');
    const userId = +localStorage.getItem('Account Id');
  }

  readLocalStorageValue(key: string): string {
    return localStorage.getItem(key);
}

signout(){ 
  localStorage.clear();
  location.href = "http://localhost:4200/"
  //location.reload();
 
}

}
