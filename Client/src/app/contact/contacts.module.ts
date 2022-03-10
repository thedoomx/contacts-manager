import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DetailsComponent } from './details/details.component';
import { CheckboxModule } from 'primeng/checkbox';
import { ContactsComponent } from './contacts.component';




@NgModule({
  declarations: [
    CreateComponent,
    EditComponent,
    DetailsComponent,
    ContactsComponent
  ],
  imports: [
    CommonModule,
    CheckboxModule,

  ]
})
export class ContactsModule { }
