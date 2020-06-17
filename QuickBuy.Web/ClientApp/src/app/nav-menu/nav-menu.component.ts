import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user/user.service';
import { StoreShoppingCart } from '../store/cart/store.shopping.cart';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent  implements OnInit{
  isExpanded = false;
  public shoppingCart: StoreShoppingCart
  ngOnInit(): void {
    this.shoppingCart = new StoreShoppingCart();
  }
  constructor(private router: Router, private userService: UserService) {

  }
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public userLogged(): boolean {
    return this.userService.user_authenticated();
  }
  public user_administrator(): boolean {
    return this.userService.user_administrator();
  }
  logout() {
    this.userService.clean_session();
    this.router.navigate(['/']);
  }
  get user() {
    return this.userService.user;
  }
  public existItensShoppingCart() : boolean{
   return this.shoppingCart.existItensShoppingCart();
  }
}
