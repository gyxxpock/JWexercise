import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CreateTodoComponent } from './create-todo/create-todo.component'
import { UpdateTodoComponent } from './update-todo/update-todo.component';
import { Todo } from './todo';
import { TodoService } from './todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  createToDoDialogRef: MatDialogRef<CreateTodoComponent>;
  updateToDoDialogRef: MatDialogRef<UpdateTodoComponent>;
  title = 'ToDo App';
  todos: Todo[];

  constructor(private dialog: MatDialog, private todoService: TodoService) { }
  ngOnInit(): void {
    this.loadToDos();
  }

  createTodo(): void {
    this.createToDoDialogRef = this.dialog.open(CreateTodoComponent);

    this.createToDoDialogRef.afterClosed().subscribe(description => {
      if (description !== undefined) {
        this.todoService.create(description).subscribe(result => { this.loadToDos(); });
      }
    });
  }

  updateTodo(ID: string): void {
    this.todoService.getByID(ID).subscribe(todo => {
      this.updateToDoDialogRef = this.dialog.open(UpdateTodoComponent, { data: todo });
      this.updateToDoDialogRef.afterClosed().subscribe(updatedTodo => {
        if (updatedTodo !== undefined) {
          this.todoService.update(updatedTodo).subscribe(response => {
            this.loadToDos();
          });
        }
      });
    });
  }

  deleteToDo(id: string): void {
    this.todoService.delete(id).subscribe(description => {
      this.loadToDos();
    });
  }

  completeTodo(ID: string, complete: boolean): void {
    this.todoService.getByID(ID).subscribe(todo => {
      todo.IsDone = complete;
      this.todoService.update(todo).subscribe(response => {
        this.loadToDos();
      });
    });
  }

  loadToDos(): void {
    this.todoService.getAll().subscribe(data => {
      this.todos = data;
    });
  }
}
