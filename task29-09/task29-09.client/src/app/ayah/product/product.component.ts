import { Component } from '@angular/core';
import { UrlService } from '../ayahURL/url.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {

  ngOnInit() {
    this.get()
  }
  constructor(private _ser: UrlService) { }
  array:any
  get() {
    this._ser.getAllProduct().subscribe((data) =>
      this.array = data
    )

  }
  object = {
    cartId: 0,
    productId: 0,
    userId: 0,
    quantity:0
  }
  addToCartProduct(productID: any) {
    this.object.productId = productID;
    this._ser.addToCart({ ...this.object });
  }

}
