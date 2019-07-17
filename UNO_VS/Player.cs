using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_VS
{
    class Player
    {
        List<Card> cardList = new List<Card>();
        int playerTurnOrder;
        public string playerName { get; set; }
        Rule rule = new Rule();
        public Player(int num)
        {
            this.playerTurnOrder = num;
            this.playerName = "P" + num;
        }
        public void DisplayHand()
        {
            Console.WriteLine(playerName + " Hand");

            foreach (var item in cardList)
            {
                Console.WriteLine((cardList.IndexOf(item)+1).ToString() + ": Color: " + item.GetColor() + " " + "Value: " + item.GetValue());
            }
            Console.WriteLine("---------------------------------------------------------\n");

        }
        public void AddCard(Card card)
        {
            cardList.Add(card);
        }
        public void SetPlayerTurn(int turnNum)
        {
            playerTurnOrder = turnNum;
        }
        public List<Card> GetPlayerCard()
        {
            return this.cardList;
        }
        public List<Card> Action(Card currentCard)
        {
            int choice;
            List<Card> playCardList = new List<Card>();

            Console.WriteLine("Player Options");
            Console.WriteLine("Enter 1 to play single card");
            Console.WriteLine("Enter 2 to play single card");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid number");
                Console.Write("Please try again");
            }
            if(choice == 1)
            {
                playCardList.Add(PlaySingleCard());
            }



            return playCardList;



        }

        public Card PlaySingleCard()
        {
            int cardChoice;
            DisplayHand();
            Console.WriteLine("Choose the numer to play card");
            cardChoice = Convert.ToInt16(Console.ReadLine());
            Card card = cardList.ElementAt(cardChoice-1);
            return card;
        }

    }
}
