﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Skeleton.SimpleAsyncDemo
{
	public sealed class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool boolValue = (bool)value;

			return boolValue
				? Visibility.Visible
				: Visibility.Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}