﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SamStore.Core.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null) 
        {
            if (OperationIsValid())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", Errors.ToArray() },
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState) 
        {
            var errors = modelState.Values.SelectMany(x => x.Errors);

            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool OperationIsValid() =>
            !Errors.Any();

        protected void AddError(string error) => 
            Errors.Add(error);

        protected void ClearErrors() => 
            Errors.Clear();
    }
}