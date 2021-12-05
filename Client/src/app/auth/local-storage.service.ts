import {Injectable} from '@angular/core';
import {Tokens, User} from './auth.model';

const USER_KEY = 'auth-user';
const TOKEN_KEY = 'auth-token';

export function tokenGetter() {
  const tokens = localStorage.getItem(TOKEN_KEY);
  if (tokens) {
    return (JSON.parse(tokens) as Tokens).accessToken;
  }
  return null;
}

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() {
  }

  logout() {
    localStorage.clear();
  }

  saveToken(tokens: Tokens): void {
    localStorage.setItem(TOKEN_KEY, JSON.stringify(tokens));
  }

  getToken(): Tokens | null {
    const tokens = localStorage.getItem(TOKEN_KEY);
    if (tokens) {
      return JSON.parse(tokens);
    }
    return null;
  }

  saveUser(user: User): void {
    localStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  getUser(): User | null {
    const user = localStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return null;
  }
}
