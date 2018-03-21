import { Component, OnInit, Directive, AfterViewInit, Input, ViewChild, ElementRef, ViewChildren, QueryList  } from '@angular/core';
import { ProjectService } from '../../../core/shared/services/project.service'
import { SharedService } from '../../../core/shared/services/shared.service'
import { ValidateComponent } from '../validate/validate.component';
import { AuthenticationService } from '../../../core/shared/services/authentication.service'

import { Router } from '@angular/router'; 
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form-abstract',
  templateUrl: './form-abstract.component.html',
  styleUrls: ['./form-abstract.component.scss']
})
export class FormAbstractComponent implements OnInit {
  isAdmin = this.authenticationService.isAdmin;
  language = this.sharedService.sharedNode.language 

  @ViewChildren('cmp') components: QueryList<ValidateComponent>;

  valueObject = JSON.stringify(this.sharedService.sharedNode.valueObject);

  isExpandedValidate = {
    abstract: false
  }
  message = {
    error: '',
    succes: '',
    warning: ''
  };
  id: number;
  projectCredentials = {
    abstract: this.valueObject,
    profileId: this.authenticationService.profileId
  };

  constructor(
    private projectService:ProjectService,
    private sharedService:SharedService,
    private authenticationService:AuthenticationService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.id = this.route.parent.snapshot.params.id;
    if(this.id){
      this.projectService.getProjectGeneralById(this.id).subscribe(
        project => { 
          this.projectCredentials = project
          this.projectCredentials.abstract = this.projectCredentials.abstract.toString().replace(/(\r\n\t|\n|\r\t)/gm,"");
          this.projectCredentials.abstract = JSON.parse(this.projectCredentials.abstract.toString());
        }
      )
    } else{
      this.projectCredentials.abstract = JSON.parse(this.projectCredentials.abstract);
    }
  }

  save() {
    this.projectCredentials.abstract = JSON.stringify(this.projectCredentials.abstract);
    this.projectService.saveProjects(this.projectCredentials, 'general').subscribe(
      res => {
        this.projectCredentials.abstract = JSON.parse(this.projectCredentials.abstract.toString());
        this.message.succes =  "Uw wijzigingen zijn opgeslaan"
        if(res){
          this.router.navigate(['/project', res.id, 'abstract']);
        }
      },
      err => {
        console.log("Error occured");
        this.message.error = "Uw wijzigingen zijn niet opgeslaan, gelieve opnieuw te proberen"
      }
    );
  }

  validate(){
    var validates = [];
    this.components.forEach(validate => validates.push(validate.validate));
    /* if(this.language === 'nl'){
      this.projectCredentials.abstract.nl.validate = validates[0] 
    } else{
      this.projectCredentials.abstract.en.validate = validates[0]
    } */

/*     this.projectCredentials.abstract.nl.validate = validates[0]
 */     // console.log(this.projectCredentials)
    this.save();
  }
}
