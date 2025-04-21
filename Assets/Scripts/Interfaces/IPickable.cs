namespace Shooter.Interfaces {
    using Inventory;

    public interface IPickable {
        void OnPickUp(Inventory inventory);
    }
}