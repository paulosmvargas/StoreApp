import { Component, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { CarrinhoService } from '../../services/carrinho.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.scss'],
  imports: [RouterLink, RouterLinkActive]
})
export class Navbar {
  private carrinhoService = inject(CarrinhoService);
  get quantidade() {
    return this.carrinhoService.quantidadeTotal();
  }
}
