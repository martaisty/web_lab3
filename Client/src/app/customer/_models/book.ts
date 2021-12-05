import {Sage} from './sage';

export interface Book {
  id?: string;
  name?: string;
  description?: string;
  sages?: Sage[];
  quantity?: number;
}
