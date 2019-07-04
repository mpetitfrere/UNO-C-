using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace UNO_VS
{
    class Log
    {
        //string methodLogFile = "Method Log";
         public string GetTempPath()
        {
            string path = Environment.CurrentDirectory;
            if (!path.EndsWith("\\")) path += "\\";
            return path;
        }

        public void LogMessageToFile(string msg)
        {
            System.IO.StreamWriter sw = System.IO.File.AppendText(
                GetTempPath() + "My Log File.txt");
            try
            {
                string logLine = System.String.Format(
                    "{0:G}\n {1}", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
        public void LogMessageToFile(string msg, string fileName)
        {
            System.IO.StreamWriter sw = System.IO.File.AppendText(
                GetTempPath() + fileName+".txt");
            try
            {
                string logLine = System.String.Format(
                    "{0:G}: {1}", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }

        public void LogValidMoves(string methodName, Card currentCard, Card playerCard)
        {
            string methodLogFile = "Method Log";
            string methodNameHeader = "\nMethod Name: " + methodName;
            string currentCardMsg = "\nCurrent Card Color: " + currentCard.GetColor() + " Current Card Value: " + currentCard.GetValue();
            string playerCardMsg = "\nPlayer Card Color: " + playerCard.GetColor()    + " Current Card Value: " + playerCard.GetValue();
            string completeMessage = methodNameHeader + currentCardMsg + playerCardMsg + "\n";
            LogMessageToFile(completeMessage, methodLogFile);

        }
        public void LogInvalidMove(Card currentCard, List<Card> cardList)
        {
            string fileName = "illegalMove";
            string msg1 = "Current Card: " + currentCard.ToString();
            string msg2 = "\n";
            //Debug.WriteLine("Current Card: " + currentCard.ToString());
            foreach (var item in cardList)
            {
                msg2 = msg2 + "Player Card: " + item.ToString() + "\n";

            }
            string msg3 = msg1 + "\n" + msg2;
            LogMessageToFile(msg3, fileName);
        }

        
    }
}
