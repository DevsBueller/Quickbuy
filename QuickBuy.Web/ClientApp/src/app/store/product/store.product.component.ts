import { Component, OnInit } from "@angular/core";
import { templateJitUrl, ClassStmt } from "@angular/compiler";
import { ProductService } from "../../services/product/product.service";
import { Product } from "../../model/product";
import { Router } from "@angular/router";
import { StoreShoppingCart } from "../cart/store.shopping.cart";
@Component({
  selector: "store-app-product",
  templateUrl: "./store.product.component.html",
  styleUrls:["./store.product.component.css"]
})

export class StoreProductComponent implements OnInit{
  public product: Product;
  public shoppingCart: StoreShoppingCart;
  ngOnInit(): void {
    this.shoppingCart = new StoreShoppingCart();
    var productDetail = sessionStorage.getItem('productDetail');
    if (productDetail) {
      this.product = JSON.parse(productDetail);
    }
  }
  constructor(private productService: ProductService, private router : Router) {

  }
  public buy() {
    this.shoppingCart.add(this.product);
    this.router.navigate(["/store-buy"]);
  }
}
