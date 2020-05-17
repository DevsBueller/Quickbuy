import { Component, OnInit } from "@angular/core";
import { User } from "../../model/user";
import { UserService } from "../../services/user/user.service";

@Component({
  selector: "register-user",
  templateUrl: "./register.user.component.html",
  styleUrls: ["./register.user.component.css"]
})

export class RegisterUserComponent implements OnInit{

  public user: User;

  public message: string;
  public activate_spinner: boolean;
  public userResgisted;
  constructor(private userService: UserService) {

  }
  ngOnInit(): void {
    this.user = new User();

  }
  public register() {
    this.activate_spinner = true;
    this.userService.registerUser(this.user)
      .subscribe(
        userJson => {
        
          this.userResgisted = true;
          this.message = "";
          this.activate_spinner = false;
        },
        e => {
        this.message = e.error
          this.activate_spinner = false;
        })
  }
}
