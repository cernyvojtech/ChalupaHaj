using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChalupaHaj.Data;
using ChalupaHaj.Models;
using Microsoft.EntityFrameworkCore.Storage;
using ChalupaHaj.Controllers;

namespace ChalupaHaj.Views.Shared.Components.ReservationForms
{
    public class ReservationViewComponent : ViewComponent
    {
        //creates database context
        private readonly ApplicationDbContext _context;


        //creates instansce of database context - to be used, when returning view
        public ReservationViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }


        //input - user created form, sends to database and return view 
        public async Task<IViewComponentResult> InvokeAsync([Bind("Id,Name,Surname,Email,Phone,Arrival,Departure,NumberOfPersons,Message")] ReservationForm reservationForm)
        {
            return await Task.FromResult((IViewComponentResult)View());
        }


    }
}
