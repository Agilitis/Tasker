import React, {Component, Fragment} from 'react';
import {TodoForm} from './TodoForm';
import 'react-dropdown/style.css'
import {TodoTable} from "./TodoTable";
const URL = "http://localhost:5000/api/todos/";


export class TodoPage extends Component {
    static displayName = TodoPage.name;


    callbackFunction = async (data) => {
        const response = await fetch(URL);
        this.setState({ todos: await response.json(), loading: false });
    };

    constructor(props) {
        super(props);
        this.state = {todos: []};

    }


    render() {
        return (
            <Fragment>
                <TodoTable todos = {this.state.todos} />
                <TodoForm refreshCallback={this.callbackFunction.bind(this)}/>
            </Fragment>
        );
    }


}
