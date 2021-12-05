import {Book} from '../books/book';

export interface Sage {
  id?: string;
  name?: string;
  age?: number;
  city?: string;
  books?: Book[];
}

export interface SageUpdate {
  id?: string;
  name?: string;
  age?: number;
  city?: string;
  books?: number[];
}
