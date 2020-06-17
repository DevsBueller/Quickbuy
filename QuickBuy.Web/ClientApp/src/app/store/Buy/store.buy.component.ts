import { Component, OnInit } from "@angular/core";
import { templateJitUrl } from "@angular/compiler";
import { StoreShoppingCart } from "../cart/store.shopping.cart";
import { Product } from "../../model/product";
import { Order } from "../../model/order";
import { UserService } from "../../services/user/user.service";
import { OrderItem } from "../../model/orderItem";
import { OrderService } from "../../services/order/order.service";
import { Router } from "@angular/router";

@Component({
  selector: "store-selector",
  templateUrl: "./store.buy.component.html",
  styleUrls: ["./store.buy.component.css"]
})
export class StoreBuyComponent implements OnInit {
  public shoppingCart: StoreShoppingCart;
  public products: Product[];
  public total: number;
  ngOnInit(): void {
    this.shoppingCart = new StoreShoppingCart();
    this.products = this.shoppingCart.getProducts();
    this.updateTotal();
  }
  constructor(private userService: UserService, private orderService: OrderService, private router: Router) {

  }


  public updatePrice(product: Product, quantity: number) {
    if (!product.originalPrice) {
      product.originalPrice = product.price;
    } else {
      product.price = product.originalPrice;
    }
    if (quantity <= 0) {
      quantity = 1;
      product.quantity = quantity;
    }

    product.price = product.price * quantity;
    this.shoppingCart.update(this.products);
    this.updateTotal();

  }
  public remove(product: Product) {
    this.shoppingCart.removeProduct(product);
    this.products = this.shoppingCart.getProducts();
    this.updateTotal();
  }
  public updateTotal() {
    this.total = this.products.reduce((acc, product) => acc + product.price, 0);
  }
  public buyProduct() {

    this.orderService.buyProduct(this.createOrder())
      .subscribe
      (
        orderId => {
          sessionStorage.setItem("orderId", orderId.toString())
          this.products = [];
          this.shoppingCart.cleanShoppingCart();
          //redirecionr prta outra página
          this.router.navigate(["/buy-success"])
        },
        e => {
          console.log(e.error);
        });

  }
  public createOrder(): Order {
    let order = new Order();
    order.userId = this.userService.user.id;
    order.cep = "123334";
    order.city = "Sao Paulo";
    order.state = "Sao Paulo"
    order.datePrevDelivery = new Date();
    order.paymentFormId = 1;
    order.addresNumber = "21223";
    order.addres = "Rua exemplo; Numero: qualquer;"
    this.products = this.shoppingCart.getProducts();

    for (let product of this.products) {
      let orderItem = new OrderItem();
      orderItem.productId = product.id;

      if (!product.quantity) {
        product.quantity = 1;
        orderItem.quantity = product.quantity;
      }
      order.ordemItems.push(orderItem);
    }
    return order;
  }

}
