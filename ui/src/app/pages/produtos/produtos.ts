import { Component, inject } from '@angular/core';
import { NgFor, CurrencyPipe, AsyncPipe } from '@angular/common';
import { ProdutosService } from '../../services/produtos.service';
import { CarrinhoService } from '../../services/carrinho.service';
import { Produto } from '../../models/produto';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-produtos',
  standalone: true,
  templateUrl: './produtos.html',
  styleUrls: ['./produtos.scss'],
  imports: [NgFor, AsyncPipe, CurrencyPipe, RouterLink]
})
export class Produtos {

  private produtosService = inject(ProdutosService);
  private carrinhoService = inject(CarrinhoService);

  produtos$ = this.produtosService.getProdutos();

  adicionarCarrinho(produto: Produto) {
    this.carrinhoService.adicionar(produto);
  }

}