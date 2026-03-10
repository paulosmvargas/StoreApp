import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {

  private http = inject(HttpClient);

  criarPedido(pedido: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/pedidos`, pedido);
  }

}