using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MVVM.View.transformers
{
    internal class Sexe2RadioTransform:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SexeEnum s;
            switch((string)parameter)
            {
                case "0":s = SexeEnum.DONA; break;
                case "1":s = SexeEnum.HOME; break;
                default:s = SexeEnum.NO_DEFINIT; break;
            }
            return ((SexeEnum)value) == s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            SexeEnum s;
            switch ((string)parameter)
            {
                case "0": s = SexeEnum.DONA; break;
                case "1": s = SexeEnum.HOME; break;
                default: s = SexeEnum.NO_DEFINIT; break;
            }

            if ((bool)value == true)
            {
                // Si el RadioButton es sel·lecciona, canviem el sexe
                return s;
            }
            else
            {
                // Si el RadioButton es dessel·leciona, no cal fer res
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
