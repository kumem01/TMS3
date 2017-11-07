import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SearchTasks } from './task/search.component';
import { TaskService } from './services/task.service';
import { TaskDetail } from './task/taskDetail.component';

@NgModule({
  declarations: [
    AppComponent, SearchTasks,TaskDetail
  ],
  imports: [
      BrowserModule, FormsModule, HttpClientModule
  ],
  providers: [TaskService],
  bootstrap: [AppComponent]
})
export class AppModule { }
