﻿using Bricks.Interfaces;

namespace Bricks.Classes
{
    class InputTheLevelOfGame : ICommand
    {
        ICreator[] creators = new ICreator[] { new СreatorEazyMenu(), new CreatorHardMenu() };

        readonly int choice;

        public InputTheLevelOfGame(int choice)
        {
            this.choice = choice;
        }
        public void Execute()
        {
            creators[choice - 1].CreateMenu().GameProcess();
        }
    }
}
