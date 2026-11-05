using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {

        enum enMode { AddNew = 1, Update };
        enMode Mode;
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCode { get; set; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";
            this.CountryCode = "";
            this.PhoneCode = "";

            Mode = enMode.AddNew;
        }

        private clsCountry(int ID, string CountryName, string CountryCode, string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.CountryCode = CountryCode;
            this.PhoneCode = PhoneCode;
            Mode = enMode.Update;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            string CountryCode = "";
            string PhoneCode = "";

            if (clsCountryDataAccess.GetCountryInfoByID(ID, ref CountryName, ref CountryCode, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, CountryCode, PhoneCode);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewCountry()
        {
            this.ID = clsCountryDataAccess.AddNewCountry(this.CountryName, this.CountryCode, this.PhoneCode);
            return (this.ID != -1);

        }

        private bool _UpdateCountry()
        {
            return clsCountryDataAccess.UpdateCountry(this.ID, this.CountryName, this.CountryCode, this.PhoneCode);
        }


        public static bool DeleteCountry(int ID)
        {
            return clsCountryDataAccess.DeleteCountry(ID);
        }

        public static bool isCountryExist(int ID)
        {
            return clsCountryDataAccess.IsCountryExist(ID);
        }

        static public DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }



        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCountry();

            }

            return false;
        }

        public static clsCountry Find(string CountryName)
        {

            int ID = -1;
            string Code = "";
            string PhoneCode = "";


            if (clsCountryDataAccess.GetCountryInfoByName(CountryName, ref ID, ref Code, ref PhoneCode))

                return new clsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;

        }
    }
}
