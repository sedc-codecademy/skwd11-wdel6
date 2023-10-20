import { Component, OnInit } from '@angular/core';

const url = "https://localhost:668/calculator/add/4/5";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Angular inside SEDC Server';
  name: string = "";

  async ngOnInit() {
    const response = await fetch(url);
    const data = await response.json();
    this.name = data.name;
  }
}
