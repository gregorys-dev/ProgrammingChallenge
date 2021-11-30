export interface SubmitSolutionCommand {
    playerName: string,
    challengeTaskId: number,
    solutionCode: string,
    language: 'python3' | 'csharp'
}