import { Component, Inject, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UiService } from 'src/app/services/ui.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public products: Product[] = [];
  showAddForm: boolean = false;
  subscription!: Subscription;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private uiService: UiService) { 
    http.get<Product[]>(baseUrl + 'api/products?tenantId=1').subscribe(result => {
      this.products = result;
    }, error => console.error(error));

    this.subscription = this.uiService.onToggle().subscribe(res => this.showAddForm = res);
  }

  ngOnInit(): void {
  }

  toggleAddForm():void{
    this.uiService.toggleAddForm();
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