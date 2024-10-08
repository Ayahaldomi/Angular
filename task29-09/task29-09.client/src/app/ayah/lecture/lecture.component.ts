import { Component } from '@angular/core';

@Component({
  selector: 'app-lecture',
  templateUrl: './lecture.component.html',
  styleUrl: './lecture.component.css'
})
export class LectureComponent {
  name: string = "hadeel";
  number: number = 27;
  urlImg: string = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Google_Translate_logo.svg/2048px-Google_Translate_logo.svg.png";

  
  today: number = Date.now();
  str: string = 'abcdefghij';

  onchangeHadeel() {
    this.name = "Rawaa";
  }

  userobj = {
    name: "ayah",
    age: 28,
    color: "red",
  }

  usersArray = [{
    name: "ayah",
    age: 28,
    food: "egg",
  },
    {
      name: "hadeel",
      age: 19,
      food: "egg",
    },
    {
      name: "rahaf",
      age: 10,
      food: "egg",
    }]


}
