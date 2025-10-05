namespace Game.Core
{
    #region Logs
    public enum LogLevel
    {
        DEBUG,
        INFO,
        WARNING,
        ERROR
    }
    #endregion

    #region Characters
    public enum ECharacterAnimation
    {
        idle_down,
        idle_up,
        idle_left,
        idle_right,
        turn_down,
        turn_up,
        turn_left,
        turn_right,
        walk_down,
        walk_up,
        walk_left,
        walk_right
    }
    #endregion

    #region Levels

    public enum LevelName
    {
        wioska,
        wioska_zielony_domek,
        wioska_fioletowy_domek,
        wioska_centrum_pokemon,
        wioska_jaskinia,
    }
    #endregion

    #region Groups
    public enum LevelGroup
    {
        SPAWNPOINTS,
        SCENETRIGGERS,
    }
    #endregion

    #region Movements
    public enum ECharacterMovement
    {
        WALKING,
        JUMPING,
    }
    #endregion

    #region Sings

    public enum SignsType
    {
        METAL,
        WOOD,
    }
    #endregion
}