using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonServices _personService;

        public PersonController(ILogger<PersonController> logger, IPersonServices personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        }



        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            var person = _personService.FindByID(id);
            
            if(person == null) 
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personService.Create(person));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();

        }

        //[HttpGet("sum/{firstNumber}/{secondNumber}")]
        //public IActionResult Sum(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var res = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

        //        return Ok(res.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        //public IActionResult Subtraction(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var res = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

        //        return Ok(res.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        //public IActionResult Multiplication(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var res = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

        //        return Ok(res.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("division/{firstNumber}/{secondNumber}")]
        //public IActionResult Division(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var res = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

        //        return Ok(res.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}


        //[HttpGet("mean/{firstNumber}/{secondNumber}")]
        //public IActionResult Mean(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var res = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

        //        return Ok((res).ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("square-root/{firstNumber}")]
        //public IActionResult SquareRoot(string firstNumber)
        //{
        //    if (IsNumeric(firstNumber))
        //    {
        //        var res = Math.Sqrt((double)ConvertToDecimal(firstNumber));

        //        return Ok((res).ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}


        private decimal ConvertToDecimal(string strNumber)
        {
            if (decimal.TryParse(strNumber, out decimal number))
                return number;

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {

            return double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out double number);


        }
    }
}