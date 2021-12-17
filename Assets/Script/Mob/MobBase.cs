namespace Script.Mob
{
    public abstract class MobBase
    {
        public int QuantityOfLife { get; private set; }

        public MobBase(int quantityOfLife)
        {
            QuantityOfLife = quantityOfLife;
        }

        public void TakeHitAndDoSomeBehavior(int damageTaken)
        {
            TakeAHit(damageTaken);
            
            if(QuantityOfLife <= 0)
                OnDeath();
            
            BehaviorOnHit();
        }

        public abstract void OnDeath();

        public abstract void TakeAHit(int damageTaken);
        public abstract void BehaviorOnHit();
    }
}