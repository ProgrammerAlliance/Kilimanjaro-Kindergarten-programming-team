import {RSAA} from 'redux-api-middleware';
import queryString from 'query-string';

const createRequest = (method, endpoint, params = {}) => handler => {
  let body = null, query = '';

  if (method.toLowerCase() === 'get') {
    query = queryString.stringify(params);
  } else {
    body = JSON.stringify(params);
  }

  return {
    [RSAA]: {
      method: method,
      endpoint: `${endpoint}${query ? '?' + query : ''}`,
      headers: {
        'Content-Type': 'application/json'
      },
      body: body,
      types: [
        {
          type: 'REQUEST',
          meta: handler,
        },
        {
          type: 'SUCCESS',
          meta: handler,
          payload: (action, state, res) => res.json(),
        },
        'FAILURE'
      ],
    }
  };
};

export const onRequest = (action) => action + '_REQUEST';
export const onFailure = (action) => action + '_FAILURE';
export const onSuccess = (action) => action + '_SUCCESS';

export const createRequestTypeHandlerReducer = handlers => (state = {}, action) => {
  const key = action.meta + '_' + action.type;

  if (handlers && handlers.hasOwnProperty(key)) {
    return handlers[key](state, action);
  } else {
    return state;
  }
};

/**
 * HTTP request methods definitions
 */
const methods = ['get', 'post', 'delete', 'put', 'options'];

const request = {};

/**
 * Map request functions
 */
methods.map(method => (endpoint, params) => handler => createRequest(method, endpoint, params)(handler))
  .forEach((fn, index) => {
    request[methods[index]] = fn;
  });

export default request;
