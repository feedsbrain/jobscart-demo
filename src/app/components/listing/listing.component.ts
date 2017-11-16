import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { Product } from '../../api/models/product';
import { Order } from '../../api/models/order';
import { Message } from 'primeng/primeng';
import * as _ from 'lodash';
import { Customer } from '../../api/models/customer';
import { OrderDetail } from '../../api/models/orderdetail';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ListingComponent implements OnInit {
  customer: Customer;
  order: Order;
  isLoading = true;
  msgs: Message[] = [];

  constructor(private productService: ProductService, private orderService: OrderService, private router: Router) {
    this.customer = JSON.parse(localStorage.getItem('currentUser'));
    this.order = new Order();
    this.order.Customer = this.customer;
  }

  ngOnInit() {
    this.productService.getProductList().subscribe(result => {
      this.isLoading = false;
      this.order.OrderDetails = result.map(p => {
        const od = new OrderDetail();
        od.Product = new Product();
        od.Product.Id = p.id;
        od.Product.Name = p.name;
        od.Product.Description = p.description;
        od.Product.Price = p.price;
        od.Quantity = 1;
        return od;
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
    this.order.OrderDetails.forEach(o => {
      quantity += o.Quantity;
    });
    if (quantity === 0) {
      this.showWarn('Invalid quantity ...');
      return;
    }
    const _self = this;
    _self.orderService.checkout(_self.order)
      .subscribe(
      data => {
        debugger;
      },
      error => {
        debugger;
      });
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
