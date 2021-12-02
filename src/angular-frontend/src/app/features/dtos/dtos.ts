export interface SubmitSolutionCommand {
    playerName: string,
    challengeTaskId: number,
    solutionCode: string,
    language: 'python3' | 'csharp'
}

export interface PlayerScore {
    playerName: string
    successfulSubmissions: number
    solvedTaskIds: number[]
}