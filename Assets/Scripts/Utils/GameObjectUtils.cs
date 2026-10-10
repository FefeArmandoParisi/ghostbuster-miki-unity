using UnityEngine;

public static class GameObjectUtils
{
    /// <summary>
    /// Returns the Transform of the first GameObject found with the given tag, or null if none found.
    /// This is a simple helper to centralize tag-based lookup logic.
    /// </summary>
    public static Transform FindTransformByTag(string tag)
    {
        var go = GameObject.FindWithTag(tag);
        return go != null ? go.transform : null;
    }

    public static Transform FindPlayer()
    {
        const string playerTag = GameConstants.TagPlayer;
        return GameObjectUtils.FindTransformByTag(playerTag).transform;
    }
}