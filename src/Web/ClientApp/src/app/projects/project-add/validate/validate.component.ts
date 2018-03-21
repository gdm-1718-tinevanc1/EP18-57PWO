import { Component, OnInit, Input, AfterViewInit, ViewChildren } from '@angular/core';
import { AuthenticationService } from '../../../core/shared/services/authentication.service'

@Component({
  selector: 'app-validate',
  templateUrl: './validate.component.html',
  styleUrls: ['./validate.component.scss']
})
export class ValidateComponent{
  isAdmin = this.authenticationService.isAdmin;
  validate = {}
  private _projectCredentials: {};

  @Input() set projectCredentials(value: Object) {
    this.validate = value
  }

  constructor(
    private authenticationService:AuthenticationService
  ) { }
}
