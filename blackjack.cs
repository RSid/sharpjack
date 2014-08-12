using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class Card {
    public string suit { get; private set; }
    public int rank { get; private set; }

    public Card(string suit, int rank)
      {
       this.suit = suit;
       this.rank = rank;
      }
  }

public class Hand {
    public List<Card> hand;

    public Hand()
      {
       this.hand = new List<Card>();
      }

    public void AddCards(List<Card> cards)
      {
        foreach (Card card in cards) {
          this.hand.Add(card);
        }
      }

    public void DisplayHand()
      {
        foreach (Card card in this.hand) {
           Console.WriteLine(card.suit + card.rank);
         }
      }

    public int Score() {
      int sum=0;
      for (int i=0; i<this.hand.Count; i++) {
        sum += this.hand[i].rank;
      }
      return sum;
    }
  }

public class Deck {
  public List<Card> deck = new List<Card>();

  public IEnumerable<int> ranks = Enumerable.Range(1, 10);
  public string[] suits = new string[]
               {"H","S","C","D"};

  public Deck()
    {
      foreach (string suit in suits) {
          foreach (int rank in ranks) {
            deck.Add(new Card(suit, rank));
          }
        }
    }

  public void DealCard(Hand hand)
    {
      Random random = new Random();
      int index = random.Next(0,40);
      List<Card> additions = new List<Card>();
      additions.Add(this.deck[index]);
      hand.AddCards(additions);
      this.deck.RemoveAt(index);
    }

  public void DealHand(Hand hand)
    {
      for(int i=0; i<2; i++ ) {
        this.DealCard(hand);
      }
    }
 }

public class GameLogic {
  public void CompareScores (int PlayerScore, int DealerScore) {
    if (PlayerScore > 21 || DealerScore > 21) {
      string loser = PlayerScore>21 ? "You" : "Dealer";
      Console.WriteLine("{0} went bust! Cry moar.", loser );
    } else {
      Console.WriteLine("fooobaaaar");
    }
  }
}


public class Blackjack {
  static public void Main ()
  {
    GameLogic gamelogic = new GameLogic();
    string gamestate = "new";

    while (gamestate != "over") {
      Deck deck1 = new Deck();
      string action;

      if (gamestate == "new") {
        Console.WriteLine("New game!");

        gamestate = "playing";

      } else if (gamestate == "playing") {

        Hand playerHand = new Hand();
        Hand dealerHand = new Hand();

        deck1.DealHand(playerHand);
        deck1.DealHand(dealerHand);

        Console.WriteLine("You were dealt: ");
        playerHand.DisplayHand();

        action = Console.ReadLine();

        if (action == "H") {
          deck1.DealCard(playerHand);
          Console.WriteLine("Your hand is: ");
          playerHand.DisplayHand();
          Console.WriteLine("Your score is: ");
          Console.WriteLine(playerHand.Score());
          GameLogic.CompareScores(playerHand.Score(),dealerHand.Score());
        }

        gamestate = "over";
      }
    }
  }
}
