using System.Text.Json.Serialization;

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
    public override char MapSymbol => 'E';


    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
        CalculatePower = () => 8 * Level + 2 * Agility;
    }

    public Elf() : this("Elf") { }

    public override string Greating() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}";

    public override string ToString()
    => $"{GetType().Name.ToUpper()}: {Info}";
    [JsonIgnore]
    public override string Info => $"{Name} [{Level}][{Agility}]";
}