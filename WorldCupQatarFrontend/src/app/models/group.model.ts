import { TeamInterface } from "./team.model";

export interface GroupInterface {
  id: number;
  groupName: string;
  worldCupId?: number;
  teams?: TeamInterface[]
}
