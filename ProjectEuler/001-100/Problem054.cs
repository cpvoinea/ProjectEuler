using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ProjectEuler
{
    class Problem054 : IProblem
    {
        enum HandType
        {
            Nothing = 1,
            OnePair = 2,
            TwoPair = 5,
            ThreeOfAKind = 10,
            Straight = 15,
            Flush = 20,
            FullHouse = 25,
            FourOfAKind = 50,
            StraightFlush = 75,
            RoyalFlush = 100
        }

        struct Card
        {
            public Card(char value, char suit)
            {
                switch (value)
                {
                    case 'T':
                        Value = 10;
                        break;
                    case 'J':
                        Value = 11;
                        break;
                    case 'Q':
                        Value = 12;
                        break;
                    case 'K':
                        Value = 13;
                        break;
                    case 'A':
                        Value = 14;
                        break;
                    default:
                        Value = value - 48;
                        break;
                }

                switch (suit)
                {
                    case 'H':
                        Suit = 0;
                        break;
                    case 'C':
                        Suit = 1;
                        break;
                    case 'S':
                        Suit = 2;
                        break;
                    case 'D':
                        Suit = 3;
                        break;
                    default:
                        Suit = -1;
                        break;
                }
            }

            public int Value;
            public int Suit;
        }

        class Hand
        {
            public List<Card> Cards = new List<Card>();
            int highestCard = 0;
            int lowCard = 15;
            int[] count = new int[15];
            int[] suit = new int[4];
            int maxCount = 0;
            public int MaxCard = 0;

            public void AddCard(Card c)
            {
                if (c.Value > highestCard)
                    highestCard = c.Value;
                if (c.Value < lowCard)
                    lowCard = c.Value;
                count[c.Value]++;
                suit[c.Suit]++;

                int cv = count[c.Value];
                if (cv > maxCount)
                {
                    maxCount = cv;
                    MaxCard = c.Value;
                }

                Cards.Add(c);
            }

            public int SecondCard
            {
                get
                {
                    int max = 0;
                    int card = 0;
                    for (int i = 2; i < 15; i++)
                        if (i != MaxCard && count[i] > max)
                        {
                            max = count[i];
                            card = i;
                        }
                    return card;
                }
            }

            int SecondCount
            {
                get
                {
                    return count[SecondCard];
                }
            }

            bool IsFlush
            {
                get
                {
                    for (int i = 0; i < 4; i++)
                        if (suit[i] == 5)
                            return true;
                    return false;
                }
            }

            bool IsStraight
            {
                get
                {
                    for (int i = lowCard; i <= highestCard; i++)
                        if (count[i] != 1)
                            return false;
                    return highestCard - lowCard == 4;
                }
            }

            bool IsStraightFlush
            {
                get
                {
                    return IsStraight && IsFlush;
                }
            }

            bool IsRoyalFlush
            {
                get
                {
                    return IsStraightFlush && highestCard == 14;
                }
            }

            public int HighCard
            {
                get
                {
                    for (int i = 14; i > 1; i--)
                        if (count[i] == 1)
                            return i;
                    return 0;
                }
            }

            public HandType Type
            {
                get
                {
                    if (IsRoyalFlush)
                        return HandType.RoyalFlush;
                    if (IsStraightFlush)
                        return HandType.StraightFlush;
                    if (maxCount == 4)
                        return HandType.FourOfAKind;
                    if (maxCount == 3 && SecondCount == 2)
                        return HandType.FullHouse;
                    if (IsFlush)
                        return HandType.Flush;
                    if (IsStraight)
                        return HandType.Straight;
                    if (maxCount == 3)
                        return HandType.ThreeOfAKind;
                    if (maxCount == 2 && SecondCount == 2)
                        return HandType.TwoPair;
                    if (maxCount == 2)
                        return HandType.OnePair;
                    return HandType.Nothing;
                }
            }

            public override string ToString()
            {
                string result = "";
                foreach (Card c in Cards)
                    result += c.Value + "-" + c.Suit + " ";
                return result;
            }
        }

        bool Check(Card[] cards)
        {
            Hand player1 = new Hand();
            Hand player2 = new Hand();
            for (int i = 0; i < 10; i++)
                if (i < 5)
                    player1.AddCard(cards[i]);
                else
                    player2.AddCard(cards[i]);
            if (player1.Type != player2.Type)
                return (int)player1.Type > (int)player2.Type;

            if (player1.Type == HandType.RoyalFlush)
                return true;
            if (player1.Type == HandType.StraightFlush || player1.Type == HandType.Flush || player1.Type == HandType.Straight || player1.Type == HandType.Nothing)
            {
                if (player1.HighCard > player2.HighCard)
                    return true;
                if (player1.HighCard == player2.HighCard)
                    return true;
                return false;
            }
            if (player1.Type == HandType.ThreeOfAKind || player1.Type == HandType.OnePair)
            {
                if (player1.MaxCard > player2.MaxCard)
                    return true;
                if (player1.MaxCard == player2.MaxCard)
                {
                    if (player1.HighCard > player2.HighCard)
                        return true;
                    if (player1.HighCard == player2.HighCard)
                        return true;
                    return false;
                }
                return false;
            }
            if (player1.Type == HandType.FourOfAKind || player1.Type == HandType.FullHouse || player1.Type == HandType.TwoPair)
            {
                if (player1.MaxCard > player2.MaxCard)
                    return true;
                if (player1.MaxCard == player2.MaxCard)
                {
                    if (player1.SecondCard > player2.SecondCard)
                        return true;
                    if (player1.SecondCard == player2.SecondCard)
                    {
                        if (player1.HighCard > player2.HighCard)
                            return true;
                        if (player1.HighCard == player2.HighCard)
                            return true;
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        public string GetResult()
        {
            using (StreamReader sr = new StreamReader("Resources\\Problem054.txt"))
            {
                int count = 0;
                while (!sr.EndOfStream)
                {
                    var cards = sr.ReadLine().Split().Select(s => new Card(s[0], s[1]));
                    count += Check(cards.ToArray()) ? 1 : 0;
                }

                return count.ToString();
            }
        }
    }
}
