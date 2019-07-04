using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_VS
{
    public class Card
    {
        private string color;
        private string value;
        private int cardType;
        public enum Types
        {
            Number = 1,
            ActionCard =2,
            WildCard =3,
            WildDraw4 =4

        }
        public Card(string color, string value,  int type)
        {
            this.color = color;
            this.value = value;
            this.cardType = type;

        }

        public string GetColor()
        {
            return this.color;
        }

        public string GetValue()
        {
            return this.value;
        }

        public int GetCardType()
        {
            return this.cardType;
        }
        private void setCardType(string type)
        {
           // Types.ActionCard = "c";
        }
        public override string ToString()
        {
            return String.Format("Color:{0},     Value:{1},", color, value);
        }
    }
}
