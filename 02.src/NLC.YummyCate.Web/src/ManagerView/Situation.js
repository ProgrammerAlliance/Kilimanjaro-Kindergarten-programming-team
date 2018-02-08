import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {UserBox} from '../UserView/UserBox';
import {actionCreators} from '../actions/actions';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';

export class Situation extends Component {
  constructor(props) {
    super();
  }

  render() {
    return (
      <div className="situationBox">
        <div className="situationContent">
          <div className="eaterNum">
            <span>今日吃饭人数：<b>{this.props.state.finnalCount}</b></span>
            <span>预计金额：<b>{20 * this.props.state.finnalCount}</b></span>
          </div>
          <img src={this.props.state.imgUrl + '/src/picture/face.png'} className="face"/>


          {/*<Link to="/ManagerBox/createMessage" className="link" onClick={console.log(this.props.state)}>生成订餐信息</Link>*/}

        </div>

      </div>
    );
  }
}

const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(Situation);



