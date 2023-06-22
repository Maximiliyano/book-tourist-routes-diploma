import { UserRoles } from '../enums/user-roles';

export class RegisterUser {
  name: string;
  avatar: string | null;
  email: string;
  role: UserRoles;
  password: string;
}
