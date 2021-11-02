using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ppj3
{
    class DataManager
    {
        public static List<Movie> Movies = new List<Movie>();
        public static List<Reservation> Reservations = new List<Reservation>();
    
        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                string moviesOutput = File.ReadAllText(@"./Movies.xml");
                XElement moviesXElement = XElement.Parse(moviesOutput);

                Movies = (from item in moviesXElement.Descendants("movie")
                          select new Movie()
                          {
                              Title = item.Element("title").Value,
                              Room = item.Element("room").Value,
                              Screeningtime = item.Element("screeningtime").Value,
                              Grade = item.Element("grade").Value,
                              Content = item.Element("content").Value,
                              Genre = item.Element("genre").Value
                          }).ToList<Movie>();

                string reservationsOutput = File.ReadAllText(@"./Reservations.xml");
                XElement reservationsXElement = XElement.Parse(reservationsOutput);

                Reservations = (from item in reservationsXElement.Descendants("reservation")
                                select new Reservation()
                                {
                                    rTitle = item.Element("rtitle").Value,
                                    rRoom = item.Element("rroom").Value,
                                    rSt = item.Element("rst").Value,
                                    Seat = item.Element("seat").Value,
                                    Price = int.Parse(item.Element("price").Value),
                                    Name = item.Element("name").Value,
                                    PhoneNum = item.Element("phoneNum").Value,
                                    WhenReserve = DateTime.Parse(item.Element("whenReserve").Value),
                                    Password = item.Element("password").Value
                                }).ToList<Reservation>();
            }catch(FileNotFoundException e)
            {
                Save();
            }
        }

        public static void Save()
        {
            string moviesOutput = "";
            moviesOutput += "<movies>\n";
            foreach(var item in Movies)
            {
                moviesOutput += "<movie>\n";
                moviesOutput += "<title>" + item.Title + "</title>\n";
                moviesOutput += "<room>" + item.Room + "</room>\n";
                moviesOutput += "<screeningtime>" + item.Screeningtime + "</screeningtime>\n";
                moviesOutput += "<grade>" + item.Grade + "</grade>\n";
                moviesOutput += "<content>" + item.Content + "</content>\n";
                moviesOutput += "<genre>" + item.Genre + "</genre>\n";
                moviesOutput += "</movie>\n";
            }
            moviesOutput += "</movies>\n";
            File.WriteAllText(@"./Movies.xml", moviesOutput);

            string reservationsOutput = "";
            reservationsOutput += "<reservations>\n";
            foreach(var item in Reservations)
            {
                reservationsOutput += "<reservation>\n";
                reservationsOutput += "<rtitle>" + item.rTitle + "</rtitle>\n";
                reservationsOutput += "<rroom>" + item.rRoom + "</rroom>\n";
                reservationsOutput += "<rst>" + item.rSt + "</rst>\n";
                reservationsOutput += "<seat>" + item.Seat + "</seat>\n";
                reservationsOutput += "<price>" + item.Price + "</price>\n";
                reservationsOutput += "<name>" + item.Name + "</name>\n";
                reservationsOutput += "<phoneNum>" + item.PhoneNum + "</phoneNum>\n";
                reservationsOutput += "<whenReserve>" + item.WhenReserve.ToLongDateString() + "</whenReserve>\n";
                reservationsOutput += "<password>" + item.Password + "</password>\n";
                reservationsOutput += "</reservation>\n";
            }
            reservationsOutput += "</reservations>\n";
            File.WriteAllText(@"./Reservations.xml", reservationsOutput);
        }
    }
}
