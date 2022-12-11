
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Reflection;
//using BO;
//using System.Collections;

//namespace BL
//{
//    public static string ToStringProperty<T>(this T t, string suffix = "")
//    //מתודה להפיכת ישות למחרוזת לצורך הצגת הפרטים
//    {
//        string str = "";
//        foreach (PropertyInfo prop in t!.GetType().GetProperties())
//        {
//            var value = prop.GetValue(t, null);
//            if (value is not string && value is IEnumerable)
//            {
//                str = str + "\n" + prop.Name + ":";
//                foreach (var item in (IEnumerable)value)
//                    str += item.ToStringProperty("      ");
//            }

//            else
//                str += "\n" + suffix + prop.Name + ": " + value;
//        }
//        str += "\n";
//        return str;
//    }
//}

