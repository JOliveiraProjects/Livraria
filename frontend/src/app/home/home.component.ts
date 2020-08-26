import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'mt-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {

  }

  username: string;
  password: string;

  login(): void {    
    if (this.username == 'admin@livraria.com.br' && this.password == 'admin@123') {
      this.router.navigate(["/livro"]);
    } else {
      alert("Usuário ou Senha Incorreto!");
    }
  }

}
