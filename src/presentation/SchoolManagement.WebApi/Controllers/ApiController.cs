using Microsoft.AspNetCore.Mvc;

using SchoolManagement.Data;

namespace SchoolManagement.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ApiController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected new IActionResult Ok()
        {
            _unitOfWork.Commit();
            return base.Ok(Envelope.Ok());
        }

        protected new IActionResult Ok<T>(T result)
        {
            _unitOfWork.Commit();
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }
    }
}
