"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
//import { Observable } from 'rxjs/Observable';
var rxjs_1 = require("rxjs");
require("rxjs/add/observable/throw");
var task_1 = require("../../models/task");
var TaskService = /** @class */ (function () {
    function TaskService(http) {
        this.http = http;
        this.url = "/api/tasks";
        this.selectedTask = new task_1.Task();
    }
    TaskService.prototype.getTasks = function (search) {
        return this.http.post(this.url + '/search', search)
            .map(this.getData)
            .catch(this.handleErrors);
    };
    TaskService.prototype.getData = function (res) {
        var body = res;
        return body || {};
    };
    TaskService.prototype.handleErrors = function (error) {
        var errors = [];
        console.error('An error occured', errors);
        return rxjs_1.Observable.throw(errors);
    };
    TaskService.prototype.getSelectedTask = function (task) {
        this.selectedTask = task;
    };
    TaskService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], TaskService);
    return TaskService;
}());
exports.TaskService = TaskService;
//# sourceMappingURL=task.service.js.map