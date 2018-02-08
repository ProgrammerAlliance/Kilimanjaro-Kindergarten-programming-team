import {applyMiddleware, compose, createStore} from 'redux';
import {handlers} from './actions/actions';
import {apiMiddleware} from 'redux-api-middleware';
import {createRequestTypeHandlerReducer} from './lib/request';

const middlewares = [apiMiddleware];

/**
 * 设置初始状态
 */
const initialState = {
  loginName: '', loginPassword: '', userType: '',
  loginRequest: '', authority: '', orderSituation: 0,
  imgUrl: 'http://192.168.3.178:8080',
  messageBox: '', finnalCount: 0, cleaner1: '', cleaner2: '',
  orderNameList: [], userTip: ''//用户备注
};

const createStoreEnhanced = compose(applyMiddleware(...middlewares))(createStore);

const createGenericTypeHandlerReducer = handlers => (state = {}, action) => {
  if (handlers && handlers.hasOwnProperty(action.type)) {
    return handlers[action.type](state, action);
  } else {
    return state;
  }
};

const genericTypeHandlerReducer = createGenericTypeHandlerReducer(handlers);
const requestTypeHandlerReducer = createRequestTypeHandlerReducer(handlers);


const reducers = [
  genericTypeHandlerReducer,
  requestTypeHandlerReducer
];

/**
 * Create store
 */
const store = createStoreEnhanced((state = initialState, action) => {
  let prevState = state, nextState = state;

  for (let i = 0; i < reducers.length; i++) {
    const reducer = reducers[i];
    nextState = reducer(prevState, action);

    // break the loop when state changed
    if (prevState !== nextState) {
      break;
    }
  }


  return nextState;
});

export default store;
