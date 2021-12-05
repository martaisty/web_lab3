import {User} from '../../auth/auth.model';
import {Book} from '../../customer/_models/book';

export interface Order {
  id?: string;
  customer?: User;
  books?: Book[]
}
