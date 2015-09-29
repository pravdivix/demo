using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Skeleton.Client.Core
{
	public abstract class ViewModel : ObservableObject, IDataErrorInfo
	{
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

		/// <summary>
		/// Gets the error message for the property with the given name.
		/// </summary>
		/// <returns>
		/// The error message for the property. The default is an empty string ("").
		/// </returns>
		/// <param name="columnName">The name of the property whose error message to get. </param>
		public string this[string columnName]
		{
			get
			{
				return Validate(columnName);
			}
		}

		/// <summary>
		/// Validates a property whose name matches the specified <see cref="propertyName"/>.
		/// </summary>
		/// <param name="propertyName">The name of the property to validate.</param>
		/// <returns>Returns a validation error, if any, otherwise returns null.</returns>
		protected virtual string Validate(string propertyName)
		{
			ValidationContext validationContext = new ValidationContext(this)
			{
				MemberName = propertyName
			};

			Collection<ValidationResult> validationResults = new Collection<ValidationResult>();

			if (!Validator.TryValidateObject(this, validationContext, validationResults, true))
			{
				ValidationResult validationResult = validationResults.SingleOrDefault(r => r.MemberNames.Any(x => x == propertyName));

				return validationResult == null
					? null
					: validationResult.ErrorMessage;
			}

			return null;
		}
	}
}