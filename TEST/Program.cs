using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Abstracts;
using RwaApartmaniDataLayer.Repositories.Implementations;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBRepo repo = new DBRepo();
            //var apartments = repo.LoadApartments();
            //foreach (var apartment in apartments)
            //{
            //    var statis = repo.LoadApartmentStatusById(apartment.StatusId);
            //    Console.WriteLine(statis.Name);
            //}
            //var owners = repo.LoadApartmentOwners();
            //foreach (var owner in owners)
            //{
            //    Console.WriteLine(owner.Name);
            //}
            //var reservations = repo.LoadApartmentReservations();
            //foreach (var reservation in reservations)
            //{
            //    var temp = repo.LoadApartmentReservationById(reservation.Id);
            //    Console.WriteLine($"Apartment: {temp.Apartment.Name} Username: {temp.User.UserName}");
            //}
            //var apartments = repo.LoadApartments(a => a.City.Name.Equals("Opatija"));
            //foreach (var apartment in apartments)
            //{
            //    Console.WriteLine(apartment.Name);
            //    foreach (var tag in apartment.Tags)
            //    {
            //        Console.WriteLine($"\t{tag.Name}");
            //    }
            //}
            //var reviews = repo.LoadApartmentReviews();
            //foreach (var review in reviews)
            //{
            //    var temp = repo.LoadApartmentReviewById(review.Id);
            //    Console.WriteLine($"Apartment: {temp.Apartment.Name} User: {temp.User.UserName} Review: {temp.Details} Stars: {temp.Stars}");
            //}
            //var tuples = repo.LoadTagsCounted();
            //foreach (var tuple in tuples)
            //{
            //    Console.WriteLine($"{tuple.Item1.Name}- ({tuple.Item2}) {(tuple.Item2.Equals(0) ? "- DELETE" : string.Empty)}");
            //}
            //var apartments = repo.LoadApartments(a => true);
            //IList<Apartment> aps = new List<Apartment>(apartments);
            //aps.ToList().Sort((left, right) => left.PicturesCount.CompareTo(right.PicturesCount));
            //foreach (var item in aps)
            //{
            //    Console.WriteLine(item.PicturesCount);
            //}
            //var owners = repo.LoadApartmentOwners();
            //foreach (var owner in owners)
            //{
            //    Console.WriteLine(owner.Name);
            //}
            //List<int> tagoviIzBaze = new List<int>() { 1,2,3,4 };
            //List<int> trenutniTagovi = new List<int>() { 1, 2, 5};
            //List<int> tagoviZaMaknuti = tagoviIzBaze.Except(trenutniTagovi).ToList();
            //List<int> tagoviZaDodati = trenutniTagovi.Except(tagoviIzBaze).ToList();
            //Console.WriteLine("Tagovi za maknuti");
            //foreach (var num in tagoviZaMaknuti)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.WriteLine("Tagovi za dodati");
            //foreach (var num in tagoviZaDodati)
            //{
            //    Console.WriteLine(num);
            //}
            //var apartment = repo.LoadApartmentById(1);
            //foreach (var picture in apartment.Pictures)
            //{
            //    Console.WriteLine(picture.Base64Content);
            //}
            //byte[] data = Encoding.ASCII.GetBytes(apartment.Pictures[0].Base64Content);
            //Console.WriteLine(ResizeImage(data));đ
            var pic = new ApartmentPicture { Name = "Kurac" };
            Console.WriteLine(pic.Path);
            

        }
        public static string ResizeImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var image = Image.FromStream(ms);

                var ratioX = (double)150 / image.Width;
                var ratioY = (double)50 / image.Height;

                var ratio = Math.Min(ratioX, ratioY);

                var width = (int)(image.Width * ratio);
                var height = (int)(image.Height * ratio);

                var newImage = new Bitmap(width, height);

                Graphics.FromImage(newImage).DrawImage(image, 0, 0, width, height);

                Bitmap bmp = new Bitmap(newImage);

                ImageConverter converter = new ImageConverter();

                data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                return "data:image/*;base64," + Convert.ToBase64String(data);
            }
        }

    }
}
