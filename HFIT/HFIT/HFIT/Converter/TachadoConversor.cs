using System;
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
            try
            {
                Boolean valor = (string)value == "SIM" ? true : false;
                // Boolean valor = true ;

                if (valor)
                {
                    return TextDecorations.Strikethrough;
                }
                else
                {
                    return TextDecorations.None;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool ConvertTextToBool(string value, CultureInfo culture)
        {
            try
            {
                Boolean valor = (string)value == "SIM" ? true : false;
                // Boolean valor = true ;
                return valor;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
