﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.ReCAPTCHA
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReCAPTCHAController : ControllerBase
    {
        //private IHttpClientFactory HttpClientFactory { get; }

        //private IOptions<reCAPTCHAVerificationOptions> reCAPTCHAVerificationOptions { get; }

        //public reCAPTCHAController(IHttpClientFactory httpClientFactory, IOptions<reCAPTCHAVerificationOptions> reCAPTCHAVerificationOptions)
        //{
        //    this.HttpClientFactory = httpClientFactory;
        //    this.reCAPTCHAVerificationOptions = reCAPTCHAVerificationOptions;
        //}

        //public async Task<IActionResult> Post([FromBody] SampleAPIArgs args)
        //{
        //    var url = "https://www.google.com/recaptcha/api/siteverify";
        //    var content = new FormUrlEncodedContent(new Dictionary<string, string>
        //    {
        //        {"secret", this.reCAPTCHAVerificationOptions.Value.Secret},
        //        {"response", args.reCAPTCHAResponse}
        //    });

        //    var httpClient = this.HttpClientFactory.CreateClient();
        //    var response = await httpClient.PostAsync(url, content);
        //    response.EnsureSuccessStatusCode();

        //    var verificationResponse = await response.Content.ReadFromJsonAsync<reCAPTCHAVerificationResponse>();
        //    if (verificationResponse.Success) return Ok();

        //    return BadRequest(string.Join(", ", verificationResponse.ErrorCodes.Select(err => err.Replace('-', ' '))));
        //}
    }
}
