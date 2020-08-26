import {Injectable} from '@angular/core'
import {Http} from '@angular/http'
import {Observable} from 'rxjs/Observable'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch'


import {Livro} from "./livro-model"

import {LIVRARIA_API} from '../app.api'
import {ErrorHandler} from '../app.error-handler'

@Injectable()
export class LivroService {

    constructor(private http: Http){}

    averbacaoById(id: number): Observable<Livro>{
        debugger
        console.log(id);       

        return this.http.get(`${LIVRARIA_API}/api/Livraria/livro/${id}/`)
          .map(response => response.json())
          .catch(ErrorHandler.handleError)
      }

}

