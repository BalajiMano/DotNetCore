using Commander.Models;
namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
           var commad= new List<Command>{
             new Command{Id=01,HowTo="Play Cricker", Line="Pratice Everyday", Platform="In Nets"},
              new Command{Id=02,HowTo="Hit the Gym", Line="Go Everyday", Platform="In Gym"},
               new Command{Id=03,HowTo="Study Harder", Line="Pratice Everyday", Platform="Anywhere"},
           };
           return commad;
        }

        public Command GetCommandById(int Id)
        {
           return new Command{Id=1,HowTo="Play Cricker", Line="Pratice Everyday", Platform="In Nets"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }

}