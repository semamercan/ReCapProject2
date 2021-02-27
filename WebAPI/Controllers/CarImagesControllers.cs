using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesControllers : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesControllers(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, int carId)
        {     
            if (Path.GetExtension(file.FileName) != ".png" && Path.GetExtension(file.FileName) != ".jpg" && Path.GetExtension(file.FileName) != ".jpeg")
            {
                return BadRequest();
            }
            CarImage carImage = new CarImage();
            carImage.CarId = carId;
            carImage.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            carImage.Date = DateTime.Now;
            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                FileStream fileStream = System.IO.File.Create(Path.Combine(@"\Images\CarImages\" + carImage.ImagePath));
                file.CopyTo(fileStream);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var data = _carImageService.GetById(id);
            var result = _carImageService.Delete(data.Data);
            if (result.Success)
            {
                System.IO.File.Delete(Path.Combine(@"CarImages\" + data.Data.ImagePath));
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] int carImageId, [FromForm] int carId)
        {
            if (Path.GetExtension(file.FileName) != ".png" && Path.GetExtension(file.FileName) != ".jpg" && Path.GetExtension(file.FileName) != ".jpeg")
            {
                return BadRequest();
            }
            var data = _carImageService.GetById(carImageId);
            data.Data.CarId = carId;
            System.IO.File.Delete(Path.Combine(@"Images\CarImages\" + data.Data.ImagePath));
            data.Data.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            data.Data.Date = DateTime.Now;
            var result = _carImageService.Update(data.Data);
            if (result.Success)
            {
                FileStream fileStream = System.IO.File.Create(Path.Combine(@"Images\CarImages\" + data.Data.ImagePath));
                file.CopyTo(fileStream);
                return Ok(result);
            }
            return BadRequest(result); ;
        }


    }
}
