import React, {Component} from 'react';
import Enzyme, {shallow} from 'enzyme';
import {Notify} from '../src/Notify';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({adapter: new Adapter()});

test('notify test', () => {
  let component;

  const props = {
    sayHello: () => {

    },
    sendAsyncRequest: (params) => {
      expect(component.state().loading).toEqual(true);

      return new Promise((resolve, reject) => {
        resolve();

        expect(component.state().loading).toEqual(false);
      });
    }
  };

  component = shallow(<Notify {...props}/>);
  component.find('button').at(2).simulate('click');
});
