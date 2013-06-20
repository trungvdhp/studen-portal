using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Models;
using System.Reflection;
using System.ComponentModel;

namespace StudentPortal.Lib
{
	public class GlobalLib
	{
		#region Controller
		/// <summary>
		/// Get sub classes
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private static List<Type> GetSubClasses<T>()
		{
			return AppDomain
				.CurrentDomain
				.GetAssemblies()
				.SelectMany(
					a => a.GetTypes().Where(type => type.IsSubclassOf(typeof(T)))
				).ToList();
		}

		/// <summary>
		/// Get controller names
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<string> GetControllerNames()
		{
			return GetSubClasses<Controller>().Select(t => t.Name);
		}

		/// <summary>
		/// Get list method
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<webpages_Roles> GetControllerActionMethods()
		{
			List<Type> controllers = GetSubClasses<Controller>();
			List<webpages_Roles> methods = new List<webpages_Roles>();

			foreach (Type item in controllers)
			{
				MethodInfo[] list = item.GetMethods();
				string controllername = item.Name.Substring(0, item.Name.Length - "Controller".Length);

				foreach (MethodInfo m in list)
				{
					if (m.IsPublic)
					{
						if (typeof(ActionResult).IsAssignableFrom(m.ReturnParameter.ParameterType) ||
							typeof(JsonResult).IsAssignableFrom(m.ReturnParameter.ParameterType))
						{
							AuthorizeAttribute authorize = (AuthorizeAttribute)m.GetCustomAttribute(typeof(AuthorizeAttribute), false);
							DescriptionAttribute description = (DescriptionAttribute)m.GetCustomAttribute(typeof(DescriptionAttribute));

							string action_name = controllername + "." + m.Name;

							if (authorize != null && authorize.Roles == action_name && !methods.Any(a => a.RoleName == action_name))
							{
								methods.Add(new webpages_Roles
								{
									DisplayName = description == null ? action_name : description.Description,
									RoleName = action_name
								});
							}
						}
					}
				}
			}

			return methods;
		}
		#endregion
	}
}