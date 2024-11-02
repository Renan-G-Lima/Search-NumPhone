using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using OpenCage.Geocode;

namespace teste.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class Passkey : ControllerBase
    {
        private readonly Geocoder _geocoder;

        public Passkey()
        {
            var key = "c5f8e9a5351d4bc4b47f0e7bf708f665"; // substitua pela sua chave de API real
            _geocoder = new Geocoder(key);
        }

        [HttpGet("geocode")]
        public IActionResult Geocode(string address)
        {
            var result = _geocoder.Geocode(address);
            return Ok(result);
        }

        [HttpGet("reverse-geocode")]
        public IActionResult ReverseGeocode(double latitude, double longitude)
        {
            var result = _geocoder.ReverseGeocode(latitude, longitude);
            return Ok(result);
        }

        private IActionResult Ok(GeocoderResponse result)
        {
            throw new NotImplementedException();
        }
    }

    internal class RouteAttribute : Attribute
    {
        public RouteAttribute(string v)
        {
            V = v;
        }

        public string V { get; }
    }

    internal class ApiControllerAttribute : Attribute
    {
    }

    internal class HttpGetAttribute : Attribute
    {
        private string v;

        public HttpGetAttribute(string v)
        {
            this.v = v;
        }
    }

    public interface IActionResult
    {
    }

    public class ControllerBase
    {
    }
}