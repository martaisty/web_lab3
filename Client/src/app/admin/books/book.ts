import {Sage} from '../sages/sage';

export interface Book {
  id?: string;
  name?: string;
  description?: string;
  sages?: Sage[];
}

export interface BookUpdate {
  id?: string;
  name?: string;
  description?: string;
  sages?: number[];
}
