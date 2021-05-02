﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HFIT.Converter
{
   public  class TachadoConversor
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Boolean valor = (Boolean)value;

            if (valor)
            {
                return TextDecorations.Strikethrough;
            }
            else
            {
                return TextDecorations.None;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}