import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {UserBox} from '../UserView/UserBox';
import {actionCreators} from '../actions/actions';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import NameContent from './NameContent';

export class userManage extends Component {
  constructor(props) {
    super();
  }

  render() {
    return (
      <div className="userManageBox">
        <div className="userManageList">
          {this.props.state.orderNameList.map((name, index) => <NameContent name={name} index={index}/>)}

        </div>
      </div>
    );
  }
}

const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(userManage);



