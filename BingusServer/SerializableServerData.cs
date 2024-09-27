using Neto.Server;
using System.Collections.Concurrent;

namespace BingusServer
{
    public record SerializableServerData(ConcurrentDictionary<string, ServerRoom> Rooms, ConcurrentDictionary<string, ClientIdentity> Identities);
}
