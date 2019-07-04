using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_VS
{
    public class Deck
    {
        static int maxSize = 108; //76 Number cards, 24 Action cards and 8 Wild cards.
        //color contains 19 cards, one number 0 card and two sets of cards numbered 1-9.

        List<Card> cardList = new List<Card>();
        String[] colors = new string[] { "RED", "BLUE", "YELLOW", "GREEN" };
        String[] actionCards = new string[] {"+2", "REVERSE", "SKIP"};

        Card card;
        public Deck ()
        {
            SetupCards();
            ShuffleList();


        }

        public void SetupCards()
        {
            AddNumberCards();
            AddZeroCard();
            AddActionCard();
            AddWildCards();
        }

        private void ShuffleList()
        {
            List<Card> randomCardList = new List<Card>();
            Random r = new Random();
            int randomIndex = 0;
            while (cardList.Count > 0)
            {
                randomIndex = r.Next(0, cardList.Count); //Choose a random object in the list
                randomCardList.Add(cardList[randomIndex]); //add it to the new, random list
                cardList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            cardList = randomCardList;
        }
        public Card draw()
        {
            card = cardList.ElementAt(new Random().Next(0, maxSize));
            cardList.Remove(card);
            maxSize = maxSize - 1;
            return card;
        }
        public List<Card> draw(int num)
        {
            List<Card> drawList = new List<Card>();

            for (int i =0; i< num; i++)
            {
                card = cardList.ElementAt(new Random().Next(0, maxSize));
                cardList.Remove(card);
                maxSize = maxSize - 1;
                drawList.Add(card);
            }
            return drawList;
        }

        public List<Card> DisperseCards(int Players)
        {
            List<Card> dispserseList = new List<Card>();
            for (int i =0; i < 7 * Players; i++)
            {
                card = cardList.ElementAt(i);
                cardList.Remove(card);
                dispserseList.Add(card);
            }
            return dispserseList;
        }

        public Card FirstCard()
        {
              return cardList.ElementAt(new Random().Next(0, cardList.Count));
        }
     

      
        public void AddNumberCards()
        {
            List<Card> numCardist = new List<Card>();

            for (int i = 0; i < colors.Count(); i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    card = new Card(colors[i],j.ToString(),1);
                    numCardist.Add(card);
                }
            }
            cardList.AddRange(numCardist);
            cardList.AddRange(numCardist);
        }
        public void AddZeroCard()
        {
            for (int i = 0; i < 4; i++)
            {
                card = new Card(colors[i], "0", 1);
                cardList.Add(card);
            }
         
        }

        private void AddActionCard()
        {
            List<Card> actionCardList = new List<Card>();

            for (int i = 0; i < actionCards.Count(); i++)
            {
                for (int j = 0; j < colors.Count(); j++)
                {
                    card = new Card(colors[j],actionCards[i],2);
                    actionCardList.Add(card);
                }
            }
            cardList.AddRange(actionCardList);
            cardList.AddRange(actionCardList);

        }

        private void AddWildCards()
        {
            for (int i = 0; i <4; i++)
            {
                card = new Card("Black", "Wild Draw 4", 3);
                cardList.Add(card);
            }

            for (int i = 0; i < 4; i++)
            {
                card = new Card("Black", "Wild Card", 4);
                cardList.Add(card);
            }
        }
     

        public void PrintCards()
        {
            foreach (var item in cardList)
            {
                Console.WriteLine("Color: " + item.GetColor()+ " " + "Value: " + item.GetValue());
            }
        }

        public void PrintCardListCount()
        {
            Console.WriteLine(cardList.Count);
        }



    }
}
