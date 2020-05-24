import { Component, OnInit } from "@angular/core";
import { templateJitUrl, ClassStmt } from "@angular/compiler";
import { ProductService } from "../../services/product/product.service";
@Component({
  selector: "store-app-product",
  templateUrl: "./store.product.component.html",
  styleUrls:["./store.product.component.css"]
})

export class StoreProductComponent implements OnInit{
  ngOnInit(): void {

  }
  constructor(private productService: ProductService) {

  }
}
