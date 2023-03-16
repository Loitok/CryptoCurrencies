using System;
using System.Globalization;
using System.Windows.Data;

namespace CryptoCurrencies
{
    public class ToUpper : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value == null ? string.Empty : value.ToString()?.ToUpper();
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PercentageToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                decimal percentage = (decimal)value;
                return (percentage >= 0 ? "⏶" : "⏷") +
                       Math.Abs(percentage / 100).ToString("P", CultureInfo.InvariantCulture);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PercentageToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value != null && (decimal)value >= 0 ? "#16c784" : "#ea3943";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalToVariableCurrency : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return string.Empty;

            var price = (decimal)value;

            int precision;

            if (price >= 1 || price < 0) 
                precision = 2;
            else if (price > 0.099M) 
                precision = 4;
            else 
                precision = (int)Math.Log10((double)(1M / price)) * 2;

            return string.Format(CultureInfo.CurrentCulture, "{0:C" + precision + "}", price);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalToVariablePrecision : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var price = (decimal)value;

            if (price <= 0) return string.Empty;

            int precision;
            if (price >= 1) precision = 2;
            else if (price > 0.099M) precision = 4;
            else precision = (int)Math.Log10((double)(1M / price)) * 2;
            return string.Format(CultureInfo.CurrentCulture, "{0:N" + precision + "}", price);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalToShortCurrency : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal v = (decimal)value;
            culture = CultureInfo.CurrentCulture;
            string symbol = culture.NumberFormat.CurrencySymbol;
            return v switch
            {
                > 999_999_999 => v.ToString(symbol + "0,,,.##B", culture),
                > 999_999 => v.ToString(symbol + "0,,.##M", culture),
                > 9_999 => v.ToString(symbol + "0,.##K", culture),
                _ => v.ToString("C", culture)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalDivision : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(
                    CultureInfo.CurrentCulture,
                    "{0:N5}",
                    values[0] is not decimal a || values[1] is not decimal b ? 0 : b / a)
                ;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
