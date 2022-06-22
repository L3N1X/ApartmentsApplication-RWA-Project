using RwaApartmaniDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if (this.ddlUserType.SelectedValue == "registered")
            //    {
            //        string details = this.txtDetails.Text;
            //        /*Generate reservation with registered user*/
            //        ((IRepo)Application["database"]).InsertApartmentReservation(new ApartmentReservation
            //        {
            //            Guid = Guid.NewGuid(),
            //            CreatedAt = DateTime.Now,
            //            ApartmentId = selectedApartment.Id,
            //            Details = "????",
            //            UserId = int.Parse(this.ddlUsers.SelectedValue),
            //        });
            //    }
            //    else if (this.ddlUserType.SelectedValue == "not_registered")
            //    {
            //        /*Generate resevation with unregistered user*/
            //        ((IRepo)Application["database"]).InsertApartmentReservation(new ApartmentReservation
            //        {
            //            Guid = Guid.NewGuid(),
            //            CreatedAt = DateTime.Now,
            //            ApartmentId = selectedApartment.Id,
            //            Details = this.txtDetails.Text,
            //            UserEmail = this.txtEmail.Text,
            //            UserName = this.txtUserName.Text,
            //            UserAddress = this.txtUserAddress.Text,
            //            UserPhone = this.txtPhone.Text
            //        });
            //    }
            var reservation = new ApartmentReservation
            {
                Guid = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ApartmentId = 3,
                Details = "????",
                UserId = int.Parse("2"),
            };
        }
    }
}
