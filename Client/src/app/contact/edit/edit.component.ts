
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  id: string;
  contactForm: FormGroup;

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private contactsService: ContactsService, private router: Router) {
    
    this.id = this.route.snapshot.paramMap.get('id');

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
    this.fetchContact();
  }

  edit() {
    this.contactsService.editContact(this.id, this.contactForm.value).subscribe(res => {
      this.router.navigate(['contact', ''])
    })
  }

  fetchContact() {
    this.contactsService.getContact(this.id).subscribe(contact => {
      this.contactForm = this.fb.group({
        firstName: [contact.firstName, Validators.required],
        surName: [contact.surName, Validators.required],
        address: [contact.address, Validators.required],
        dateOfBirth: [contact.dateOfBirth, Validators.required],
        phoneNumber: [contact.phoneNumber, Validators.required],
        iban: [contact.iban, Validators.required],
      })
    })
  }

}