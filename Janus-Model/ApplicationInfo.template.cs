﻿// Не исправлять ApplicationInfo.cs руками, файл генерируется автоматически
// Для изменения править ApplicationInfo.template.cs

using System;

using Rsdn.SmartApp;

namespace Rsdn.Janus
{
	public class ApplicationInfo
	{
		public const string ApplicationName = "RSDN@Home";
		public const string VersionString = "1.2.0.$WCREV$";
		public const string Release = "alpha 5";
		public const string Company = "RSDN Team";
		public const string Copyright = "Copyright © by RSDN Team (http://rsdn.ru), 2002-2011";

		public const string ResourcesNamespace = "Rsdn.Janus.Resources.";
		
		public const string MachineConfigFolder = "Janus";
		public const string AppDataFolder = "Janus";

		public static readonly Version Version = new Version(VersionString);

		public static string FullVersion
		{
			get
			{
				return
					"{0}.{1}.{2} {3} {4} {5}"
						.FormatStr(
							Version.Major,
							Version.Minor,
							Version.Build,
							Release,
							Resources.Revision,
							Version.Revision);
			}
		}

		public static string NameWithVersion
		{
			get { return ApplicationName + " " + Resources.Version.ToLower() + " " + FullVersion; }
		}

		public static string NameWithVersionAndCopyright
		{
			get { return NameWithVersion + ", " + Copyright; }
		}
	}
}