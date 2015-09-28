using System;
using System.ComponentModel;

namespace Skeleton.Client.Core
{
	public abstract class ViewModel : ObservableObject, IDataErrorInfo
	{
		/// <summary>
		/// Gets the error message for the property with the given name.
		/// </summary>
		/// <returns>
		/// The error message for the property. The default is an empty string ("").
		/// </returns>
		/// <param name="columnName">The name of the property whose error message to get. </param>
		public string this[string columnName]
		{
			get { throw new System.NotImplementedException(); }
		}

		/// <summary>
		/// Gets an error message indicating what is wrong with this object.
		/// </summary>
		/// <returns>
		/// An error message indicating what is wrong with this object. The default is an empty string ("").
		/// </returns>
		[Obsolete]
		public string Error
		{
			get
			{
				throw new NotSupportedException();
			}
		}
	}
}