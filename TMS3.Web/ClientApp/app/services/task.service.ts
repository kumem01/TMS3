
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { Observable } from 'rxjs/Observable';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/observable/throw';

import { Task } from '../../models/task';
import { TaskSearchParameters } from '../../models/taskSearchParameters';

@Injectable()
export class TaskService {

    private url = "/api/tasks";
    constructor(private http: HttpClient) { }
    public selectedTask: Task = new Task();
    getTasks(search: TaskSearchParameters): Observable<Task[]> {
        return this.http.post(this.url + '/search', search)
            .map(this.getData)
            .catch(this.handleErrors);
    }

    private getData(res: Response) {
        let body = res;
        return body || {};
    }

    private handleErrors(error: any): Observable<any> {
        let errors: string[] = [];
        console.error('An error occured', errors);
        return Observable.throw(errors);
    }

    public getSelectedTask(task: Task) {
        this.selectedTask = task;
    }
}