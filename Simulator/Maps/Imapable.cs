using System.Text.Json.Serialization;

namespace Simulator.Maps;
[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
[JsonDerivedType(typeof(Animals), nameof(Animals))]
[JsonDerivedType(typeof(Birds), nameof(Birds))]
public interface Imapable
{
    Point Position { get; }
    Map? Map { get; }
    char MapSymbol { get; }

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point startingPosition);
    string ToString();
}
