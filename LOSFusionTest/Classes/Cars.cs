using LOSFusionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace LOSFusionTest.Classes
{
    public class Cars:ICarsInterface,IDisposable
    {
        //Get car list
        #region Methods 
        public List<CarModel> getCars(string minYear, string maxYear)
        {
            var userId = GetUserId();
            var response =new List<CarModel>();
            var _minYear = minYear!=null ? Convert.ToDateTime(minYear) : DateTime.Now;
            var _maxYear = maxYear!=null ? Convert.ToDateTime(maxYear) : DateTime.Now.AddYears(-20); Convert.ToDateTime(maxYear);
            using (var _entity = new LosFusionTestEntities())
            {
                var cars = _entity.TblCars.Where(c => c.Year<_minYear && c.Year > _maxYear && c.UserId==userId);
                if (cars != null)
                {
                   foreach(var c in cars)
                    {
                        response.Add(new CarModel { Color = c.Color, ID = c.ID, Name = c.Name, UserId =c.UserId, Year = (DateTime)c.Year });
                    }
                }
            }
            return response;
        }

        //Get car by car Id
        public CarModel getCarsbyId(int carId)
        {
            var response = new CarModel();
            var userId = GetUserId();
            using (var _entity = new LosFusionTestEntities())
            {
                var cars = _entity.TblCars.Where(c=>c.ID==carId && c.UserId==userId).FirstOrDefault();
                if (cars != null)
                {
                   response= new CarModel { Color = cars.Color, ID = cars.ID, Name = cars.Name, UserId = cars.UserId, Year = (DateTime)cars.Year };
                }
            }
            return response;
        }

        //Add-update car details
        public bool AddUpdatecar(CarModel model)
        {
            var status = false;
            var userId = GetUserId();
            using (var entity= new LosFusionTestEntities())
            {
                if (model.ID > 0)
                {
                    var car = entity.TblCars.Where(c => c.ID == model.ID).FirstOrDefault();
                    if (car != null)
                    {
                        car.Color = model.Color;
                        car.Name = model.Name;
                        car.Year = Convert.ToDateTime(model.Year);
                        car.ModifiedOn = DateTime.Now;
                        entity.SaveChanges();
                        status = true;
                    }
                }
                else
                {
                    var car = new TblCar();
                    car.Color = model.Color;
                    car.Name = model.Name;
                    car.UserId = userId.ToString();// model.UserId;
                    car.Year = Convert.ToDateTime(model.Year);
                    car.ModifiedOn = DateTime.Now;
                    entity.TblCars.Add(car);
                    entity.SaveChanges();
                    status = true;
                }
            }
            return status;
        }
        #endregion

        #region Claim Identity
        private string GetUserId()
        {
            var claims = (ClaimsIdentity)ClaimsPrincipal.Current.Identity;

            if (claims == null)
            {
                return null;
            }

            var targetClaim = claims.Claims.FirstOrDefault();
            if (targetClaim == null)
            {
                return null;// defaultValue;
            }

            return targetClaim.Value;
        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}