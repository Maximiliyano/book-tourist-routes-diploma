import { AccessTokenDto } from "../interfaces/access-token-dto";
import { User } from "./user";

export class LoginUserCredentials {
  user: User;
  token: AccessTokenDto;
}
