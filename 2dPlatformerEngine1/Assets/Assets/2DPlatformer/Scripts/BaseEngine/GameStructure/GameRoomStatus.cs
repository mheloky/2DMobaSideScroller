using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPIPGame.Server.DomainObjects;

namespace Assets._2DPlatformer.Scripts.BaseEngine.GameStructure
{
    public static class GameRoomStatus
    {
        static Dictionary<int, APlayer> ThePlayers = new Dictionary<int, APlayer>();
        static int ClientID
        {
            get;
            set;
        }
        
        public static void AddPlayer(APlayer thePlayer)
        {
            lock(ThePlayers)
            { 
                ThePlayers.Add(thePlayer.GetClientID(), thePlayer);
            }
        }

        public static APlayer GetPlayer(int clientID)
        {
            return ThePlayers[clientID];
        }

        public static List<APlayer> GetPlayers()
        {
            return ThePlayers.Values.ToList();
        }
    }
}
