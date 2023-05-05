namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons
{
    public interface IAmmoProvider
    {
        public int AvailableCharges { get; }
        public int MaximumCharges { get; }
        public float RemainingNextChargeTime { get; }
        public float RemainingCooldownTime { get; }
        public bool IsReadyToUseCharge { get; }

        public bool TryUseCharge();
        public void Update(float time);
        public void Reset();
    }
}
