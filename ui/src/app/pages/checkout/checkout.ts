import { Component, inject } from '@angular/core';
import { CurrencyPipe, NgFor } from '@angular/common';
import { CarrinhoService } from '../../services/carrinho.service';
import { PedidosService } from '../../services/pedidos.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  standalone: true,
  templateUrl: './checkout.html',
  imports: [CurrencyPipe, FormsModule, NgFor]
})
export class Checkout {
  private carrinhoService = inject(CarrinhoService);
  private pedidosService = inject(PedidosService);
  private router = inject(Router);

  itens = this.carrinhoService.listar();

  meiosPagamento = ["Pix", "Cartao", "Boleto"];
  meioPagamento = this.meiosPagamento[0];

  nome = "";
  email = "";
  endereco = "";

  total(): number {
    return this.itens.reduce((soma, item) => soma + item.produto.preco * item.quantidade, 0);
  }

  finalizarPedido() {
    const pedido = {
      nome: this.nome,
      email: this.email,
      endereco: this.endereco,
      meioPagamento: this.meioPagamento,
      produtos: this.itens.map(p => ({
        produtoId: p.produto.id,
        quantidade: p.quantidade
      }))
    };

    this.pedidosService.criarPedido(pedido)
      .subscribe({
        next: () => {
          this.carrinhoService.limpar();
          this.router.navigate(['/confirmacao']);
        },
        error: (err) => console.error(err)
      });
  }
}
