import { Component, OnInit } from "@angular/core";

@Component({
  templateUrl: "./store.buy.success.component.html",
  styleUrls: ["./store.buy.success.component.css"]
})
export class StoreBuySuccessComponent implements OnInit {
  public orderId: string;
  ngOnInit(): void {
    this.orderId = sessionStorage.getItem("orderId");
  }
}
