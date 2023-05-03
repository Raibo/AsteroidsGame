namespace Assets.Scripts.Wrappers
{
    public class DestroyableObjectDestroyWrapper : DestroyableWrapper
    {
        public override void Destroy() =>
            Destroy(gameObject);
    }
}
