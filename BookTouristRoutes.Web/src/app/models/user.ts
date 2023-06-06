import { Avatar } from "./avatar";

export class User {
  id: number;
  name: string;
  password: string;
  avatar: Avatar;
  avatarId: number | null;
  email: string;
  role: number;
  salt: string;
  createdAt: Date;
  updatedAt: Date;
}
