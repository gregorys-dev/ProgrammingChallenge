export interface ChallengeTask {
    id: number;
    name: string;
    description: string;
}

export interface PlayerScore {
    playerName: string;
    successfulSubmissions: number;
    solvedTaskIds: number[];
}

export interface ExecutionInfo {
    id: number;
    script: string;
    language: string;
    usedMemory: string;
    cpuTime: string;
}

export interface Solution {
    id: number;
    playerId: number;
    challengeTaskId: number;
    executionInfoId: number;
    executionInfo: ExecutionInfo;
    isPassed: boolean;
}