import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor(private http: HttpClient) { }
  staticData = "https://localhost:7201/api";

  email: BehaviorSubject<string> = new BehaviorSubject<string>("");

  emailAddress = this.email.asObservable();

  getServices(): Observable<any> {
    return this.http.get<any>(`${this.staticData}/Services/getAllServices`);

  }

  getsubServicesbyServiceId(id: any): Observable<any> {
    return this.http.get<any>(`${this.staticData}/SubServices/GetSubServicesbyServiceID/${id}`);
  }

  getSubscription(): Observable<any> {
    return this.http.get<any>(`${this.staticData}/Subscribrion`)
  }

  getSubServiceDetails(id: any): Observable<any> {

    return this.http.get<any>(`${this.staticData}/SubServices/GetSubServicesbyID/${id}`);
  }


  // the Data Will Get From the function in the service subscribtion
  addUSerSubScription(data: any): Observable<any> {
    return this.http.post<any>(`${this.staticData}/UserSubscription`, data)
  }

  
  addUser(data: any): Observable<any> {
    return this.http.post<any>(`${this.staticData}/User`, data)
  }

  logInuser(data: any): Observable<any> {
    return this.http.post<any>(`${this.staticData}/User/LogIn`, data)
  }

  addServiceAPI(data: any): Observable<any> {
    return this.http.post<any>(`${this.staticData}/Services`, data)
  }


  PUTService(id: any ,data: any): Observable<any> {
    return this.http.put<any>(`${this.staticData}/Services/editService/${id}`, data)
  }

  getAllProduct(): Observable<any> {
    return this.http.get<any>(`${this.staticData}/Product`)
  }

  cartItem: any = [];
  cartItemSubject: BehaviorSubject<any> = new BehaviorSubject<any>(this.cartItem); // اسناد داتا 
  cartItemObser = this.cartItemSubject.asObservable(); // ناخذ منه الداتا

  addToCart(data: any) {
    var recod = this.cartItem.find((x: any) => x.productId == data.productId);
    if (recod) {
      alert("product already exist")
    } else {
      this.cartItem.push(data);
      this.cartItemSubject.next(this.cartItem);
    }

   
  }

  increaseQ(id: any) {
    var product = this.cartItem.find((x: any) => x.productId == id)
    if (product) {
      product.quantity += 1;

      this.cartItemSubject.next(this.cartItem); /// next UPDATES and we use it for behavior subject 
    }
  }

  decreaseQ(id: any) {
    var product = this.cartItem.find((x: any) => x.productId == id)
    if (product) {
      product.quantity -= 1;

      this.cartItemSubject.next(this.cartItem); /// next UPDATES and we use it for behavior subject 
    }
  }
}
