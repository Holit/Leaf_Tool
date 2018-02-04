using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Leaf_Tool.Commands
{
	public class Settime : ModCommand
	{
		public override CommandType Type
		{
			get { return CommandType.World; }
		}

		public override string Command
		{
			get { return "time"; }
		}

		public override string Usage
		{
			get { return "/time numTicks"; }
		}

		public override string Description 
		{
			get { return "Set world time, if time has no args, it will be paused."; }
		}

		public override void Action(CommandCaller caller, string input, string[] args)
		{
            if (args.Length == 1)
            {
                Main.time = int.Parse(args[0]);//Set time
                caller.Reply("Time has been set to " + int.Parse(args[0]));
            }
            else if(args.Length == 0)
            {
                Main.stopTimeOuts = !Main.stopTimeOuts;//Pause time or start time
                if (Main.stopTimeOuts == false)
                {
                    caller.Reply("Time has stopped");
                }
                else
                {
                    caller.Reply("Time has started");
                }
            }
		}
	}
}