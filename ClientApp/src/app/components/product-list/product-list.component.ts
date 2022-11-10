import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public products: Product[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    http.get<Product[]>(baseUrl + 'api/products?tenantId=1').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface Product {
  tenantId: number;
  productId: number;
  name: string;
  description: string;
  price: number;
  productTypeId: number;
  active: boolean;
}