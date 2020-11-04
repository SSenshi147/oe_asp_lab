export class Todo {
    public TodoName: string;
    public TodoTime: number;
    public Color: string;
    
    constructor() {
        this.Color = '#' + Math.floor(Math.random()*16777215).toString(16);
    }
}
