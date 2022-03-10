import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  contactForm: FormGroup;
  constructor(private fb: FormBuilder, private contactsService: ContactsService, private router: Router) {
    this.contactForm = this.fb.group({
      firstName: [null, Validators.required],
      surName: [null, Validators.required],
      address: [null, Validators.required],
      dateOfBirth: [null, Validators.required],
      phoneNumber: [null, Validators.required],
      iban: [null, Validators.required],
    })
   }

  ngOnInit(): void {
    
  }


  create() {
    this.contactsService.createContact(this.contactForm.value).subscribe(res => {
      this.router.navigate(['contact', ''])
    })
  }

}
