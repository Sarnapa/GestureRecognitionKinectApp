using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views.Helpers
{
	public static class FontSizeConverter
	{
		#region Public methods
		public static void ScaleFontSizeForTextBlock(TextBox tb, int colIdx, double maxFontSize = 42d)
		{
			if (tb != null && !string.IsNullOrEmpty(tb.Text) && colIdx >= 0)
			{
				double fontSize = maxFontSize;
				Size desiredSize = MeasureText(tb, maxFontSize);

				var grid = tb.Parent as Grid;
				var columnDefinitionCollection = grid.ColumnDefinitions;

				if (colIdx >= columnDefinitionCollection.Count)
					return;

				double tbHeight = tb.ActualHeight;
				double colWidth = columnDefinitionCollection[colIdx].ActualWidth;

				double widthMargins = tb.Margin.Left + tb.Margin.Right;
				double heightMargins = tb.Margin.Top + tb.Margin.Bottom;

				double desiredHeight = desiredSize.Height + heightMargins;
				double desiredWidth = desiredSize.Width + widthMargins;

				if (tbHeight < desiredHeight)
				{
					double factor = (desiredHeight - heightMargins) / (tbHeight - heightMargins);
					fontSize = Math.Min(fontSize, maxFontSize / factor);
				}

				if (colWidth < desiredWidth)
				{
					double factor = (desiredWidth - widthMargins) / (colWidth - widthMargins);
					fontSize = Math.Min(fontSize, maxFontSize / factor);
				}

				if (fontSize > 0)
					tb.FontSize = fontSize;
			}
		}
		#endregion

		#region Private methods
		/// <summary>
		/// Measures text size of textbox
		/// </summary>
		/// <param name="tb">TextBox component</param>
		private static Size MeasureText(TextBox tb, double maxFontSize = 42d)
		{
			var formattedText = new FormattedText(tb.Text, CultureInfo.CurrentUICulture,
					FlowDirection.LeftToRight,
					new Typeface(tb.FontFamily, tb.FontStyle, tb.FontWeight, tb.FontStretch),
					maxFontSize, Brushes.Black, 1d);

			return new Size(formattedText.Width, formattedText.Height);
		}
		#endregion
	}
}
