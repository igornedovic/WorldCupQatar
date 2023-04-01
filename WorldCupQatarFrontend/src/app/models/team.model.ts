export interface TeamInterface {
    id?: number,
    name: string,
    iconUrl?: string,
    matchesPlayed?: number,
    wins?: number,
    draws?: number,
    losses?: number,
    goalsScored?: number,
    goalsConceded?: number,
    points?: number
    groupId?: number
}