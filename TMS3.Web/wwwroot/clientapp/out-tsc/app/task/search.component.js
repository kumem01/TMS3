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
var task_service_1 = require("../services/task.service");
var task_1 = require("../../models/task");
var taskSearchParameters_1 = require("../../models/taskSearchParameters");
var SearchTasks = /** @class */ (function () {
    function SearchTasks(taskService) {
        this.taskService = taskService;
        this.searchParams = new taskSearchParameters_1.TaskSearchParameters();
        this.taskDetail = new task_1.Task();
        this.tasks = [];
    }
    SearchTasks.prototype.searchTasks = function () {
        this.getTasks();
    };
    SearchTasks.prototype.getTasks = function () {
        var _this = this;
        this.taskService.getTasks(this.searchParams)
            .subscribe(function (r) { return _this.tasks = r; });
    };
    SearchTasks.prototype.selectedTask = function (selectedTask) {
        this.taskDetail = selectedTask;
    };
    SearchTasks.prototype.ngOnInit = function () {
    };
    SearchTasks = __decorate([
        core_1.Component({
            selector: 'search-tasks',
            templateUrl: "./search.component.html",
            styles: []
        }),
        __metadata("design:paramtypes", [task_service_1.TaskService])
    ], SearchTasks);
    return SearchTasks;
}());
exports.SearchTasks = SearchTasks;
//# sourceMappingURL=search.component.js.map