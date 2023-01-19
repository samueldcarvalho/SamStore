import { UserData } from "./../models/user-data";
import { LoginData } from "./../models/login-data";
import { RegisterUserData } from "../models/register-user-data";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { BaseService } from "./abstractions/base.service";

@Injectable({
  providedIn: "root",
})
export class AuthService extends BaseService {
  constructor(private _httpClient: HttpClient) {
    super("auth");
  }

  registerUser(registerData: RegisterUserData): Observable<UserData> {
    return this._httpClient.post<UserData>(this._baseUrlService + "/register", registerData);
  }

  login(loginData: LoginData): Observable<UserData> {
    return this._httpClient.post<UserData>(this._baseUrlService + "/authenticate", loginData);
  }
}
