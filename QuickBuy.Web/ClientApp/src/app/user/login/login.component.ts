import { Component, OnInit } from "@angular/core";
import { User } from "../../model/user";
import { Router, ActivatedRoute } from "@angular/router";
import { UserService } from "../../services/user/user.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {

  public user;
  public returnUrl: string;
  public message: string;
  public activate_spinner: boolean;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private userService: UserService) {


  }
  ngOnInit(): void {
    this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];
    this.user = new User();
  }
  login() {
    this.activate_spinner = true;
    this.userService.verifyUser(this.user).subscribe(
      user_json => {
        // essa linha será executada no cso de retorno sem erros 

        this.userService.user = user_json

        if (this.returnUrl == null) {
          this.router.navigate(['/'])
        }else
        this.router.navigate([this.returnUrl])
      },
      error => {
        console.log(error);
        this.message = error.error;
        this.activate_spinner = false;
      }
    );
    //if (this.user.email == "carlos@" && this.user.password =="123") {
    //  sessionStorage.setItem("user-authenticated", "1");
    //  this.router.navigate([this.returnUrl]);
    //}
  }
}
