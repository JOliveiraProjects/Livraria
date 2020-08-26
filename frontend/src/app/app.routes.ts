import {Routes} from '@angular/router'

import {HomeComponent} from './home/home.component'
import {NotFoundComponent} from './not-found/not-found.component'
import { LivroComponent } from './livro/livro.component';


export const ROUTES: Routes = [
  {path: '', component: HomeComponent},  
  {path: 'livro', component: LivroComponent},
  {path: 'about', loadChildren: './about/about.module#AboutModule'},
  {path: '**', component: NotFoundComponent},
]
