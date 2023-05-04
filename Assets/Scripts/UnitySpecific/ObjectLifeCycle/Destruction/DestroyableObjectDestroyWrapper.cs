namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction
{
    public class DestroyableObjectDestroyWrapper : DestroyableWrapper
    {
        public override void Destroy() =>
            Destroy(gameObject);
    }
}
