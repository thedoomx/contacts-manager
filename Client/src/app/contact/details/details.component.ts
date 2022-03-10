import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactsService } from '../contacts.service';
import { Contact } from '../models/contact.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  id: string;
  contact: Contact;

  constructor(private route: ActivatedRoute, private contactsService: ContactsService) { }

  ngOnInit(): void {
    this.fetchContact();
  }

  fetchContact() {
    this.contactsService.getContact(this.id).subscribe(contact => {
      this.contact = contact;
    })
  }

}
