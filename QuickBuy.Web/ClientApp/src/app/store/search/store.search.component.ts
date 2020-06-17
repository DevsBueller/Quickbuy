import { Component, OnInit} from "@angular/core";
import { Product } from "../../model/product";
import { ProductService } from "../../services/product/product.service";
import { Router } from "@angular/router";
@Component({
  selector: "app-store",
  templateUrl: "./store.search.component.html",
  styleUrls: ["./store.search.component.css"]
})
export class StoreSearchComponent implements OnInit {
  public products: Product[];

  public activte_spinner:boolean;
  ngOnInit(): void {

  }

  constructor(private productService: ProductService, private router: Router) {
    this.activte_spinner = true;
    this.productService.getAll().subscribe(
      products => {
        this.products = products
        this.activte_spinner = false;
      },
      e => {
        console.log(e.error);
        this.activte_spinner = false;
      })
  }
  public openProduct(product: Product) {
    sessionStorage.setItem('productDetail', JSON.stringify(product));
    this.router.navigate(['/store-product']);
  }


}
