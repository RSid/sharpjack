using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
 
public class Card
{
    public string suit { get; private set; }
    public int rank { get; private set; }
 
    public Card(string suit, int rank)
    {
         this.suit = suit;
         this.rank = rank;
    }
}
 
public class Hand
{
    public Card [] hand = new Card [2];
 
    public Hand(Card card1, Card card2)
    {
         this.hand[0] = card1;
         this.hand[1] = card2;
    }
}
 
public class Deck
 {
  public IList<Card> deck = new List<Card>();
 
  public IEnumerable<int> ranks = Enumerable.Range(1, 10);
  public string[] suits = new string[]
               {"H","S","C","D"};
 
  public Deck()
    {
      foreach (string suit in suits)
      {
        foreach (int rank in ranks) {
          deck.Add(new Card(suit, rank));
        }
      }
    }
 }
 
 
public class Blackjack
{
  static public void Main ()
  {
     Deck deck1 = new Deck();
 
     foreach (Card card in deck1.deck)
     {
       Console.WriteLine(card.suit + card.rank);
     }
  }
}
