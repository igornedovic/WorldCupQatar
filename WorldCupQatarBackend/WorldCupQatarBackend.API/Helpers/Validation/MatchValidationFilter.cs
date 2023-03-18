using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WorldCupQatarBackend.Business.DTOs;

namespace WorldCupQatarBackend.API.Helpers.Validation
{
    public class MatchValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is MatchCreateDto);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null!");
                return;
            }

            var matchCreateDto = (MatchCreateDto)param.Value;

            if (string.IsNullOrEmpty(matchCreateDto.MatchDateTime))
            {
                context.Result = new BadRequestObjectResult("Match date and time is required!");
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}