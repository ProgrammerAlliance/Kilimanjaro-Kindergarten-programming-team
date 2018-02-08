import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {ManagerBox} from './ManagerBox';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import {actionCreators} from '../actions/actions';

export class TodayCleaner extends Component {
  constructor(props) {
    super();
  }

  render() {
    return (
      <div className="cleaner">
        <div className="cleanerContent">
          <div className="cleanerButton"
               // onClick={()=>{alert(1)}}>点击随机生成打扫名单
               onClick={()=>{this.props.chooseCleaner('clean');}}>点击随机生成打扫名单
          </div>
          <div className="cleanerBox">
            <p>{this.props.state.cleaner1}</p>
            <p>{this.props.state.cleaner2}</p>
          </div>
        </div>


      </div>
    );
  }
}
const mapState = (state) => {
  return {state: state};
};
export default connect(mapState, (dispatch) => bindActionCreators(actionCreators, dispatch))(TodayCleaner);



