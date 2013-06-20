using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudentPortal
{
	public class CustomRoleProvider : RoleProvider
	{

		DHHHContext db = new DHHHContext();

		public override string[] GetRolesForUser(string username)
		{
			var user = db.UserProfiles.First(t => t.UserName == username);
			if (user != null)
			{
				var roles = db.webpages_Groups_Roles.Where(t => t.GroupId == user.GroupId).Join(db.webpages_Roles,gr=>gr.RoleId,r=>r.RoleId,(gr,r)=>new{r.RoleName}).ToList();
				var list = new List<string>();
				foreach (var r in roles)
				{
					list.Add(r.RoleName);
				}
				return list.ToArray();
			}
			string[] str=new string[]{};
			return str;
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			throw new NotImplementedException();
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}