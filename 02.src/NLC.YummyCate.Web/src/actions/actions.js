import request, {onSuccess} from '../lib/request';

export const actions = {
  CHANGE_USERTYPE: 'CHANGE_USERTYPE',//登陆界面-选择管理员或用户
  GET_LOGINNAME: 'GET_LOGINNAME',//登陆界面-获取用户名
  GET_LOGINPASSWORD: 'GET_LOGINPASSWORD',//登陆界面-获取密码
  SEND_ASYNC_REQUEST: 'SEND_ASYNC_REQUEST', //登录：传用户名和密码
  CLEAR_INFO: 'CLEARINFO', //推出时清空登录信息
  USER_ORDER: 'USERORDER',//员工订餐+1
  CANCEL_ORDER: 'CANCELORDER',//员工取消订餐
  WRITE_MESSAGE: 'WRITEMESSAGE',//管理员写入备注
  CHOOSE_CLEANER: 'CHOOSE_CLEANER',//选择打扫人员
  GET_NAME_LIST: 'GET_NAME_LIST',//获取今日订餐的人员名单
  GET_USER_TIP: 'GET_USER_TIP'//获取用户写的备注
};

export const actionCreators = {
    changeUserType: (usertype) => {
      return {
        type: actions.CHANGE_USERTYPE,
        usertype: usertype
      };
    },
    getLoginName: (loginName) => {
      return {
        type: actions.GET_LOGINNAME,
        loginName: loginName
      };
    },
    getLoginPassword: (loginPassword) => {
      return {
        type: actions.GET_LOGINPASSWORD,
        loginPassword: loginPassword
      };
    },
    clearInfo: (usertype) => {
      return {
        type: actions.CLEAR_INFO,
        usertype: usertype
      };
    },
    writeMessage: (message) => {
      return {
        type: actions.WRITE_MESSAGE,
        message: message
      };
    },
    getUserTip: (userTip) => {
      return {
        type: actions.GET_USER_TIP,
        userTip: userTip
      };
    },

    userOrder: (params) =>
      request.get('http://192.168.3.94:8096/api/Order/StaffOrder', params)(actions.USER_ORDER),
    cancelOrder: (params) =>
      request.get('http://192.168.3.94:8096/api/Order/StaffCancelOrder', params)(actions.CANCEL_ORDER),

    sendAsyncRequest: (params) =>
      request.get('http://192.168.3.94:8096/api/User/UserLogin', params)(actions.SEND_ASYNC_REQUEST),


    chooseCleaner: (params) =>
      request.get('http://192.168.3.94:8096/api/Order/ProduceCleanerName', params)(actions.CHOOSE_CLEANER),

    getNameList: (params) =>
      request.get('http://192.168.3.94:8096/api/Order/GetAllStaffInfo', params)(actions.GET_NAME_LIST)

  }
;


export const handlers = {
  [actions.CHANGE_USERTYPE]: (state, action) => ({
    ...state,
    userType: action.usertype
  }),
  [actions.GET_LOGINNAME]: (state, action) => ({
    ...state,
    loginName: action.loginName
  }),
  [actions.GET_LOGINPASSWORD]: (state, action) => ({
    ...state,
    loginPassword: action.loginPassword
  }),
  [actions.CLEAR_INFO]: (state, action) => {
    console.log(state);
    console.log(action);
    return {
      ...state,
      loginPassword: '',
      loginName: '',
      userType: '',
      loginRequest: '',
      authority: ''
      // messageBox: ''
    };
  },
  [actions.WRITE_MESSAGE]: (state, action) => {
    // console.log(action);
    // console.log(state);
    return {
      ...state,
      messageBox: action.message
    };
  },
  [actions.GET_USER_TIP]: (state, action) => {
    console.log(action);
    console.log(state);
    return {
      ...state,
      userTip: action.userTip
    };
  },


  [onSuccess(actions.USER_ORDER)]: (state, action) => {
    console.log(action);
    console.log(state);
    return {
      ...state,
      orderSituation: action.payload.OrderingState
    };
  },
  [onSuccess(actions.CANCEL_ORDER)]: (state, action) => {
    // console.log(action);
    // console.log(state);
    return {
      ...state,
      orderSituation: action.payload.OrderingState
    };
  },
  [onSuccess(actions.CHOOSE_CLEANER)]: (state, action) => {
    // console.log(action);
    // console.log(state);
    return {
      ...state,
      cleaner1: action.payload.GetCleanerName1,
      cleaner2: action.payload.GetCleanerName2
    };
  },
  [onSuccess(actions.GET_NAME_LIST)]: (state, action) => {
    console.log(action);
    console.log(state);
    return {
      ...state,
      orderNameList: action.payload
    };
  },

  /**
   * Change state when request succeed
   * @param state
   * @param action
   */
  [onSuccess(actions.SEND_ASYNC_REQUEST)]: (state, action) => {
    console.log(action);
    console.log(state);
    return {
      ...state,
      // list: action.payload,
      loginRequest: action.payload.Result,  //是否允许登录
      authority: action.payload.Authority,  //用户类型
      finnalCount: action.payload.Count//订餐总人数
    };
  }
};
