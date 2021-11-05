using System;
namespace Validation
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	internal sealed class ValidatedNotNullAttribute : Attribute
	{
	}
}
