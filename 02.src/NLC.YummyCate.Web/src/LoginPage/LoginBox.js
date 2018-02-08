import React, {Component} from 'react';
import {Link, withRouter} from 'react-router-dom';
import createBrowserHistory from 'history/createBrowserHistory';

import store from '../store';
import {connect, Provider} from 'react-redux';
import {Route, Router} from 'react-router';

import SigninBox from '../SigninPage/SigninBox';
import UserBox from '../UserView/UserBox';
import ManageBox from '../ManagerView/ManagerBox';
import {actionCreators} from '../actions/actions';
import {bindActionCreators} from 'redux';
// import {connect} from 'react-redux';

// const history = createBrowserHistory();
// const routes = [
//   {path: '/SigninBox', component: SigninBox}
// ];

export class LoginBox extends Component {
  constructor(props) {
    super();
    // console.log(props);
    this.state = {
      loginTip: 'hide'
    };
    this.login = this.login.bind(this);
  }

  login() {
    if (this.props.state.userType === 'manager'
      && this.props.state.loginRequest === true
      && this.props.state.authority === 2) {
      this.setState({loginTip: 'hide'});
      this.props.history.push('/Managerbox/situation');
    } else if (this.props.state.userType === 'user'
      && this.props.state.loginRequest === true
      && this.props.state.authority === 1) {
      this.setState({loginTip: 'hide'});

      this.props.history.push('/userbox');
    } else {
      this.setState({loginTip: 'show'});
    }
  }

  render() {
    // console.log(this.props.state);
    return (
      <div className="container">
        <section id="content">
          <form action="">
            <h1>纳龙点餐系统</h1>
            <div>
              <div className="loginErrorTip" id={this.state.loginTip}>❌用户名或密码错误❌</div>
              <input type="text" placeholder="Username" required="" id="username" onChange={(e) => {
                this.props.getLoginName(e.target.value);
              }}/>
            </div>
            <div>
              <input type="password" placeholder="Password" required="" id="password" onChange={(e) => {
                this.props.getLoginPassword(e.target.value);
              }}/>
            </div>
            <div>
              <span><input type="radio" name="loginRadio" value="manager" onChange={e => {
                this.props.changeUserType(e.target.value);
              }}/>管理员登录</span>
              <span><input type="radio" name="loginRadio" value="user" onChange={e => {
                this.props.changeUserType(e.target.value);
              }}/>用户登录</span>
            </div>
            <div>
              <div className="link" onClick={e => {
                e.preventDefault();
                // this.props.sendAsyncRequest();
                const loginInfo = {
                  username: this.props.state.loginName,
                  password: this.props.state.loginPassword
                };
                this.props.sendAsyncRequest(loginInfo).then(this.login);
              }}>登录
              </div>
            </div>
          </form>

        </section>
      </div>
    );
  }
}

const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(LoginBox);

