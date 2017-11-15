import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { Product } from '../../api/models/product';
import { Order } from '../../api/models/order';
import { Message } from 'primeng/primeng';
import * as _ from 'lodash';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ListingComponent implements OnInit {

  orders: Array<Order>;
  isLoading = true;
  msgs: Message[] = [];

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.productService.getProductList().subscribe(result => {
      this.isLoading = false;
      this.orders = result.map(p => {
        const o = new Order();
        o.Product = new Product();
        o.Product.Id = p.id;
        o.Product.Name = p.name;
        o.Product.Description = p.description;
        o.Product.Price = p.price;
        o.Quantity = 1;
        return o;
      });
    }, err => {
      if (err.status === 401) {
        // Not Authorized
        this.router.navigate(['/login']);
      }
    });
  }

  checkout() {
    let quantity = 0;
    this.orders.forEach(o => {
      quantity += o.Quantity;
    });
    if (quantity === 0) {
      this.showWarn('Invalid quantity ...');
      return;
    }
    // TODO: Success
  }

  showSuccess(message: string) {
    this.msgs = [];
    this.msgs.push({ severity: 'success', summary: 'Success Message', detail: message });
  }

  showInfo(message: string) {
    this.msgs = [];
    this.msgs.push({ severity: 'info', summary: 'Info Message', detail: message });
  }

  showWarn(message: string) {
    this.msgs = [];
    this.msgs.push({ severity: 'warn', summary: 'Warn Message', detail: message });
  }

  showError(message: string) {
    this.msgs = [];
    this.msgs.push({ severity: 'error', summary: 'Error Message', detail: message });
  }

  clearMessage() {
    this.msgs = [];
  }

}
