using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private CommanderContext _CommanderContext;

        public SqlCommanderRepo(CommanderContext context)
        {
            _CommanderContext = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _CommanderContext.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _CommanderContext.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _CommanderContext.Commands.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_CommanderContext.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {

        }
    }

}