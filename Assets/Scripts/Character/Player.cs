using UnityEngine;

public class Player : Singleton<Player>
{
    public CharacterStats CharacterStats;

    private void Update()
    {
        CharacterStats.Position = transform.position;
        CharacterStats.Rotation = transform.rotation;
    }
}
