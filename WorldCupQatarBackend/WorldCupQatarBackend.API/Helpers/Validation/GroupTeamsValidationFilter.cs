using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.API.Helpers.Validation
{
    public class GroupValidator
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public class TeamValidator
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public class GroupTeamsValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is GroupCreateDto);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null!");
                return;
            }

            var groupCreateDto = (GroupCreateDto)param.Value;

            if (string.IsNullOrEmpty(groupCreateDto.Name))
            {
                context.Result = new BadRequestObjectResult("Group name is required!");
                return;
            }

            var path = Path.GetDirectoryName(typeof(GroupTeamsValidationFilter).Assembly.Location);

            var groupsData = File.ReadAllText(path + @"/Helpers/Validation/JSON/groups.json");

            var possibleGroups = JsonSerializer.Deserialize<List<GroupValidator>>(groupsData);

            if (!possibleGroups.Any(x => x.Name == groupCreateDto.Name))
            {
                context.Result = new BadRequestObjectResult("Invalid group name format!");
                return;
            }

            var countriesData = File.ReadAllText(path + @"/Helpers/Validation/JSON/countries.json");

            var possibleTeams = JsonSerializer.Deserialize<List<TeamValidator>>(countriesData);

            foreach (var team in groupCreateDto.Teams)
            {
                if (!possibleTeams.Any(x => x.Name == team.Name))
                {
                    var possibleTeamsMessage = GetPossibleTeamsBadRequestMessage(possibleTeams);

                    context.Result = new BadRequestObjectResult($"{team.Name} is not valid team name. {possibleTeamsMessage}");

                    return;
                }
            }

        }

        private string GetPossibleTeamsBadRequestMessage(List<TeamValidator> possibleTeams)
        {
            StringBuilder stringBuilder = new StringBuilder("Possible teams to enter: ");

            for (int i = 0; i < possibleTeams.Count; i++)
            {
                if (i != possibleTeams.Count - 1)
                {
                    stringBuilder.Append($"{possibleTeams[i]},");
                }
                else
                {
                    stringBuilder.Append($"{possibleTeams[i]}");
                }
            }

            return stringBuilder.ToString();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

    }

}