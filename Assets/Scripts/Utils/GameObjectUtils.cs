using UnityEngine;

public static class GameObjectUtils
{
    public static PlayerBase FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag(GameConstants.PlayerTag);
        return playerObject != null ? playerObject.GetComponent<PlayerBase>() : null;
    }
}