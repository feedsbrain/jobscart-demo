import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { Product } from '../../api/models/product';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ListingComponent implements OnInit {

  products: Array<Product>;
  isLoading: boolean = true;

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.productService.getProductList().subscribe(result => {
      this.isLoading = false
      this.products = result.map(product => {
        let p = new Product
        p.Id = product.Id;
        p.Name = product.Name;
        p.Description = product.Description;
        p.Price = product.price;
        p.Quantity = 0;
        return p;
      })
    }, err => {
      if (err.status == 401)
        //Not Authorized
        this.router.navigate(['/login'])
    })
  }

  checkout() {

  }

}
