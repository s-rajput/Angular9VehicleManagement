import { Component, Input, ɵConsole } from '@angular/core';
import { FormGroup }        from '@angular/forms';

import { QuestionBase }     from './question-base';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html'
})
export class DynamicFormQuestionComponent {
  @Input() question: QuestionBase<string>;
  @Input() form: FormGroup;
  get isValid() { console.log('cameeee');
    if(this.form.controls[this.question.key])
     return this.form.controls[this.question.key].valid;
     }
     
}
