using System;
using System.Collections.Generic;
using System.Linq;


namespace PL
{
    public class ScoutingService
    {
        private List<Player> players = new List<Player>();

        public IEnumerable<Player> GetPlayers() => players;

        public void AddPlayer(Player player)
        {
            player.Id = players.Any() ? players.Max(p => p.Id) + 1 : 1;
            players.Add(player);
        }

        public void DeletePlayer(int playerId)
        {
            var playerToDelete = players.FirstOrDefault(p => p.Id == playerId);
            if (playerToDelete != null)
                players.Remove(playerToDelete);
        }

        public void UpdateGoalsScored(int playerId, int goals)
        {
            var player = players.FirstOrDefault(p => p.Id == playerId);
            if (player != null)
                player.GoalsScored += goals;
        }

        public void UpdateAssists(int playerId, int assists)
        {
            var player = players.FirstOrDefault(p => p.Id == playerId);
            if (player != null)
                player.Assists += assists;
        }

    }

}
