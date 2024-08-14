import { RegisterComponent } from './Componnent/register/register.component';
import { ContactComponent } from './Componnent/contact/contact.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Componnent/home/home.component';
import { LoginComponent } from './Componnent/login/login.component';

const routes: Routes = [
  {path: '', component : HomeComponent , pathMatch:'full'},
  {path: 'home', component: HomeComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
