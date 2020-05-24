import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterUserComponent } from './user/register/register.user.component';
//import { CommonModule } from '@angular/common';
//import { RoutesGuard } from './authorization/routes-guard';
import { UserService } from './services/user/user.service';
import { ProductService } from './services/product/product.service';
import { ProductSearchComponent } from './product/search/product.search.component';
import { StoreSearchComponent } from './store/search/store.search.component';
import { TruncateModule } from "ng2-truncate"
import { StoreProductComponent } from './store/product/store.product.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductComponent,
    LoginComponent,
    RegisterUserComponent,
    ProductSearchComponent,
    StoreSearchComponent,
    StoreProductComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TruncateModule,


  
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'product', component: ProductComponent/*, canActivate: [RoutesGuard] */},
      { path: 'login', component: LoginComponent },
      { path: 'new-user', component: RegisterUserComponent },
      { path: 'product-search', component: ProductSearchComponent }
    ])
  ],
  providers: [UserService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
