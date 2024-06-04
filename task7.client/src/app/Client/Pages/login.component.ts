import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../../assets/css/login.css', '../../../assets/css/header.css','../../../assets/css/footer.css']
})

export class LoginComponent implements OnInit {
  frmLogin: any;
  UserEmailId: any;
  UserPassword: any;
  user_id: any;
  ngOnInit() {

  }

  constructor(private http: HttpClient, private router: Router) {
    
  }


  loginClient(frmLogin: NgForm) {
    if (frmLogin.valid) {
     
      const param = {
        email: this.UserEmailId,
        password: this.UserPassword
      }

          this.router.navigate(['/Client/Dashboard']);
    
    }
  }
}
