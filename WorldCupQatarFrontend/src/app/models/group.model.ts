import { TeamInterface } from "./team.model";

export interface GroupInterface {
  id: number;
  name: string;
  worldCupId?: number;
  teams?: TeamInterface[]
}
