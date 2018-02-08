// import React, {Component} from 'react';
// import {bindActionCreators} from 'redux';
// import {connect} from 'react-redux';
// import {actionCreators} from './actions/actions';
//
// export class Notify extends Component {
//   state = {
//     loading: false
//   };
//
//   handleSayHello(text) {
//     this.props.sayHello(text);
//   }
//
//   handleAsyncRequest = () => {
//     this.setState({
//       loading: true
//     });
//
//     this.props.sendAsyncRequest({a: 1, b: 2}).then(() => {
//       this.setState({
//         loading: false
//       });
//     });
//   };
//
//   render() {
//     return (
//       <div>
//         <button onClick={() => this.handleSayHello('Tom')}>Tom</button>
//         <button onClick={() => this.handleSayHello('Jerry')}>Jerry</button>
//         <button onClick={this.handleAsyncRequest} disabled={this.state.loading}>
//           {this.state.loading ? 'Loading...' : 'Async Request'}
//         </button>
//       </div>
//     );
//   }
// }
//
// export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Notify);
