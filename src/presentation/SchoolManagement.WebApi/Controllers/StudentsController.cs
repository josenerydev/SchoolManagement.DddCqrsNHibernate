using MediatR;

using Microsoft.AspNetCore.Mvc;

using SchoolManagement.Application.Student;
using SchoolManagement.Data;

namespace SchoolManagement.WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator, UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
