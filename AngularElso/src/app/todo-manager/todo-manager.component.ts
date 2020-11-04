import { Component, OnInit } from '@angular/core';
import { Todo } from '../todo';

@Component({
  selector: 'app-todo-manager',
  templateUrl: './todo-manager.component.html',
  styleUrls: ['./todo-manager.component.css']
})
export class TodoManagerComponent implements OnInit {

  public Todos: Array<Todo>;

  constructor() {
    this.Todos = new Array<Todo>();
  }

  add(name: HTMLInputElement, time: HTMLInputElement){
    const t = new Todo();
    t.TodoName = name.value;
    t.TodoTime = parseInt(time.value, 10);
    
    this.Todos.push(t);
  }

  ngOnInit(): void {
  }

}
