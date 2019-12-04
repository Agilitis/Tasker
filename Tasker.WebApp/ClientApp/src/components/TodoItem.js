import React, { Component, Fragment } from 'react';
import { TodoForm } from './TodoForm';
import Dropdown from 'react-dropdown'
import 'react-dropdown/style.css'

const HEADER = {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
};

const URL = "http://localhost:5000/api/todos/"

export class TodoItem extends Component {
    static displayName = TodoItem.name;


    callbackFunction = async (todo) => {
        const response = await fetch(URL);
        let data = await response.json();
        this.setState({ todos: data, loading: false });
    }

    constructor(props) {
        super(props);
        this.state = { todos: [], loading: true };

    }

    componentDidMount() {
        this.populateTodos();
    }

    async deleteTodo(todo) {
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'DELETE'
        });
        this.populateTodos();
    }



    async todoHigherPriority(todo) {
        todo.priority++;
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'DELETE'
        });
        var data = JSON.stringify({
            "title": todo.title,
            "description": todo.description,
            "deadline": todo.deadline,
            "priority": todo.priority,
            "state": todo.state
        });
        console.log(data);
        await fetch(URL, {
            headers: HEADER,
            method: 'POST',
            body: data,
        });
        this.populateTodos();
    }

    async todoLowerPrioririty(todo) {
        todo.priority--;
        await fetch(URL + todo.id, {
            headers: HEADER,
            method: 'DELETE'
        });
        var data = JSON.stringify({
            "title": todo.title,
            "description": todo.description,
            "deadline": todo.deadline,
            "priority": todo.priority,
            "state": todo.state
        });
        await fetch(URL, {
            headers: HEADER,
            method: 'POST',
            body: data,
        });
        this.populateTodos();
    }

    async selectState(todo, state) {
        var data = JSON.stringify({
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
        this.populateTodos();
    }



    renderTodos(todos) {
        todos = todos.sort((a, b) => {
            return a.priority - b.priority;
        });
        const options = [
            { value: 0, label: "Paused" },
            { value: 1, label: "Doing" },
            { value: 2, label: "Finished" },
            { value: 3, label: "Postponed" }
        ]
        return (
            <Fragment>
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
                                <td><Dropdown options={options} onChange={(state) => { this.selectState(todo, state) }} value={options[todo.state]} placeholder="Select an option" /></td>
                                <td><button onClick={() => { this.deleteTodo(todo) }}>Delete</button></td>
                                <td><button onClick={() => { this.todoLowerPrioririty(todo) }}>^</button></td>
                                <td><button onClick={() => { this.todoHigherPriority(todo) }}>v</button></td>
                            </tr>
                        )}
                    </tbody>

                </table>
                <TodoForm refreshCallback={this.callbackFunction} />
            </Fragment>



        );
    }

    onSubmit(data) {
        console.log(data)
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

    async populateTodos() {
        const response = await fetch(URL);
        const data = await response.json();
        this.setState({ todos: data, loading: false });
    }
}
