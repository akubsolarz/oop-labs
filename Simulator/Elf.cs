namespace Simulator;

public class Elf : Creature
{
    private int _singcount = 0;
    private int _agility;
    public int Agility
    {
        get => _agility;
        private set => _agility = Validator.Limiter(value, 0, 10);
    }
    public void Sing()
    {
        _singcount++;

        if (_singcount % 3 == 0)
        {
            Agility++;
        }
    }

    public override int Power => 8 * Level + 2 * Agility;

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }

    public override string Greating() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}";

    public override string ToString()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}";
    }

    public override string Info => $" {Name} [{Level}][{Agility}]";
}