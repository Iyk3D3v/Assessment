using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Assess : ControllerBase
    {

        //Please find below solutions to the Assessment Questions
        
        //This is solution to the first question
        
        // https://localhost:5051/api/Assess/First?sample=1-2-3-4-5
        [HttpGet]
        public IActionResult First(string sample)
        {
            if (sample != null)
            {
                var letters = sample.Split("-");
                var numbers = Array.ConvertAll(letters, int.Parse);
                var diff = numbers[1] - numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                   if((numbers[i] - numbers[i-1]) != diff)
                   {
                       return Ok(false);
                   }
                }
                return Ok(true);
            }
            return BadRequest();
        }

        //Solution to the second question
        //sample object is as belows
        // {
        //     "arr":[1,2],
        //     "K" : 5
        // }

        [HttpPost]
        public IActionResult Second(RequestDto req )
        {
            int num;
            if(req.arr.Length < 2)
            {
                return BadRequest("Invalid Request");
            }
            int diff = req.arr[1] = req.arr[0];
            for(int i = 1; i< req.arr.Length; i++)
            {
                if((req.arr[i] -req. arr[i-1]) != diff)
                {
                    num =0;
                }

            }
            num =diff;
            if(req.arr.Length > req.K & num != 0)
            {
                return Ok(req.arr[req.K-1]);
            }

            return Ok(-1);
        }


        //solution to the Third question

        //https://localhost:5051/api/Assess/Third?sample=Assess
        [HttpGet]
        public IActionResult Third(string sample)
        {
            string result = string.Empty;
            if (sample != null)
            {
                var unique = sample.Distinct().ToList();
                for(int i = 0; i < unique.Count; i++)
                {
                    var count = sample.Count(x=>x == unique[i]);
                    result = result + unique[i].ToString() + count;
                }
                return Ok(result);
            }
            return BadRequest();
        }

    }
}