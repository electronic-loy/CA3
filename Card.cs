using System;

namespace Blackjack

public class Card
{
	public Class1()
	{
        //I have inspired this code from https://dotnetfiddle.net/Xuj7b6


        public enum Suites
    {
        Hearts = 0,
        Diamonds,
        Clubs,
        Spades
    }

    public int Value
    {
        get;
        set;
    }

    public Suites Suite
    {
        get;
        set;
    }

    //Used to get full name, also usefull 
    //if you want to just get the named value
    public string NamedValue
    {
        get
        {
            string name = string.Empty;
            switch (Value)
            {
                case (14):
                    name = "Ace";
                    break;
                case (13):
                    name = "King";
                    break;
                case (12):
                    name = "Queen";
                    break;
                case (11):
                    name = "Jack";
                    break;
                default:
                    name = Value.ToString();
                    break;
            }

            return name;
        }
    }

    public string Name
    {
        get
        {
            return NamedValue + " of  " + Suite.ToString();
        }
    }

    public Card(int Value, Suites Suite)
    {
        this.Value = Value;
        this.Suite = Suite;
    }
}

	}
}
