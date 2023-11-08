using QuanLyVanBan.Models;
using System;
using System.Security.Principal;

namespace QuanLyVanBan.Authentications
{
	public class CustomIdentity : IIdentity
	{
		public CustomIdentity(CurrentUser currentUser)
		{
			if (currentUser == null)
			{
				throw new ArgumentNullException(nameof(currentUser));
			}

			// Map your properties to the identity properties as needed
			MaTK = currentUser.MaTK;
			TenTK = currentUser.TenTK;
			Name = currentUser.Ten; 
			Password = currentUser.MatKhau; 
			Role = currentUser.ChucVu;
			AuthenticationType = "CustomAuthentication"; // You can set a custom authentication type if needed
			IsAuthenticated = true; // Set to true if the user is authenticated, false otherwise
			IsSavedPassword = currentUser.IsSavedPassword; // Set to true if the user is authenticated, false otherwise
		}

		public string AuthenticationType { get; private set; }
		public bool IsAuthenticated { get; private set; }
		public string MaTK { get; private set; }
		public string TenTK { get; private set; }
		public string Name { get; private set; }
		public string Password { get; private set; }
		public string Role { get; private set; }
		public bool IsSavedPassword { get; private set; }
	}
}
