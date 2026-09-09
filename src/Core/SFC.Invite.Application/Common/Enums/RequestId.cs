namespace SFC.Invite.Application.Common.Enums;
public enum RequestId
{
    // main
    DatabaseReset,
    // data
    InitData,
    ResetData,
    // identity
    CreateUser,
    CreateUsers,
    // player
    CreatePlayer,
    UpdatePlayer,
    CreatePlayers,
    // team
    ResetTeamData,
    CreateTeam,
    UpdateTeam,
    CreateTeams,
    // team player
    CreateTeamPlayer,
    UpdateTeamPlayer,
    CreateTeamPlayers,
    // game
    ResetGameData,
    CreateGame,
    UpdateGame,
    CreateGames,
    // game player
    CreateGamePlayer,
    UpdateGamePlayer,
    CreateGamePlayers,
    // game team
    CreateGameTeam,
    UpdateGameTeam,
    CreateGameTeams,
    // core
    TeamPlayerInviteExist,
    GetAllInviteData,
    CreateTeamPlayerInvite,
    CreateTeamPlayerInvites,
    UpdateTeamPlayerInvite,
    GetTeamPlayerInvite,
    GetAllTeamPlayerInvites,
    GetTeamPlayerInvites,
    // invite game player
    CreateGamePlayerInvite,
    CreateGamePlayerInvites,
    UpdateGamePlayerInvite,
    ExistGamePlayerInvite,
    GetGamePlayerInvite,
    GetsGamePlayerInvite,
    GetGamePlayerInvites,
    // invite game team
    CreateGameTeamInvite,
    CreateGameTeamInvites,
    UpdateGameTeamInvite,
    ExistGameTeamInvite,
    GetGameTeamInvite,
    GetsGameTeamInvite,
    GetGameTeamInvites,
}