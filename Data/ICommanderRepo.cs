using System.Collections.Generic;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;


namespace Commander.Data
{
    public interface ICommanderRepo
    {

        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();


        Command GetCommandById(int Id);

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);
    }

}
