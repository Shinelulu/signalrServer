using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeCommunicationServer.Hubs
{
    public class Members
    {
		private static Dictionary<string,string> allMembers;

		public static void AddMember(string user, string id)
		{
			if (allMembers.ContainsKey(user))
				return;
			allMembers.Add(user, id);
		}

		public static string GetMember(string user)
		{
			if (allMembers.ContainsKey(user))
				return allMembers[user];
			else
				return null;
		}
	}
}
