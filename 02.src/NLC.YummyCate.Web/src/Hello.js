// import React, {Component} from 'react';
// import {bindActionCreators} from 'redux';
// import {connect} from 'react-redux';
// import {actionCreators} from './actions/actions';
//
// export class Hello extends Component {
//   render() {
//     const {name, list} = this.props;
//
//     return (
//       <div>
//         Hello, {name}!
//         <ul>
//           {(list || []).map((item, index) =>
//             <li key={index}><p>{item.title}</p><p>{item.body}</p></li>)}
//         </ul>
//       </div>
//     );
//   }
// }
//
// export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Hello);
