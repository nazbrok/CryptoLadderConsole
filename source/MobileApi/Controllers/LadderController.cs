using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedBusinessLogic = InternetWideWorld.CryptoLadder.Shared.BusinessLogic;
using InternetWideWorld.CryptoLadder.Shared.Model;

namespace CryptoLadderMobileApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LadderController : ControllerBase
    {
        /// <summary>Get the generated ladder details.</summary>
        [HttpGet]
        public List<LinearRungs> Get(double startPrice, double endPrice, int ladderRungs, int totalQuantity)
        {
            return SharedBusinessLogic.Ladder.Linear(startPrice, endPrice, ladderRungs, totalQuantity);
        }
    }
}