import { AuthService } from './../../Services/auth.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private _AuthService:AuthService , 
    private _router:Router
  ){}


  registerForm:FormGroup= new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    phone: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl('')
  })

  register(form:FormGroup){
    console.log(form.value)
    this._AuthService.register(form.value).subscribe({
      next: data => {
        this._router.navigate(['/login']);
      },
      error: error => console.log(error)
    })
}
}
