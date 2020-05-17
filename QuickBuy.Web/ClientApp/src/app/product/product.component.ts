import { Component, OnInit  } from "@angular/core"
import { ProductService } from "../services/product/product.service";
import { Router } from "@angular/router";
import { Product } from "../model/product";
@Component({
  selector: "app-product",
  templateUrl: "./product.component.html",
  styleUrls: ["./product.component.css"]
})
export class ProductComponent implements OnInit{// Nome das classes começando com maiúsculo por conta da convenção PascalCase

  public product: Product
  public message: string;
  public selectedFile: File;
  public activate_spinner: boolean;
  //ngOnInit(): void {
  //  var productSession = sessionStorage.getItem('productSession')
  //  if (produtoSession) {
  //    this.product = JSON.parse(productSession);
  //  } else {
  //    this.product = new Product();
  //  }
  //}
  constructor(private productService: ProductService, private router: Router) {

  }

  ngOnInit(): void {
    this.product = new Product();

  }
  public inputChange(files: FileList) {
    this.selectedFile = files.item(0);
    this.activate_spinner = true;
    this.productService.sendFile(this.selectedFile).subscribe(
      fileName => {
        this.product.fileName = fileName;
        alert(this.product.fileName);
        console.log(fileName);
        this.activate_spinner = false;
      },
      e => {
        console.log(e.error)
        this.activate_spinner = false;
      }
        
    );
  }
  public register() {

    this.productService.register(this.product)
      .subscribe(
        productJson => {
          console.log(productJson);        
        },
        e => {
          console.log(e.error);
          this.message = e.error;

        }
      );
  }
}
