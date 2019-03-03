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
        public static int ClientID
        {
            get;
            set;
        }
        public static NetworkManager TheNetworkManager
        {
            get;
            set;
        }
        static Dictionary<int, ANetworkPlayer> ClientIDToPlayersSouls = new Dictionary<int, ANetworkPlayer>();
        static Dictionary<int, Player> ClientIDToPlayersPhysicalBodies = new Dictionary<int, Player>();
        
        public static void AddPlayerSoul(ANetworkPlayer thePlayer)
        {
            lock (ClientIDToPlayersSouls)
            {
                ClientIDToPlayersSouls.Add(thePlayer.GetClientID(), thePlayer);
            }
        }

        public static ANetworkPlayer GetPlayerSoul(int clientID)
        {
            return ClientIDToPlayersSouls[clientID];
        }

        public static List<ANetworkPlayer> GetPlayersSouls()
        {
            return ClientIDToPlayersSouls.Values.ToList();
        }

        public static void AddPhysicalPlayer(int clientID, Player thePlayer)
        {
            lock (ClientIDToPlayersPhysicalBodies)
            {
                ClientIDToPlayersPhysicalBodies.Add(clientID, thePlayer);
            }
        }

        public static Player GetPhysicalPlayer(int clientID)
        {
            return ClientIDToPlayersPhysicalBodies[clientID];
        }

        public static List<Player> GetPhysicalPlayers()
        {
            return ClientIDToPlayersPhysicalBodies.Values.ToList();
        }

        public static Player GetThisMainPlayer()
        {
            return GetPhysicalPlayer(ClientID);
        }
    }
}
