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
    // core
    GetAllInviteData,
    CreateTeamPlayerInvite,
    UpdateTeamPlayerInvite,
    GetTeamPlayerInvite,
    GetTeamPlayerInvites,
}