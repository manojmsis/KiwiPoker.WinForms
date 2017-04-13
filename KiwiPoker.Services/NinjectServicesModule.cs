using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiPoker.Services
{
   public class NinjectServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameService >().To<GameService>();
            Bind<IDeckOfCards>().To<DeckOfCards>();
        }
    }
}
