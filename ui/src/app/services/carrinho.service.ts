import { Injectable } from '@angular/core';
import { Produto } from '../models/produto';

interface ItemCarrinho {
  produto: Produto;
  quantidade: number;
}

@Injectable({
  providedIn: 'root'
})

export class CarrinhoService {
  private itens: ItemCarrinho[] = [];

  adicionar(produto: Produto) {
    const item = this.itens.find(i => i.produto.id === produto.id);

    if(item) {
      item.quantidade++;
    } else {
      this.itens.push({ produto, quantidade: 1 });
    }
  }

  diminuir(produtoId: number) {
    const item = this.itens.find(i => i.produto.id === produtoId);

    if(!item) return;

    item.quantidade--;

    if(item.quantidade <= 0) {
      this.itens = this.itens.filter(i => i.produto.id !== produtoId);
    }
  }

  quantidadeTotal() {
    return this.itens.reduce((s, i) => s + i.quantidade, 0);
  }

  listar() {
    return this.itens;
  }

  limpar() {
    this.itens = [];
  }

}