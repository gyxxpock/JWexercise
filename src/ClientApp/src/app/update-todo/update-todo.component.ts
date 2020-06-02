import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Todo } from '../todo';

@Component({
  selector: 'app-update-todo',
  templateUrl: './update-todo.component.html',
  styleUrls: ['./update-todo.component.scss']
})
export class UpdateTodoComponent implements OnInit {

  description: string;
  dueDate: Date;
  notes: string;

  constructor(
    private dialogRef: MatDialogRef<UpdateTodoComponent>,
    @Inject(MAT_DIALOG_DATA) public todo: Todo) { }

  ngOnInit(): void {
    let tmpDate = new Date();
    if (this.todo.DueDate.length > 0) {
      tmpDate = new Date(parseInt(this.todo.DueDate, 10));
    }
    this.description = this.todo.Description;
    this.dueDate = tmpDate;
    this.notes = this.todo.Notes;
  }

  updateToDo(): void {
    this.todo.Description = this.description;
    this.todo.DueDate = this.dueDate.getTime().toString();
    this.todo.Notes = this.notes;
    this.dialogRef.close(this.todo);
  }

}
