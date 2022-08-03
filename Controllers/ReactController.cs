using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private static readonly string[] Reacts = new[]
       {
            "Happy", "Sad", "Good", "Fun", "Worry", "Hurry"
        };

        private readonly ILogger<ReactController> _logger;

        public ReactController(ILogger<ReactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<reactOfMom> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new reactOfMom
            {
                Date = DateTime.Now.AddDays(index),
                Power = rng.Next(1, 100),
                Emotion = Reacts[rng.Next(Reacts.Length)]
            })
            .ToArray();
        }
    }
}
