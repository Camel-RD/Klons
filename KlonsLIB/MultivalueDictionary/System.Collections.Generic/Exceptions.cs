using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
namespace System.Collections.Generic
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Exceptions
	{
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Exceptions.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("System.Collections.Generic.Exceptions", typeof(Exceptions).Assembly);
					Exceptions.resourceMan = resourceManager;
				}
				return Exceptions.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Exceptions.resourceCulture;
			}
			set
			{
				Exceptions.resourceCulture = value;
			}
		}
		internal static string CopyTo_ArgumentsTooSmall
		{
			get
			{
				return Exceptions.ResourceManager.GetString("CopyTo_ArgumentsTooSmall", Exceptions.resourceCulture);
			}
		}
		internal static string Create_TValueCollectionReadOnly
		{
			get
			{
				return Exceptions.ResourceManager.GetString("Create_TValueCollectionReadOnly", Exceptions.resourceCulture);
			}
		}
		internal static string Enumerator_AfterCurrent
		{
			get
			{
				return Exceptions.ResourceManager.GetString("Enumerator_AfterCurrent", Exceptions.resourceCulture);
			}
		}
		internal static string Enumerator_BeforeCurrent
		{
			get
			{
				return Exceptions.ResourceManager.GetString("Enumerator_BeforeCurrent", Exceptions.resourceCulture);
			}
		}
		internal static string Enumerator_Modification
		{
			get
			{
				return Exceptions.ResourceManager.GetString("Enumerator_Modification", Exceptions.resourceCulture);
			}
		}
		internal static string KeyNotFound
		{
			get
			{
				return Exceptions.ResourceManager.GetString("KeyNotFound", Exceptions.resourceCulture);
			}
		}
		internal static string ReadOnly_Modification
		{
			get
			{
				return Exceptions.ResourceManager.GetString("ReadOnly_Modification", Exceptions.resourceCulture);
			}
		}
		internal Exceptions()
		{
		}
	}
}
