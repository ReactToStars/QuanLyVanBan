using System;
using System.Linq;
using System.Security.Principal;

namespace QuanLyVanBan.Authentications
{
	public class CustomPrincipal : IPrincipal
	{
		private readonly CustomIdentity _identity;

		public CustomPrincipal(CustomIdentity identity)
		{
			_identity = identity ?? throw new ArgumentNullException(nameof(identity));
		}

		public IIdentity Identity => _identity;

        // Implement any custom role-based authorization logic here if needed
        public bool IsInRole(string role)
		{
			// Example: Check if the user has a specific role
			return role.Equals(_identity.Role, StringComparison.CurrentCultureIgnoreCase);
		}

		public bool IsInRole(params string[] role)
		{
			// Example: Check if the user has a specific role
			return role.Contains(_identity.Role);
		}
	}

}
