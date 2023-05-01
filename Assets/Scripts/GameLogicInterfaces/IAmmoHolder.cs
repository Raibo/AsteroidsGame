namespace Hudossay.Asteroids.Assets.Scripts.GameLogicInterfaces
{
    public interface IAmmoHolder
    {
        public int AvailableCharges { get; }
        public int MaximumCharges { get; }
        public float RemainingNextChargeTime { get; }
        public float RemainingCooldownTime { get; }
        public bool TryUseCharge();
        public void Update(float time);
    }
}
