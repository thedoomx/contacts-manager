import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Contact } from './models/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {
  contactsPath: string = environment.contactApiUrl + 'contacts/';
  contactPathWithoutSlash  = this.contactsPath.slice(0, -1);

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Array<Contact>> {
    return this.http.get<Array<Contact>>(this.contactsPath);
  }

  getContact(id: string): Observable<Contact> {
    return this.http.get<Contact>(this.contactsPath + id);
  }

  createContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.contactsPath, contact);
  }

  editContact(id: string, contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(this.contactsPath + id, contact);
  }

  deleteContact(id: string) {
    return this.http.delete(this.contactsPath + id);
  }
}
