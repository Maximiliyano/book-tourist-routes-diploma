import { AccessTokenDto } from "../interfaces/access-token-dto";
import { User } from "./user";

export interface LoginUserCredentials {
  user: User;
  token: AccessTokenDto;
}
