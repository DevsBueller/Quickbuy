import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "../../model/user";


@Injectable({
  providedIn: "root"
})
export class UserService {
  private baseURL: string;
  private _user: User;

  
  set user(user: User) {
    sessionStorage.setItem("user-authenticated", JSON.stringify(user));
    this._user = user;
  }
  get user(): User {
    let user_json = sessionStorage.getItem("user-authenticated");
    this._user = JSON.parse(user_json);
    return this._user;
  }
  public user_authenticated(): boolean {
    return this._user != null && this._user.email != "" && this._user.password != "";
  }
  public clean_session() {
    sessionStorage.setItem("user-authenticated", "");
    this._user = null;
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl

  }
  public verifyUser(user: User): Observable<User> {
    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: user.email,
      password: user.password
    }
    //"http:/localhost:8080/api/User"
    return this.http.post<User>(this.baseURL + "api/user/VerifyUser", body, { headers });
  }
  public registerUser(user: User): Observable<User> {
    return this.http.post<User>(this.baseURL + "api/user", JSON.stringify(user), {headers: this.headers})
  }
}
