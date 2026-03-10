import { Routes } from '@angular/router';
import { Produtos } from './pages/produtos/produtos';
import { Carrinho } from './pages/carrinho/carrinho';
import { Checkout } from './pages/checkout/checkout';
import { Confirmacao } from './pages/confirmacao/confirmacao';

export const routes: Routes = [
  { path: '', component: Produtos },
  { path: 'carrinho', component: Carrinho },
  { path: 'checkout', component: Checkout },
  { path: 'confirmacao', component: Confirmacao }
];