using Ailos.Pix.DTO.Key;
using Ailos.Pix.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Api.Pix
{
    public class KeyController : Controller
    {
        private readonly IKeyService _keyService;

        public KeyController(IKeyService keyService)
        {
            _keyService = keyService;
        }

        [HttpPost]
        [Route("/Key")]
        public async Task<NewKeyResponse> AddKey(NewKeyRequest newKeyRequest)
        {
            return await _keyService.AddKey(newKeyRequest);
        }
    }
}
