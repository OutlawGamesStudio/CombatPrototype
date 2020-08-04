namespace ForgottenLegends.Character
{
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
            ActorData.CharacterStats.Position = transform.position;
            ActorData.CharacterStats.Rotation = transform.rotation;
        }
    }
}