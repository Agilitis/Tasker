import React, { Component } from 'react';
import { Route } from 'react-router';
import { TodoPage } from './components/TodoPage';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Route exact path='/' component={TodoPage} />
        );
    }
}
