import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {bindActionCreators} from 'redux';
import {actionCreators} from '../actions/actions';
import {connect} from 'react-redux';
import {LoginBox} from '../LoginPage/LoginBox';

export class NameContent extends Component {
  constructor(props) {
    super();
    this.state = {
      name: props.name,
      index: props.index
  };
  }

  render() {


    return (
      <p className="nameContent">
        <span>{this.state.name.StaffName}</span>
        <span>{this.state.name.Datetime}</span>
        <span>{this.state.name.Meno}</span>

      </p>
    );
  }
}

const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(NameContent);


