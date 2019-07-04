using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_VS
{
    
    class Field
    {
        private int numOfPlayers { get; set; }
        List<Player> playersList = new List<Player>();
        Deck deck = new Deck();
        Rule rule= new Rule();
        bool isGameOver = false;
        Card card;
        Card currentCard;

        public Field(int numOfPlayers)
        {
            this.numOfPlayers = numOfPlayers;
            CreatePlayers();
            Deal();
            Testing();
            //ShowCurrentCard();
            //Game();
            //deck.printCards();
            //deck.getSize();
        }
        private void CreatePlayers()
        {

            for (int i = 1; i <= numOfPlayers; i++)
            {
                Player player = new Player(i);
                playersList.Add(player);
            }
        }
        private void Deal()
        {
            List<Card> disperseList = deck.DisperseCards(playersList.Count);
            for (int i = 0; i < playersList.Count; i++)
            {
                for (int j = 6; j >= 0; j--)
                {
                    card = disperseList.ElementAt(j);
                    playersList.ElementAt(i).AddCard(card);
                    disperseList.Remove(card);
                }
            }
            currentCard = deck.FirstCard();
        }

        private void Game()
        {
            foreach (var player in playersList)
            {
                //DisplayField();
                //player.DisplayHand();
                if (rule.CanMakeValidMove(player.GetPlayerCard(), currentCard))
                {
                    //DisplayField();
                    //player.DisplayHand();
                    //Debug.WriteLine("NO2");

                }
                //else
                //    Console.WriteLine("YES");

            }
            //rule.FlushLog();

        }

        private void DisplayField()
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("\n\n");
            ShowCurrentCard();
            Console.WriteLine("\n\n");
            Console.WriteLine("---------------------------------------------------------------------");


        }

        private void ShowCurrentCard()
        {
            Console.WriteLine("Color: " + currentCard.GetColor() + " " + "Value: " + currentCard.GetValue());
        }
        private void SetCurrentCard()
        {
            //currentCard = 
        }
        private void Testing()
        {
            rule.compareCard();
        }
        private void DebugCode()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            Trace.Unindent();
        }



      

       




    }
}
