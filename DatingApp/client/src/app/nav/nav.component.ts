import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent {
  model: any = {}
  //currentUser$: Observable<User | null> = of(null);

  constructor(public accountServices: AccountService, private router: Router, private toastr: ToastrService ){

  }

  ngOnInit():void{
    //this.currentUser$ = this.accountServices.currentUser$;
  }

  /*getCurrentUser(){
    this.accountServices.currentUser$.subscribe({
      next:user => 
      {
        console.log("user is", !!user);
        this.loggedIn = !!user
      }, 
      error: error => console.log(error)
    })
  }*/

  login(){
    this.accountServices.login(this.model).subscribe({
      next: _=> this.router.navigateByUrl('/members')     
    });
  }

  logout(){
    this.accountServices.logout();
    this.router.navigateByUrl('/');
  }

}


