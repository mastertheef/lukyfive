requirejs(['react', 'reactDom', 'Scripts/Services/profileService'], function (React, ReactDOM, profileService) {

    class ContactInfo extends React.Component {

        constructor(props) {
            super(props);
            this.state = {
                isLoaded: false,
                data: {}
            };

            this.saveProfileSettings = this.saveProfileSettings.bind(this);
        }

        componentDidMount() {
            var self = this;
            profileService.getProfileSettings().then(function (data) {
                if (data && data !== '') {
                    self.setState({ data: data });
                }
                self.state.isLoaded = true;
            });
        }

        handleChange(field, e) {
            var data = this.state.data;
            data[field] = e.target.value;
            this.setState({ data: data });
        }

        saveProfileSettings() {
            var self = this;
            this.state.isLoaded = false;
            profileService.saveProfileSettings(this.state.data).then(function() {
                self.state.isLoaded = true;
            });
        }

        render() {
            return (
               
       <div className="form-horizontal">
            <fieldset>
                <div className="form-group">
                    <label className="control-label col-md-2">Full Name</label>
                    <div className="col-md-3">
                        <input type="text" id="fullName" placeholder="Full name" className="form-control" value={this.state.data.FullName} onChange={this.handleChange.bind(this, "FullName")}/>
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Address Line 1</label>
                    <div className="col-md-3">
                        <input type="text" id="addr1" placeholder="Address Line 1" className="form-control" value={this.state.data.Addr1} onChange={this.handleChange.bind(this, "Addr1")}/>
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Address Line 2</label>
                    <div className="col-md-3">
                        <input type="text" id="addr2" placeholder="Address Line 2" className="form-control" value={this.state.data.Addr2} onChange={this.handleChange.bind(this, "Addr2")}/>
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2">City</label>
                    <div className="col-md-3">
                        <input type="text" id="city" placeholder="City" className="form-control" value={this.state.data.City} onChange={this.handleChange.bind(this, "City")} />
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2">State/Province/Region</label>
                    <div className="col-md-3">
                        <input type="text" id="state" placeholder="State/Province/Region" className="form-control" value={this.state.data.Region} onChange={this.handleChange.bind(this, "Region")}/>
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Phone</label>
                    <div className="col-md-3">
                        <input type="text" id="zip" placeholder="Phone" className="form-control" value={this.state.data.Phone} onChange={this.handleChange.bind(this, "Phone")} />
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Zip/Postal Code</label>
                    <div className="col-md-3">
                        <input type="text" id="zip" placeholder="Zip/Postal Code" className="form-control" value={this.state.data.ZipCode} onChange={this.handleChange.bind(this, "ZipCode")}/>
                    </div>
                </div>

                <div className="form-group">
                    <label className="control-label col-md-2">Country</label>
                    <div className="col-md-3">
                        <select id="country" className="form-control" value={this.state.data.Country} onChange={this.handleChange.bind(this, "Country")}>
                            <option>USA</option>
                        </select>
                    </div>
                </div>
                

               <div className="form-group">
                    <div className="col-md-offset-2 col-md-3">
                        <button type="button" className="btn btn-primary" onClick={this.saveProfileSettings}>Save</button>
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