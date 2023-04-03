using LOSFusionTest.Classes;
using LOSFusionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LOSFusionTest.Controllers
{
    [Authorize]
    [RoutePrefix("api/cars")]
    public class ValuesController : ApiController
    {
        #region PRIVATE VARIABLES

        private ICarsInterface _carRepository;
        #endregion

        #region CTOR

        public ValuesController()
        {
            _carRepository = new Cars();
        }

        public ValuesController(ICarsInterface carRepository)
        {
            _carRepository = carRepository;
        }

        #endregion


        #region ApiMethods

        [Route("get")]
        [HttpGet]
        public IHttpActionResult getcars(string minYear=null, string maxYear=null)
        {
            ResponseJson response = new ResponseJson();
            try
            {
                response = new ResponseJson() { Message = "Cars list got successfully.", status = true, statusCode = 200, Result = _carRepository.getCars( minYear, maxYear) };
            }
            catch (Exception e)
            {
                response = new ResponseJson() { Message = e.Message, status = false, statusCode = e.GetHashCode() };

                //log the error in details
            }
            return Ok(response);

        }

        
        //[HttpPatch]
        [HttpGet]
        [Route("getcarbyId")]
        public IHttpActionResult getcarbyId(int id)
        {
            ResponseJson response = new ResponseJson();
            try
            {
                response = new ResponseJson() { Message = "Details get successfully.", status = true, statusCode = 200, Result = _carRepository.getCarsbyId(id) };
            }
            catch(Exception e)
            {
                response = new ResponseJson() { Message = e.Message, status = false, statusCode = e.GetHashCode() };
                
                //log the error in details
            }
            return Ok(response);

        }
       
       
        [Route("AddUpdatecar")]
        [HttpPost]
        public IHttpActionResult AddUpdatecar(CarModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResponseJson response = new ResponseJson();
            try
            {
                response = new ResponseJson() { Message = model.ID > 0 ? "Car updated successfully." : "New car added successfully.", status = true, statusCode = 200, Result = _carRepository.AddUpdatecar(model) };
            }
            catch (Exception e)
            {
                response = new ResponseJson() { Message = e.Message, status = false, statusCode = e.GetHashCode() };

                //log the error in details
            }
            return Ok(response);

        }
        #endregion
    }
}
