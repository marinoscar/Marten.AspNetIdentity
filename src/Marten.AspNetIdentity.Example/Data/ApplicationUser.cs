using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marten.AspNetIdentity.Example.Data
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser, IClaimsUser
	{
		private List<byte[]> _claims = new List<byte[]>();

		// This is for the Json.net serializer, it can't serialize ILists
		public List<byte[]> Claims => _claims;

		// Hide the interface's version from Json.Net or it gets confused
		IList<byte[]> IClaimsUser.Claims
		{
			get
			{
				return _claims;
			}
			set
			{
				_claims = new List<byte[]>(value);
			}
		}
	}
}