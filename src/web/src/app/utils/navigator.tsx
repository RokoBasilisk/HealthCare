const ROOM_ROOT = "/room"
const HOME_ROOT = "/home"

export interface IRoomNavigator {
    ROOM_BOARD: (roomId: string) => string,
    ROOM_MATCH: (roomId: string) => string,
}

export interface IHomeNavigator {
    HOME_INDEX: () => string,
    HOME_: (userId: string) => string,
}

export const roomNavigator: IRoomNavigator = {
    ROOM_BOARD: (roomId: string) => `${ROOM_ROOT}/${roomId}/board`,
    ROOM_MATCH: (roomId: string) => `${ROOM_ROOT}/${roomId}/match`
};

export const homeNavigator: IHomeNavigator = {
    HOME_INDEX: () => `${HOME_ROOT}/`,
    HOME_: (userId: string) => `${HOME_ROOT}/users/${userId}`
};