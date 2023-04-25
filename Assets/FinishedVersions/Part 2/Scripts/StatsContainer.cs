
namespace PartTwo
{
    public class StatsContainer
    {
        public Stat Health;
        public Stat Mana;
        public Stat Speed;
        public Stat Strenght;
        public Stat Intelligence;
        public Stat CurrentHealth;
        public Stat CurrentMana;

        public StatsContainer(CharacterClass characterClass)
        {
            Health = new Stat(StatKeys.Health, characterClass.Health.baseStatValue);
            Mana = new Stat(StatKeys.Mana, characterClass.Mana.baseStatValue);
            Speed = new Stat(StatKeys.Speed, characterClass.Speed.baseStatValue);
            Strenght = new Stat(StatKeys.Strenght, characterClass.Strenght.baseStatValue);
            Intelligence = new Stat(StatKeys.Intelligence, characterClass.Intelligence.baseStatValue);

            CurrentHealth = new Stat(StatKeys.CurrentHealth, characterClass.Health.baseStatValue);
            CurrentMana = new Stat(StatKeys.CurrentMana, characterClass.Mana.baseStatValue);
        }

        public Stat getStat(StatKeys statKey)
        {
            var fields = typeof(StatsContainer).GetFields();

            foreach (var item in fields)
            {
                Stat value = (Stat)item.GetValue(this);

                if (value.statKey == statKey)
                    return value;
            }

            return null;
        }
    }
}
