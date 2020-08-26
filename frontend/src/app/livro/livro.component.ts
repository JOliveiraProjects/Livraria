import { Component, OnInit } from '@angular/core';
import { Livro } from './livro-model';
import { LivroService } from './livro-service';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'mt-livro',
  templateUrl: './livro.component.html'

})
export class LivroComponent implements OnInit {


  public livro: Livro;

  constructor(private averbacaoService: LivroService,
    private route: Router, private activeRouter: ActivatedRoute) { }


  ngOnInit() { }

  inputCodigo: number;
  public returnUrl: any;
  public mensagem: any;


  consultar() {
    debugger;
    return this.averbacaoService.averbacaoById(this.inputCodigo)
      .subscribe(
        data => {
          // essa linha será executada no caso de retorno sem erros
         
          this.livro = data;
          console.log(this.livro);
          // if (this.returnUrl == null) {
          //   this.route.navigate(['/']);
          // } else {
          //   this.route.navigate([this.returnUrl]);
          // }
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;
        }
      );     
  }


}
