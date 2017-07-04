requirejs(['react', 'reactDom', 'profileService'], function (React, ReactDOM, profileService) {

    class ContactInfo extends React.Component {

        constructor(props) {
            super(props);
            this.state = { isLoaded: false };
        }

        componentDidMount() {
            console.log(profileService);
            debugger;
        }

        render() {
            return (
       <div className="form-horizontal">
            <fieldset>
                <div className="form-group">
                    <label className="control-label col-md-2">Full Name</label>
                    <div className="col-md-3">
                        <input type="text" id="fullName" placeholder="Full name" className="form-control" />
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Address Line 1</label>
                    <div className="col-md-3">
                        <input type="text" id="addr1" placeholder="Address Line 1" className="form-control" />
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Address Line 2</label>
                    <div className="col-md-3">
                        <input type="text" id="addr2" placeholder="Address Line 2" className="form-control" />
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2">City</label>
                    <div className="col-md-3">
                        <input type="text" id="city" placeholder="City" className="form-control" />
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2">State/Province/Region</label>
                    <div className="col-md-3">
                        <input type="text" id="state" placeholder="State/Province/Region" className="form-control" />
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Zip/Postal Code</label>
                    <div className="col-md-3">
                        <input type="text" id="zip" placeholder="Zip/Postal Code" className="form-control" />
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Country</label>
                    <div className="col-md-3">
                        <select id="country" className="form-control">
                            <option>USA</option>
                        </select>
                    </div>
                </div>

            </fieldset>
       </div>);
        }
    }

    ReactDOM.render(
        <ContactInfo />,
        document.getElementById('location')
    );

});
//<input type="text" placeholder="Address line 1" />
//               <input type="text" placeholder="Address line 2" />
//               <input type="text" placeholder="City" />
//               <input type="text" placeholder="State/Province/Region" />
//               <input type="text" placeholder="Zip/Postal Code" />
//               <input type="text" placeholder="Country" />