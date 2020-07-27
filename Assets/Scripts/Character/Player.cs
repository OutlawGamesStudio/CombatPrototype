using UnityEngine;

public class Player : Actor
{
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    protected override void Update()
    {
        CharacterStats.Position = transform.position;
        CharacterStats.Rotation = transform.rotation;
    }
}
