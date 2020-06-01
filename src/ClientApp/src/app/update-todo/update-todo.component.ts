import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-update-todo',
  templateUrl: './update-todo.component.html',
  styleUrls: ['./update-todo.component.scss']
})
export class UpdateTodoComponent implements OnInit {
  
  description: string;
  dueDate: Date;
  notes: string;

  constructor(private dialogRef: MatDialogRef<UpdateTodoComponent>,
    @Inject(MAT_DIALOG_DATA) public data) { }

  ngOnInit(): void {
    console.log(this.data.ID);
  }

  updateToDo(): void{
    console.log("Update todo");
    console.log(this.data.ID);
    this.dialogRef.close();
  }

}
