import { Component } from '@angular/core';
import { UrlService } from '../ayahURL/url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})
export class LogInComponent {
  ngOnInit() {

  }
  constructor(private _ser: UrlService, private _router: Router) {

  }



  login(data: any) {
    var form = new FormData();
    for (let key in data) {
      form.append(key, data[key])
    }
    this._ser.logInuser(form).subscribe(() => {
      alert("user added sucssfully")
      this._router.navigate(['/service'])
    },
      (error) => {
        alert(error.error)
      })
  }

}
