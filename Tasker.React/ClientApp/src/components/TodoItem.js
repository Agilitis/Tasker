import React, { Component, Fragment } from 'react';
import { TodoForm } from './TodoForm';
import Dropdown from 'react-dropdown'
import 'react-dropdown/style.css'

export class TodoItem extends Component {
    static displayName = TodoItem.name;

    callbackFunction = async (todo) => {
        const response = await fetch('https://localhost:5001/api/todos');
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

    deleteTodo(todo) {
        console.log(todo);
    }

    selectStatE(state) {
        console.log(state);
    }





    renderTodos(todos) {
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
                        <tr key={todo.id}>
                            <td>{todo.title}</td>
                            <td>{todo.description}</td>
                            <td>{todo.deadline}</td>
                            <td><Dropdown options={options} onChange={this.selectState} value={options[todo.state]} placeholder="Select an option" /></td>
                            <td><button onClick={() => { this.deleteTodo(todo) }}>Delete</button></td>
                            
                            
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
        const response = await fetch('https://localhost:5001/api/todos');
        const data = await response.json();
        console.log(data);
        this.setState({ todos: data, loading: false });
    }
}
