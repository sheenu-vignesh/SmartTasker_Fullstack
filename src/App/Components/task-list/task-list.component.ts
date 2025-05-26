import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];
  newTask: Partial<Task> = { title: '', priority: 'Medium' };

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getTasks().subscribe((data) => this.tasks = data);
  }

  addTask(): void {
    if (this.newTask.title) {
      this.taskService.addTask(this.newTask).subscribe(() => {
        this.newTask = { title: '', priority: 'Medium' };
        this.loadTasks();
      });
    }
  }

  markDone(task: Task): void {
    task.isDone = !task.isDone;
    this.taskService.updateTask(task.id, task).subscribe();
  }

  deleteTask(id: number): void {
    this.taskService.deleteTask(id).subscribe(() => this.loadTasks());
  }
}
