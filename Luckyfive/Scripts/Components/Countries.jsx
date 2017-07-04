class Countries extends React.Component{
    constructor(props) {
        super(props);
        $.ajax({
            method: 'GET',
            crossDomain: true,
            dataType: "json",
            url: 'https://restcountries.eu/rest/v2/all?fields=name'
        }).done(
            function(data) {
                console.log(data);
            }
        );
    }

    render() {
        return (<span>I am countries component</span>);
    }
};

ReactDOM.render(
  <Countries />,
  document.getElementById("countries")
);
