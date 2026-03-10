import { Injectable } from '@angular/core';
import { Produto } from '../models/produto';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {

  private itens: Produto[] = [];

  adicionar(produto: Produto) {
    this.itens.push(produto);
  }

  listar() {
    return this.itens;
  }

  limpar() {
    this.itens = [];
  }

}