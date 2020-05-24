import { Component, OnInit } from "@angular/core"
import { ProductService } from "../../services/product/product.service";
import { Product } from "../../model/product";
import { Router } from "@angular/router";
@Component({
  selector: "product-search",
  templateUrl: "./product.search.component.html",
  styleUrls: ["./product.search.component.css"]
})
export class ProductSearchComponent implements OnInit {// Nome das classes começando com maiúsculo por conta da convenção PascalCase

  public products: Product[];
  public message: string;
  public activate_spinner:boolean;
  ngOnInit(): void {


  }

  constructor(private productService: ProductService, private router: Router) {
    this.activate_spinner = true;
    this.productService.getAll()
      .subscribe(products => {
        this.products = products;
        this.activate_spinner = false;
      },
        e => {
          console.log(e.error);
          this.activate_spinner = true;
        });
  }
  public addProduct() {
    this.router.navigate(['/product'])
  }
  public deleteProduct(product: Product) {
    var result = confirm("Deseja Realmente cancelar esse produto?");
    if (result == true) {
      this.activate_spinner = true;
      this.productService.delete(product)
        .subscribe(
          products => {
            this.products = products;
            this.activate_spinner = false;
          },
          e => {
            console.log(e.error);
            this.activate_spinner = false;
          }
        );
    }


  }
  public editProduct(product: Product) {
    sessionStorage.setItem('productSession', JSON.stringify(product));
    this.router.navigate(['/product']);



  }
}


