using Blackjack;

public class Card
{
    private string face;
    private string suit;

    public Card(string cardFace, string cardSuit)
    {
        face = cardFace;
        suit = cardSuit;
    }

    public string GetLocalizedFace(Translations translations)
    {
        return translations.Get(face); // Fetch localized face name
    }

    public string GetLocalizedSuit(Translations translations)
    {
        return translations.Get(suit); // Fetch localized suit name
    }

    // Override ToString to display the card in a localized readable format
    public string ToString(Translations translations)
    {
        return $"{GetLocalizedFace(translations)} {GetLocalizedSuit(translations)}";
    }


    public int PointValue
    {
        get
        {
            switch (face)
            {
                case "Ace":
                    return 11; // Default value for Ace is 11
                case "King":
                case "Queen":
                case "Jack":
                    return 10; // Face cards are worth 10
                default:
                    return int.Parse(face); // Number cards return their numeric value
            }
        }
    }
}
