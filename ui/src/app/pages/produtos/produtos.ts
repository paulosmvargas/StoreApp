import { Component, inject, signal } from '@angular/core';
import { NgFor, NgIf,CurrencyPipe, AsyncPipe } from '@angular/common';
import { ProdutosService } from '../../services/produtos.service';
import { CarrinhoService } from '../../services/carrinho.service';
import { Produto } from '../../models/produto';

@Component({
  selector: 'app-produtos',
  standalone: true,
  templateUrl: './produtos.html',
  styleUrls: ['./produtos.scss'],
  imports: [NgFor, NgIf, AsyncPipe, CurrencyPipe]
})
export class Produtos {
  private produtosService = inject(ProdutosService);
  private carrinhoService = inject(CarrinhoService);

  produtos$ = this.produtosService.getProdutos();

  // guarda toasts por produto
  toasts = signal<Record<number, boolean>>({});

  adicionarCarrinho(produto: Produto) {
    this.carrinhoService.adicionar(produto);

    const id = produto.id;
    this.toasts.update(t => ({ ...t, [id]: true }));

    setTimeout(() => {
      this.toasts.update(t => {
        const copy = { ...t };
        delete copy[id];
        return copy;
      });
    }, 1600);
  }
}