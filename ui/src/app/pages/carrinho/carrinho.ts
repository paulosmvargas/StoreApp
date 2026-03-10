import { Component, inject } from '@angular/core';
import { NgFor, CurrencyPipe } from '@angular/common';
import { CarrinhoService } from '../../services/carrinho.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-carrinho',
  standalone: true,
  templateUrl: './carrinho.html',
  imports: [NgFor, CurrencyPipe, RouterLink]
})
export class Carrinho {

  private carrinhoService = inject(CarrinhoService);

  itens = this.carrinhoService.listar();

  adicionar(produto: any) {
    this.carrinhoService.adicionar(produto);
    this.itens = this.carrinhoService.listar();
  }

  diminuir(item: any) {
    if (item.quantidade === 1) {
      const ok = window.confirm('Tem certeza que deseja tirar do carrinho?');
      if (!ok) return;
    }
    this.carrinhoService.diminuir(item.produto.id);
    this.itens = this.carrinhoService.listar();
  }


  total(): number {
    return this.itens.reduce((soma, item) => soma + item.produto.preco * item.quantidade, 0);
  }
}
