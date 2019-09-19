using Weather.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace Weather.Utils
{
    public static class SQLiteUtil
    {
        private static String DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"sqlite.db3");
        private static SQLiteConnection Connection { get; set; }
        static SQLiteUtil()
        {
            if (File.Exists(DbPath))
                File.Delete(DbPath);

            File.Create(DbPath);

            Connection = new SQLiteConnection(DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite);

            Connection.CreateTable<Temperature>();
            Connection.CreateTable<Models.Weather>();
            Connection.CreateTable<CityInformation>();

            Connection.BeginTransaction();
        }

        public static IEnumerable<CityInformation> GetInformation()
        {
            var cityInfo = Connection.Table<CityInformation>();
            if (cityInfo != null && cityInfo.Count() > 1)
                return cityInfo;
            else
                throw new Exception("Não há nenhuma cidade registrada!");
        }

        public static IEnumerable<CityInformation> GetInformation(int idCity)
        {
            var cityInfo = Connection.Table<CityInformation>().Where(info => info.Id == idCity);
            if (cityInfo != null)
                return cityInfo;
            else
                throw new Exception("Não há nenhuma cidade registrada com este ID");
        }

        public static void InsertCities(IEnumerable<CityInformation> cities)
        {
            if (cities != null)
            {
                Connection.InsertAll(cities);
                Connection.Commit();
            }
            else
                throw new Exception("Há algo de errado com estes registros...");
        }
    }
}