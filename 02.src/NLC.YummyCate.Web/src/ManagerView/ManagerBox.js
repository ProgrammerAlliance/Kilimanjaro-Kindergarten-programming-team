import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import Situation from './Situation';
import SigninBox from '../SigninPage/SigninBox';
import LoginBox from '../LoginPage/LoginBox';
import UserBox from '../UserView/UserBox';
import {bindActionCreators} from 'redux';


import {Route, Router} from 'react-router';
import TodayCleaner from './todayCleaner';
import UserManageBox from './userManage';
import {actionCreators} from '../actions/actions';
import {connect} from 'react-redux';


const routes = [

  {path: '/ManagerBox/situation', component: Situation},
  {path: '/ManagerBox/todayCleaner', component: TodayCleaner},
  {path: '/ManagerBox/userManage', component: UserManageBox},
  {path: '/loginbox', component: LoginBox}
];


export class ManagerBox extends Component {
  constructor(props) {
    super();
  }

  render() {
    return (
      <div className="manager">

        <div className="box4">
          <h1> 纳龙点餐系统 · 管理界面</h1>

          <div className="ribbon">
            <Link to="/ManagerBox/situation"><span>查看订餐情况</span></Link>
            <Link to="/ManagerBox/todayCleaner"><span>今日打扫</span></Link>
            <Link to="/ManagerBox/userManage" onClick={()=>{this.props.getNameList('list');}}><span>今日订餐名单</span></Link>
            <Link to="/loginbox" onClick={()=>{this.props.clearInfo('manager');}}><span>退出登录</span></Link>

          </div>
          <div>
            <Route path="/ManagerBox/" component={Situation} exact/>
            {
              routes.map((route, index) =>
                <Route key={index} path={route.path} component={route.component}/>)
            }

          </div>

          <br/>
          {/*<div className="shr_box4">1</div>*/}
          {/*<div className="shl_box4">2</div>*/}
        </div>


      </div>


    );
  }
}
const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(ManagerBox);



