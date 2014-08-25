using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace MashBesh
{
    public struct clientInfo
    {
        public Socket socket;
        public string name;
    }

    public enum Comand
    {
        ChoosePlayer,
        DicesPoints,
        Error,
        Login,      
        Logout,
        Message,
        Move,
        MoveAndNext,
        MoveAndKill,
        MoveAndKillAndNext,
        NextPlayersStep,  
        Null,        
        Play,
        PlayersState,
        Ready,
        RollADice,
        ServerOff,
        ShowPath
    }

    public class Data
    {
        public Comand comand;
        public string message;
        public string sendersName;
        public int sendersNumber;

        public Data()
        {
            comand = Comand.Null;
            message = null;
            sendersName = null;
            sendersNumber = 0;
        }

        public Data(byte[] data)
        {
            try
            {
                string[] recievdeData = Encoding.Unicode.GetString(data).Split('¿');
                int temporaryComand;
                if (Int32.TryParse(recievdeData[0], out temporaryComand))
                {
                    comand = (Comand)temporaryComand;
                }
                else
                {
                    comand = Comand.Error;
                }
                if (recievdeData[1] != null)
                {
                    sendersName = recievdeData[1];
                }
                else
                {
                    sendersName = null;
                }
                sendersNumber = Convert.ToInt32(recievdeData[2]);
                if (recievdeData[3] != null)
                {
                    message = recievdeData[3];
                }
                else
                {
                    message = null;
                }
            }
            catch
            {
                comand = Comand.Error;
                sendersName = "Server";
                sendersNumber = 0;
            }
        }

        public byte[] ToBytes()
        {
            string returnedMessage;
            returnedMessage = null;
            returnedMessage = Convert.ToString((int)comand) + "¿";
            if (sendersName != null) { returnedMessage += sendersName; }
            else { returnedMessage += null; }
            returnedMessage += "¿";
            returnedMessage += Convert.ToString(sendersNumber) + "¿";
            if (message != null) { returnedMessage += message; }
            else { returnedMessage += null; }
            returnedMessage += "¿";
            return Encoding.Unicode.GetBytes(returnedMessage);
        }
    }
}
