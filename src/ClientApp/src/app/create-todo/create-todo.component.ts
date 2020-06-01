import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-todo',
  templateUrl: './create-todo.component.html',
  styleUrls: ['./create-todo.component.scss']
})
export class CreateTodoComponent implements OnInit {

  description: string;

  constructor(private dialogRef: MatDialogRef<CreateTodoComponent>) { }

  ngOnInit(): void {
  }

}
