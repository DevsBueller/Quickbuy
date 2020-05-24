import { Component, OnInit, ElementRef } from "@angular/core";
import { Product } from "../../model/product";
import { ProductService } from "../../services/product/product.service";
@Component({
  selector: "app-store",
  templateUrl: "./store.search.component.html",
  styleUrls: ["./store.search.component.css"]
})
export class StoreSearchComponent implements OnInit {
  public products: Product[];


  ngOnInit(): void {

  }

  constructor(private productService: ProductService, private elementRef: ElementRef)
  {
    this.productService.getAll().subscribe(
      products => {
        this.products = products
      },
      e => {
        console.log(e.error);
      })
  }
  public openProduct(product: Product) {
    this.productService.getAll().subscribe(products => { this.products = products }, e => {
      console.log(e.error);
    })
  }
  ngAfterViewInit() {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#eeeeee';
  }
}
