public interface IAttackable
{
    float Health { get; set; }

    void OnDamaged(float damage);

    void OnKilled();

}
