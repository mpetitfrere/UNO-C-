using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_VS
{
    public class Rule
    {
        private List<Card> cardList { get; set; } = new List<Card>();
        Card currentCard { get; set; }
        Card playerCard;
        Log log = new Log();
        TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
            new TextWriterTraceListener(Environment.CurrentDirectory +"Illegal Move.txt"),
            new TextWriterTraceListener(Console.Out)
            };

        public Rule()
        {
            Debug.Listeners.AddRange(listeners);
        }

        public bool CanMakeValidMove(List<Card> cardList, Card currentCard)
        {
            this.cardList = cardList;
            this.currentCard = currentCard;
            if (isSameColor() || isSameNumber() || isSameType() || HasDraw4Card() || HasWildCard()
                || IsCurrentCardDraw4Card() || IsCurrentCardWildCard())
            {
                return true;
            }
            else
            {
                LogIllegalMove();
                return false;

            }


        }

        private void ScanHand()
        {

        }

        public bool isSameColor()
        {
            foreach (var item in cardList)
            {
                WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name,item);
                if (item.GetColor().Equals(currentCard.GetColor()))
                {
                    return true;
                }
            }
            return false;

        }
        public bool isSameNumber()
        {
            foreach (var item in cardList)
            {
                WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name, item);
                if ((int)Card.Types.Number == item.GetCardType() && (int)Card.Types.Number == currentCard.GetCardType())
                {
                    if ((Convert.ToInt16(currentCard.GetValue()) == Convert.ToInt16(item.GetValue())))
                    {
                        return true;
                    }
                }

            }

            return false;

        }

        public bool isSameType()
        {
            foreach (var item in cardList)
            {
                WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name, item);
                if ((currentCard.GetCardType() == item.GetCardType()))
                {
                    if (item.GetValue().Equals(currentCard.GetValue()))
                    {
                        return true;
                    }
                }

            }
            return false;

        }

        public bool HasWildCard()
        {
            foreach (var item in cardList)
            {
                WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name, item);

                if ((int)Card.Types.WildCard == item.GetCardType())
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasDraw4Card()
        {
            foreach (var item in cardList)
            {
                WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name, item);
                if ((int)Card.Types.WildDraw4 == item.GetCardType())
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCurrentCardWildCard()
        {
            //WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name, item);
            if ((int)Card.Types.WildCard == currentCard.GetCardType())
            {
                return true;
            }
            else
                return false;

        }
        public bool IsCurrentCardDraw4Card()
        {
           // WriteToLog(System.Reflection.MethodBase.GetCurrentMethod().Name, item);
            if ((int)Card.Types.WildDraw4 == currentCard.GetCardType())
            {
                return true;
            }
            else
                return false;

        }

        public void WriteToLog(string methodName, Card item)
        {
            log.LogValidMoves(methodName,currentCard, item);
        }

        public void LogIllegalMove()
        {
            if((int)Card.Types.ActionCard == currentCard.GetCardType())
                log.LogInvalidMove(currentCard, cardList);
        }

        public void FlushLog()
        {
            for (int i = 0; i < listeners.Length; i++)
            {
                listeners[i].Flush();
            }
        }
        public bool compareCard()
        {
            Card card = new Card("RED", "Wild Draw 4", 3);
            cardList.Add(card);
            card = new Card("Blue", "Wild Card", 4);
            currentCard = card;
            if (isSameColor() || isSameNumber() || isSameType() || HasDraw4Card() || HasWildCard()
                || IsCurrentCardDraw4Card() || IsCurrentCardWildCard())
            {
                return true;
            }
            else
            {
                LogIllegalMove();
                return false;

            }

        }
    }
}
