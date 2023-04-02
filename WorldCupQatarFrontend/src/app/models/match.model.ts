export enum MatchStatus {
  NotStarted = "NotStarted",
  Finished = "Finished",
  Team1Forfeit = "Team1Forfeit",
  Team2Forfeit = "Team2Forfeit"
}

export interface MatchInterface {
    id?: number;
    matchDateTime: Date | string;
    status?: MatchStatus;
    team1Id?: number;
    team1Name?: string;
    team1Goals?: number;
    team2Id?: number;
    team2Name?: string;
    team2Goals?: number;
    stadiumId?: number;
    stadiumName?: string;
}
