using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Hubs
{
    public class BaseHub<T> : Hub
    {
        private readonly Dictionary<T, HashSet<string>> _connections =
            new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get => _connections.Count;
        }

        protected T GetUserByConnection(string connectionId)
            => _connections.FirstOrDefault(x => x.Value.Contains(connectionId)).Key;

        protected void Add(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;

                if (!_connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        protected IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;

            if (_connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        protected void Remove(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;

                if (!_connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }
}