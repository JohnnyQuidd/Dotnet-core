using FirstApplication.Models;
using System.Collections.Generic;

namespace FirstApplication.data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}