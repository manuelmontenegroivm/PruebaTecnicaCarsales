import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Spinkit } from 'ng-http-loader';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'rick-y-morty';

  // constructor(private router: Router) {
  //   this.router.navigate(['Episodios/listado']);
  // }

  public spinkit = Spinkit;
}
