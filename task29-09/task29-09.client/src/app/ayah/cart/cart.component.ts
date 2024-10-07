import { Component } from '@angular/core';
import { UrlService } from '../ayahURL/url.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  ngOnInit() {
    this.getCartItems()
  }
  constructor(private _ser: UrlService) { }
  cart: any;
  getCartItems() {
    this._ser.cartItemObser.subscribe((data) =>
    this.cart = data
    )
  }
  incrimentQ(id: any) {
    this._ser.increaseQ(id);
  }

  minusQ(id: any) {
    this._ser.decreaseQ(id);
  }
}
