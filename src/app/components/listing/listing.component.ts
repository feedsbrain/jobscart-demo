import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { Product } from '../../api/models/product';
import { Order } from '../../api/models/order';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ListingComponent implements OnInit {

  orders: Array<Order>;
  isLoading = true;

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

  }

}
