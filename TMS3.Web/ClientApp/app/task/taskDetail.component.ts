import { Component } from '@angular/core';


import { TaskService } from '../services/task.service';


@Component({
    selector: "task-detail",
    templateUrl: "/taskDetail.component.html",
    styleUrls:[]
})
export class TaskDetail
{
    constructor(private taskService: TaskService) {
        let x = 10;
    }


}