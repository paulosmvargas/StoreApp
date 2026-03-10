import { Component, inject } from '@angular/core';
import { NgFor, CurrencyPipe, NgIf } from '@angular/common';
import { CarrinhoService } from '../../services/carrinho.service';
import { Produto } from '../../models/produto';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-carrinho',
  standalone: true,
  templateUrl: './carrinho.html',
  imports: [NgFor, NgIf, CurrencyPipe, RouterLink]
})
export class Carrinho {

  private carrinhoService = inject(CarrinhoService);

  itens: Produto[] = this.carrinhoService.listar();

  total(): number {
    return this.itens.reduce((soma, item) => soma + item.preco, 0);
  }

}