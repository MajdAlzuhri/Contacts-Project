using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public static class clsDataAccessHelper
    {
        public static string GetString(object value, string defaultValue = "")
        {
            return (value != DBNull.Value && value != null) ? Convert.ToString(value) : defaultValue;
        }

        public static DateTime GetDateTime(object value, DateTime? defaultValue = null)
        {
            if (value != DBNull.Value && value != null)
                return Convert.ToDateTime(value);

            return defaultValue ?? DateTime.Today;
        }

        public static int GetInt(object value, int defaultValue = -1)
        {
            if (value != DBNull.Value && value != null)
                return Convert.ToInt32(value);

            return defaultValue;
        }
    }
}
