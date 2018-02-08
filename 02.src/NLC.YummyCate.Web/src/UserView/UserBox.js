import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {bindActionCreators} from 'redux';
import {actionCreators} from '../actions/actions';
import {connect} from 'react-redux';
import {LoginBox} from '../LoginPage/LoginBox';

export class UserBox extends Component {
  constructor(props) {
    super();
  }

  render() {
    let hasOrder = 'hide';
    let noOrder = 'show';
    if (this.props.state.orderSituation === 1) {
      hasOrder = 'show';
      noOrder = 'hide';
    } else {
      noOrder = 'show';
      hasOrder = 'hide';
    }
    let deadTime = new Date().getHours() >= 17 && new Date().getHours() <= 24 ? 'show' : 'hide';
    console.log(deadTime);

    return (
      <div className="user">
        <div className="deadline"
             id={deadTime}>现在是订餐截止时间
        </div>
        <div className="box4">

          <h1> 纳龙点餐系统 · 员工界面</h1>
          <p className="userTip"><span>——————</span> 提示：每天17：00截止修改订餐状态 <span>——————</span></p>
          <div className="btns">
            <div className="link"
                 id={this.props.state.orderSituation !== 1 ? deadTime === 'hide' ? '' : 'disable' : 'disable'}
                 onClick={() => {
                   let orderInfo = {
                     // username: '111',
                     username: this.props.state.loginName,
                     meno: this.props.state.userTip
                   };
                   this.props.userOrder(orderInfo);
                 }}>订餐+1
            </div>
            <div className="link" id={deadTime === 'show' ? 'disable' : ''} onClick={() => {
              let orderInfo = {
                username: this.props.state.loginName
              };
              this.props.cancelOrder(orderInfo);
            }}>取消订餐
            </div>
            <Link to="/loginbox" className="link" id="link"
                  onClick={() => {
                    this.props.clearInfo('user');
                  }}>退出登录
            </Link>
          </div>

          <div className="addTip">
            <div className="tipTag">
              <span>备</span><span>注</span>
            </div>
            <textarea className="tipBox" onChange={(e) => {
              this.props.getUserTip(e.target.value);
              // this.value = this.value.substring(0, 20);
              }}
                      // maxLength="20"
              // onKeyDown={this.value.length >= 10?event.returnValue = false: }
                      // onKeyUp={this.value = this.value.substring(0, 20)}
                      // placeholder="可以告诉管理员你的个人要求..."
                      id={this.props.state.orderSituation !== 1 ? deadTime === 'hide' ? '' : 'disable' : 'disable'}
              >
              {this.props.state.userTip}
            </textarea>
          </div>

          <div className="orderSituation">
            <span id={noOrder}>订餐状态：未订餐</span>
            <span id={hasOrder}>订餐状态：已订餐</span>
          </div>
        </div>


      </div>
    )
      ;
  }
}

const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(UserBox);


