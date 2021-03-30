using System;
namespace Imba.Core.Services
{
    public class BroadcastStateService : IBroadcastStateService
    {
        public BroadcastStateService()
        {
        }

        public int IncrementState(int state)
        {
            return state++;
        }
    }
}
