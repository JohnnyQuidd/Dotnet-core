using System;
using System.Collections.Generic;
using FirstApplication.Models;

namespace FirstApplication.data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil", Line="Boil something", Platform="Kettle"},
                new Command{Id=1, HowTo="Cook", Line="Cook something",  Platform="Pot"},
                new Command{Id=2, HowTo="Fry", Line="Fry something", Platform="Pan"},
                new Command{Id=3, HowTo="Drink", Line="Drink something", Platform="Glass"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil", Line="Boil something", Platform="Kettle"};
        }
    }
}