using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_4
{
    public abstract class Player : Character
    {
        public void Join()
        {
            game.PlayerJoin(this);
        }
        public void Leave()
        {
            game.PlayerLeave(this);
        }        
    }
}
