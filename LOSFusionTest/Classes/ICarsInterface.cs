using LOSFusionTest.Models;
using System;
using System.Collections.Generic;

namespace LOSFusionTest.Classes
{
    public interface ICarsInterface : IDisposable
    {
        List<CarModel> getCars(string minYear, string maxYear);
        CarModel getCarsbyId(int carId);
        bool AddUpdatecar(CarModel model);

    }
}