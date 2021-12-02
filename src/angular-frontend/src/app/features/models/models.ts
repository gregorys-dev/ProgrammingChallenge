export interface ChallengeTask {
    id: number
    name: string
    description: string
}

export interface ExecutionInfo {
    id: number
    script: string
    language: string
    usedMemory: string
    cpuTime: string
    output: string
}

export interface Solution {
    id: number
    playerId: number
    challengeTaskId: number
    executionInfoId: number
    executionInfo: ExecutionInfo
    isPassed: boolean
}

export interface TopThreePlayersItem {
    playerName: string
    successSolutions: number,
    taskNames: string[]
}
  