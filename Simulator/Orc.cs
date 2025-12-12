namespace Simulator;


public class Orc : Creature
{
    public int _huntcount = 0;
    public int _rage;
    public int Rage
    {
        get => _rage;
        set => _rage = Validator.Limiter(value, 0, 10);
    }
    public void Hunt()
    {
        _huntcount++;
        
        if (_huntcount % 2 == 0)
        {
            Rage++;
        }
    }
    public override char MapSymbol => 'O';
    public override int Power => 8 * Level + 2 * Rage;

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public Orc() { }

    public override string  Greating() => $"Hi, I'm {Name}, my level is {Level},  my rage is {Rage}";

    public override string ToString()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}";
    }
    public override string Info => $"{Name} [{Level}][{Rage}]";
}