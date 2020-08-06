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
            m_ActorInfo.CharacterStats.Position = transform.position;
            m_ActorInfo.CharacterStats.Rotation = transform.rotation;
        }
    }
}