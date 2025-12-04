namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public Birds() { }

    public Birds(string description, uint size, bool canFly = true)
    {
        Description = description;
        Size = size;
        CanFly = canFly;
    }

    public override string Info
    {
        get 
        {
            string fly = CanFly ? "fly+" : "fly-";
            return $"{Description} ({fly}) <{Size}>";
        }

    }
}
