import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Produto } from '../models/produto';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {

  private http = inject(HttpClient);

  getProdutos() {
    return this.http.get<Produto[]>(`${environment.apiUrl}/produtos`);
  }

}