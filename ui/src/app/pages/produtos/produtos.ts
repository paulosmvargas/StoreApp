import { Component, inject } from '@angular/core';
import { NgFor, CurrencyPipe, AsyncPipe, NgIf } from '@angular/common';
import { ProdutosService } from '../../services/produtos.service';

@Component({
  selector: 'app-produtos',
  standalone: true,
  templateUrl: './produtos.html',
  styleUrls: ['./produtos.scss'],
  imports: [NgFor, AsyncPipe, CurrencyPipe]
})
export class Produtos {
  private produtosService = inject(ProdutosService);
  produtos$ = this.produtosService.getProdutos();
}
