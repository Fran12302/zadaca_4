using System.Security.Cryptography.X509Certificates;

namespace metoda_tvornica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new MechFyctory());
            game.SpoonChamp("shit");
        }
    }
    public class Game
    {
        ChampionFactory factory;

        public Game(ChampionFactory factory)
        {
            this.factory = factory; 
        }

        public Champion SpoonChamp(string power)
        {
            return factory.CreateChamp(power);
        }
    }
    public interface Champion
    {
        public void Attack();
    }


    public class Assasin : Champion
    {
        string ability;

        public Assasin(string ability)
        {
            this.ability = ability;
        }

        public void Attack(string ability) {
        this.ability = ability;
        }

        public void Attack()
        {
            Console.WriteLine($"Attack - {ability}");
        }
    }

    public class Mech : Champion
    {
        string specialEffect;
        public Mech(string specialEffect)
        {
            this.specialEffect = specialEffect;
        }
        public void Attack()
        {
            Console.WriteLine($"Attack - {specialEffect}");
        }
    }

    public abstract class ChampionFactory
    {
        public abstract Champion CreateChamp(string power);
    }

    public class MechFyctory : ChampionFactory
    {
        public override Champion CreateChamp(string power)
        {
            return new Mech(power);
        }
    }

    public class AssasinFactory : ChampionFactory
    {
        public override Champion CreateChamp(string power)
        {
            return new Assasin(power);
        }
    }
}