import React, {Component} from 'react';
// import {bindActionCreators} from 'redux';
// import {connect} from 'react-redux';
import {Link} from 'react-router-dom';


export default class SigninBox extends Component {
  constructor(props) {
    super();
  }

  render() {
    return (
      <div className="signInBox">
        <h1>纳龙注册系统</h1>
        <form>

          <div className="signUser">
            用户名：<input type="text"/>
          </div>
          <div className="signPassword">
            密码：<input type="text"/>
          </div>
          <div className="signName">
            姓名：<input type="text"/>
          </div>
          <div  className="signDepartment">
            部门：
            <select>
              <option>技术部</option>
              <option>非技术部</option>
            </select>
          </div>

          <input type="button" value="取消" className="link"/>
          <Link to="/LoginBox" className="link">确定</Link>

        </form>
      </div>
    );
  }
}

