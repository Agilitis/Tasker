import React from 'react';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";


export class TodoForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { title: '', description: '', deadline: '', priority: '', state: '', date: new Date() };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        let name = event.target.name;
        let value = event.target.value;
        this.setState({ [name]: value });
    }


    async handleSubmit(event) {
        event.preventDefault();
        var data = JSON.stringify({
            "title": event.target.title.value,
            "description": event.target.description.value,
            "deadline": this.state.date,
            "priority": "2",
            "state": "1"
        });
        console.log(data);
        await fetch('https://localhost:5001/api/todos', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: data,
        });
        this.props.refreshCallback(data);

    }



    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Title:
          <input name="title" type="text" value={this.state.title} onChange={this.handleChange} />
                </label>
                <label>
                    Description:
          <input name="description" type="text" value={this.state.description} onChange={this.handleChange} />
                </label>
                <label>
                    Priority:
          <input name="priority" type="text" value={this.state.priority} onChange={this.handleChange} />
                </label>
                <label>
                    Deadline:
                <DatePicker selected={Date.now()} onChange={date => this.setState({date: date})} />
                </label>
                <input type="submit" value="Submit" />
            </form>
        );
    }
}