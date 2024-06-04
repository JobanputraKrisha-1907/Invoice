import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Client/Pages/login.component';
import { ClientRoutes } from './Client/client-routing.module';
import { ClientComponent } from './Client/client.component';

const routes: Routes = [

  { path: '', component: LoginComponent },
  { path: 'Client', component: ClientComponent, children: ClientRoutes }
 
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
