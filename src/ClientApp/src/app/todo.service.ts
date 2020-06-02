import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Todo } from './todo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor(private http: HttpClient) { }

  private handleError(error: Response | any) {
    let errorMessage: string;
    errorMessage = error.message ? error.message : error.toString();
    return throwError(errorMessage);
  }

  getAll(): Observable<any> {
    return this.http
      .get('api/todos')
      .pipe(map((response: Response) => response))
      .pipe(catchError(this.handleError));
  };

  getByID(ID: string) {
    return this.http
      .get('api/todos/' + ID)
      .pipe(map((response: Todo) => response ))
      .pipe(catchError(this.handleError));
  }

  delete(ID: string) {
    return this.http
      .delete('api/todos/' + ID)
      .pipe(map((response: Response) => response))
      .pipe(catchError(this.handleError));
  }

  create(description: string) {
    const newTodo: Todo = { ID: '', Description: description, DueDate: '', Notes: '', IsDone: false };
    return this.http
      .post('api/todos', newTodo)
      .pipe(map((response: Response) => response))
      .pipe(catchError(this.handleError));
  }

  update(todo: Todo) {
    return this.http
      .put('api/todos', todo)
      .pipe(map((response: Response) => response))
      .pipe(catchError(this.handleError));
  }

}