﻿using Bricks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Classes
{
    class SaveField : ICommand
    {
        IMenuFunction menuFunction;

        Brick[] bricks;

        public SaveField(IMenuFunction menuFunction, Brick[]bricks)
        {
            this.menuFunction = menuFunction;

            this.bricks = bricks;
        }
        public void Execute()
        {
            menuFunction.SaveField(bricks);
        }
    }
}
