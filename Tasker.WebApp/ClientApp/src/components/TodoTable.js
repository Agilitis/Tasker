import React from 'react';
import Dropdown from "react-dropdown";

const options = [
    {value: 0, label: "Paused"},
    {value: 1, label: "Doing"},
    {value: 2, label: "Finished"},
    {value: 3, label: "Postponed"}
];


const HEADER = {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
};

const URL = "http://localhost:5000/api/todos/";



export class TodoTable extends React.Component {
    constructor(props){
        super(props);
        this.state = { todos: props.todos, loading: true };
    }

    componentWillReceiveProps({todos}) {
        this.setState({todos: todos})
    }

    async deleteTodo(todo) {
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'DELETE'
        });
        this.populateTodos();
    }


    async selectState(todo, state) {
        let data = JSON.stringify({
            "title": todo.title,
            "description": todo.description,
            "deadline": todo.deadline,
            "priority": todo.priority,
            "state": state.value,
            "id": todo.id
        });
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'PUT',
            body: data,
        });

    }


    async todoHigherPriority(todo) {
        todo.priority++;
        let data = JSON.stringify({
            "title": todo.title,
            "description": todo.description,
            "deadline": todo.deadline,
            "priority": todo.priority,
            "state": todo.state,
            "id": todo.id
        });
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'PUT',
            body: data
        });
        this.populateTodos();
    }

    componentDidMount() {
        this.populateTodos();
    }

    async todoLowerPrioririty(todo) {
        todo.priority--;
        let data = JSON.stringify({
            "title": todo.title,
            "description": todo.description,
            "deadline": todo.deadline,
            "priority": todo.priority,
            "state": todo.state,
            "id": todo.id
        });
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'PUT',
            body: data
        });
        this.populateTodos();
    }

    renderTodos(todos) {
        console.log(todos);
        todos = todos.sort((a, b) => {
            return a.priority - b.priority;
        });
        return(
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Deadline</th>
                    <th>Status</th>
                </tr>
                </thead>
                <tbody>
                {todos.map(todo =>
                    <tr key={todo.priority}>
                        <td>{todo.title}</td>
                        <td>{todo.description}</td>
                        <td>{todo.deadline}</td>
                        <td><Dropdown options={options} onChange={(state) => {
                            this.selectState(todo, state)
                        }} value={options[todo.state]} placeholder="Select an option"/></td>
                        <td>
                            <button onClick={() => {
                                this.deleteTodo(todo)
                            }}>Delete
                            </button>
                        </td>
                        <td>
                            <button onClick={() => {
                                this.todoLowerPrioririty(todo)
                            }}>^
                            </button>
                        </td>
                        <td>
                            <button onClick={() => {
                                this.todoHigherPriority(todo)
                            }}>v
                            </button>
                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    async populateTodos() {
        const response = await fetch(URL);
        const data = await response.json();
        this.setState({todos: data, loading: false});
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderTodos(this.state.todos);

        return (
            <div>
                <h1 id="tabelLabel" >Todo items</h1>
                {contents}
            </div>
        );
    }
}