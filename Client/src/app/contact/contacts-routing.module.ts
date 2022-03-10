import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactsComponent } from './contacts.component';
import { CreateComponent } from './create/create.component';
import { DetailsComponent } from './details/details.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
    { path: '', component: ContactsComponent },
    { path: 'create', component: CreateComponent },
    { path: ':id', component: DetailsComponent },
    { path: ':id/edit', component: EditComponent, },
  ];
  
  @NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })
  
  export class ContactsRoutingModule { } 