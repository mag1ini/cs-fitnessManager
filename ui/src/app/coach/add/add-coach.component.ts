import { Component, OnInit } from '@angular/core';
import TrainingType from '../../domain/trainingTypes';
import {CoachService} from '../../services/coach.service';

@Component({
  selector: 'app-coach-add',
  templateUrl: './add-coach.component.html',
  styles: [
  ]
})
export class AddCoachComponent implements OnInit {

  firstname: string;
  lastname: string;
  trainingType: TrainingType;

  constructor(readonly  coachService: CoachService) { }

  ngOnInit(): void {
  }


  async add(firstname: string, lastname: string, trainingType: TrainingType) {
    try {
      await this.coachService.add(firstname, lastname, trainingType);
    }catch (e) {
      console.log(e.message);
    }

  }
}
