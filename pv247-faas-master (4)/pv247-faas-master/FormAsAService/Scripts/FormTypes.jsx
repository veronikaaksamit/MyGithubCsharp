var ElementType = React.createClass({
    render: function() {
        return (
            <table>
                <tr>
                    <th>ID</th>
                    <td>{this.props.data.Id}</td>
                </tr>
                <tr>
                    <th>Name</th>
                    <td>{this.props.data.Name}</td>
                </tr>
                <tr>
                    <th>ElementHtmlType</th>
                    <td>{this.props.data.ElementHtmlType}</td>
                </tr>
            </table>
         );
    }
});

var ElementTypeList = React.createClass({
    render: function () {
        var elementTypeNodes = this.props.data.map(function (elementType) {
            return (
                <li>
                    <ElementType data={elementType}></ElementType>
                </li>
            );  
        });

        return (
            <ul>
                {elementTypeNodes}
            </ul>
        );
    }
});

var FormType = React.createClass({
    render: function() {
        return (
            <table>
                <tr>
                    <th>ID</th>
                    <td>{this.props.data.Id}</td>
                </tr>
                <tr>
                    <th>Name</th>
                    <td>{this.props.data.Name}</td>
                </tr>
                <tr>
                    <th>Elements</th>
                    <td><ElementTypeList data={this.props.data.ElementTypes} /></td>
                </tr>
            </table>
         );
    }
});

var FormTypeList = React.createClass({
    getInitialState: function () {
        return { data: [] };
    },
    componentDidMount: function () {
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.setState({ data: data });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    render: function () {
        var formTypeNodes = this.state.data.map(function (formType) {
            return (
                <FormType data={formType}></FormType>
            );
        });

        return (
            <div>
                {formTypeNodes}
            </div>
        );
    }
});

React.render(
  <FormTypeList url="/api/FormTypes" />,
  document.getElementById('reactContent')
);