import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-client",
  templateUrl: "./client.component.html",
  styleUrls: ['../../assets/css/client-header.css', '../../assets/css/client-footer.css', '../../assets/css/client.css']
})

export class ClientComponent implements OnInit {

  constructor(private router: Router) {

  }

  ngOnInit() {

  }

  logOut() {
    sessionStorage.removeItem("user_id");
    this.router.navigate(["/"]);
  }
}
