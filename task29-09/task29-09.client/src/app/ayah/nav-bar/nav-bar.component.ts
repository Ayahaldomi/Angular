import { Component } from '@angular/core';
import { UrlService } from '../ayahURL/url.service';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  constructor(private _ser: UrlService, private _router: Router) { }
  email = "";
  ngOnInit() {
    this._ser.emailAddress.subscribe((data) =>
      this.email = data
    )
  }
  logout(){
    this.email = "";
    this._router.navigate(['/service'])
  }

}
