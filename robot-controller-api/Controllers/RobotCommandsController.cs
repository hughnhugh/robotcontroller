using Microsoft.AspNetCore.Mvc;

namespace robot_controller_api.Controllers;

[ApiController]
[Route("api/robot-commands")]
public class RobotCommandsController : ControllerBase
{
    private static readonly List<RobotCommand> _commands = new List<RobotCommand>
    {
        // commands here
        new RobotCommand(0, "LEFT", false, DateTime.Now, DateTime.Now, null),
        new RobotCommand(1, "RIGHT", false, DateTime.Now, DateTime.Now, null),
        new RobotCommand(2, "MOVE", true, DateTime.Now, DateTime.Now, null),
        new RobotCommand(3, "PLACE", false, DateTime.Now, DateTime.Now, null),
        new RobotCommand(4, "REPORT", false, DateTime.Now, DateTime.Now, null),
    };

    // Robot commands endpoints here
    [HttpGet()]
    public IEnumerable<RobotCommand> GetAllRobotCommands() => _commands;


    [HttpGet("move")]
    public IEnumerable<RobotCommand> GetMoveCommandsOnly() {
        // return a filtered _commands field here after you filter outnon - move commands.
        // you might find LINQ Where clause helpful for this matter.
        IEnumerable<RobotCommand> query = GetAllRobotCommands().Where(command => command.GetIsMoveCommand());

        return query;
    }

    [HttpGet("{id}", Name = "GetRobotCommand")]
    public IActionResult GetRobotCommandById(int id)
    {
        // Check whether you have a command with a specified Id and returnNotFound() ActionResult if not.
        // If the command exists, return ActionResult Ok() and pass the command object in it as a parameter:
        // return Ok(command);
        foreach (RobotCommand command in GetAllRobotCommands())
        {
            if (command.GetId() == id)
            {
                return Ok(command);
            }
        }
        return NotFound();
    }

    [HttpPost()]
    public IActionResult AddRobotCommand(RobotCommand newCommand)
    {
        // Check the conditions and create a new command from newCommand
        // and add it to _commands and return a GET endpoint resource URI.
        // GetRobotCommand here is a Name attribute set for the HTTP GET GetRobotCommandById method.
        if (newCommand == null)
        {
            return BadRequest();
        }

        bool nameexists = false;
        foreach (RobotCommand checknamecommand in GetAllRobotCommands())
        {
            if (checknamecommand.GetName() == newCommand.GetName())
            {
                nameexists = true;
                break;
            }
        }
   
        if (!nameexists)
        {
            int newid = GetAllRobotCommands().Count();
            RobotCommand command = new RobotCommand(newid, newCommand.GetName(), false, DateTime.Now, DateTime.Now, newCommand.GetDescription());
            _commands.Add(command);
            return CreatedAtRoute("GetRobotCommand", new { id = command.GetId() }, command);
        } 
        else
        {
            return Conflict();
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRobotCommand(int id, RobotCommand updatedCommand)
    {
        // find a command by id, return NotFound() if it doesn't exist
        // try to modify an existing command with fields from updatedCommand
        // if modification fails, return BadRequest()
        // set ModifiedDate of an existing command to DateTime.Now modification is successful
        if (GetRobotCommandById(id) == Ok())
        {
        }
        return NoContent();
    }

}
