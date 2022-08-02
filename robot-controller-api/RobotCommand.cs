namespace robot_controller_api;

public class RobotCommand
{
    /// Implement <see cref="RobotCommand"> here following the task sheet requirements

    int Id { get; set; }
    int Columns;
    int Rows;
    string Name { get; set; }
    string? Description { get; set; }
    DateTime CreatedDate;
    DateTime ModifiedDate;
    bool IsMoveCommand { get; set; }



    public RobotCommand(int id, string name, bool isMoveCommand, DateTime createdDate, DateTime modifiedDate, string? description = null)
    {
        this.Id = id;
        this.Name = name;
        this.CreatedDate = createdDate;
        this.ModifiedDate = modifiedDate;
        this.Description = description;
        this.IsMoveCommand = isMoveCommand;
    }

    public bool GetIsMoveCommand()
    {
        return IsMoveCommand;
    }

    public int GetId()
    {
        return Id;
    }

    public string? GetDescription()
    {
        return Description;
    }

    public string GetName()
    {
        return Name;
    }

    public void UpdateCommand(string name, bool isMoveCommand, string? description = null)
    {
        this.Name = name;
        this.IsMoveCommand = isMoveCommand;
        this.Description = description;
        this.ModifiedDate = DateTime.Now;

    }

}
