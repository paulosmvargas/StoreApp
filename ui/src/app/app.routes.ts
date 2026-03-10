import { Routes } from '@angular/router';
import { Produtos } from './pages/produtos/produtos';
import { Carrinho } from './pages/carrinho/carrinho';

export const routes: Routes = [
  { path: '', component: Produtos },
  { path: 'carrinho', component: Carrinho }
];