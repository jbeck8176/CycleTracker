﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CycleTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class BikeController : Controller
    {
	    private readonly IBikeRepository bikeRepository;

	    public BikeController(Data.Repositories.IBikeRepository bikeRepository)
	    {
		    this.bikeRepository = bikeRepository;
	    }

	    // GET: api/Bike
        [HttpGet]
        public IEnumerable<Bike> Get()
        {
			var partRepo = new PartRepository();
			var bike = new Bike { Make = "fuck you", Model = "no. fuck you.", Colors = "black", Trim = "fu", Year = 2016 };

			bike.Id = bikeRepository.Add(bike);

			var part = new Part { BikeId = bike.Id, Description = "test", InstalledBikeMileage = 3, InstalledDate = DateTime.UtcNow, Retailer = "Eddy's", Name = "Seat Post" };

			partRepo.Add(part);

			part = new Part { BikeId = bike.Id, Description = "test 2", InstalledBikeMileage = 3, InstalledDate = DateTime.UtcNow, Retailer = "Eddy's", Name = "Seat" };

	        partRepo.Add(part);

			return bikeRepository.FindAll();
        }

		// GET api/Bike/5
		[HttpGet("{id}")]
        public Bike Get(long id)
        {
            return bikeRepository.FindById(id);
        }

		// GET api/Bike/5
		[HttpGet("withparts/{id}")]
		public Bike GetWithParts(long id)
		{
			return bikeRepository.GetBikeWithParts(id);
		}

		// POST api/Bike
		[HttpPost]
        public Bike Post([FromBody]Bike value)
        {
	        var id = bikeRepository.Add(value);
	        return bikeRepository.FindById(id);
        }

		// PUT api/Bike/5
		[HttpPut]
        public void Put([FromBody]Bike value)
        {
			bikeRepository.Update(value);
        }

		// DELETE api/Bike/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
			bikeRepository.Remove(id);
        }
    }
}
