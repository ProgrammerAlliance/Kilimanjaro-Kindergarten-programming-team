import React, {Component} from 'react';

import store from './store';
import {Provider} from 'react-redux';
import {Route, Router} from 'react-router';
import createBrowserHistory from 'history/createBrowserHistory';

import LoginBox from './LoginPage/LoginBox';

import {Link} from 'react-router-dom';
import SigninBox from './SigninPage/SigninBox';
import UserBox from './UserView/UserBox';
import ManagerBox from './ManagerView/ManagerBox';
import Situation from './ManagerView/Situation';

const history = createBrowserHistory();

/**
 * 自定义路由
 */
const routes = [
  {path: '/loginbox', component: LoginBox},
  {path: '/signinbox', component: SigninBox},
  {path: '/userbox', component: UserBox},
  {path: '/Managerbox', component: ManagerBox}
];

export default class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <Router history={history}>
          <div>
            <Route path="/" component={LoginBox} exact/>
            {
              routes.map((route, index) =>
                <Route key={index} path={route.path} component={route.component}/>)
            }
          </div>
        </Router>
      </Provider>
    );
  }
}
