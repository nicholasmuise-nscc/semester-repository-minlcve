public class Card
{
    public string Suit { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}
