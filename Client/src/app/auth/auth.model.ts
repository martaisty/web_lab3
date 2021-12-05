export interface User {
  userName?: string;
  password?: string;
  firstName?: string;
  lastName?: string;
  roles?: string[];
}

export interface Tokens {
  accessToken: string;
}


export interface AuthDto {
  user: User;
  accessToken: string;
}
