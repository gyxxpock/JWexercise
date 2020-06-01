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
    this.createToDoDialogRef = this.dialog.open(CreateTodoComponent,
      {
        width: '500px',
      });

    this.createToDoDialogRef.afterClosed().subscribe(description => {
      if (description !== undefined) {
        this.todoService.create(description).subscribe(result => {this.loadToDos();});
      }
    });
  }

  updateTodo(ID: string): void {
    this.updateToDoDialogRef = this.dialog.open(UpdateTodoComponent, {data: {ID: ID}});

    this.updateToDoDialogRef.afterClosed().subscribe(result => {
      console.log('The update dialog was closed');
      this.loadToDos();
    });
  }

  deleteToDo(id: string): void {
    console.log("Delete");
    console.log(id);
  }

  completeTodo(ID: string, complete: boolean): void {
    console.log("Complete");
    console.log(ID);
    console.log(complete);
  }

  loadToDos(): void {
    this.todoService.getAll().subscribe(data => {
      this.todos = data;
    });
  }
}
