import { Component, OnInit } from '@angular/core';
import { ContactsService } from './contacts.service';
import { Contact } from './models/contact.model';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  contacts: Array<Contact>;

  constructor(private contactsService: ContactsService) { }

  ngOnInit(): void {
    this.fetchContacts();
  }

  fetchContacts() {
    this.contactsService.getContacts().subscribe(contacts => {
      this.contacts = contacts;
    })
  }

}
