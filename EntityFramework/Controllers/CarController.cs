using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            CarDbContext cars=new CarDbContext();
            var Cars=cars.Cars.ToList();
            return View(Cars);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Car car=new Car();
            return View(car);     
        }
        [HttpPost]
        public IActionResult create(Car car)
        {
            CarDbContext cars = new CarDbContext();
            cars.Cars.Add(car);
            cars.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            
            CarDbContext db = new CarDbContext();
            var car = db.Cars.FirstOrDefault(a => a.Id == id);
            return View(car);
        }
        [HttpPost]
        public IActionResult Update(Car car)
        {
            CarDbContext db = new CarDbContext();
            var carToUpdate = db.Cars.FirstOrDefault(a => a.Id ==car.Id);
            carToUpdate.OwnerName = car.OwnerName;
            carToUpdate.CarName = car.CarName;
            carToUpdate.CarModelYear = car.CarModelYear;
            carToUpdate.FuelType = car.FuelType;
            carToUpdate.CarInsuranceYear= car.CarInsuranceYear;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            CarDbContext db = new CarDbContext();
            var Cars = db.Cars.FirstOrDefault(a=>a.Id==id);
            db.Cars.Remove(Cars);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
