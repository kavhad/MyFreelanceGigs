import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import GigListView from './GigListView';

test('renders todo list and todo item', () => {
  render(<GigListView gigList={[{GigId:"1", Title: "Test List"}]}/>);
  expect(screen.getByText(/Test List/i)).toBeInTheDocument();
  expect(screen.getByText(/Run Test/i)).toBeInTheDocument();
});
