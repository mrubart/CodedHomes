using System;

namespace CodedHomes.Models
{
	public class OAuthMembership
	{
		public string Provider { get; set; }
		public string ProviderUserId { get; set; }
		public int UserId { get; set; }
	}
}
