
import { Component,OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

import { TaskService } from '../services/task.service';
import { Task } from '../../models/task';
import { TaskSearchParameters } from '../../models/taskSearchParameters';

@Component({
    selector: 'search-tasks',
    templateUrl:"./search.component.html",
    styles: []
})
export class SearchTasks implements OnInit{

   public constructor(private taskService:TaskService ) {

    }

   public searchParams: TaskSearchParameters = new TaskSearchParameters();
   public taskDetail: Task = new Task();
    public tasks: Task[] = [];
    public searchTasks() {
        this.getTasks();
    }
    private getTasks() {
        this.taskService.getTasks(this.searchParams)
            .subscribe(r=>this.tasks=r);
    }

    public selectedTask(selectedT: Task) {
        this.taskService.getSelectedTask(selectedT);
    }
    ngOnInit() {

    }
}