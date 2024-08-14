import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private _AuthService:AuthService
    , private _router:Router
  ){}


  loginForm:FormGroup= new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    phone: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl('')
  })

  login(form:FormGroup){
    console.log(form.value)
    this._AuthService.login(form.value).subscribe({
      next: data => {
        this._router.navigate(['/home']);
      },
      error: error => console.log(error)
    })
}
}
