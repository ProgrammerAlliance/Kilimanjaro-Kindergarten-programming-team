import React, {Component} from 'react';
import Enzyme, {shallow} from 'enzyme';
import {Hello} from '../src/Hello';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({adapter: new Adapter()});

test('hello, world', () => {
  const component = shallow(<Hello name="world"/>);

  expect(component.text()).toEqual('Hello, world!');
});
