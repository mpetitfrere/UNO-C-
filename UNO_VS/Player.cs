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

    }
}
