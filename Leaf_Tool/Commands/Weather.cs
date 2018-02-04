using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Leaf_Tool.Commands
{
	public class WeatherCmd  : ModCommand
	{
		public override CommandType Type
		{
			get { return CommandType.World; }
		}

		public override string Command
		{
			get { return "wetc"; }
		}

		public override string Usage
		{
			get { return "/wetc numTypes"; }
		}

		public override string Description 
		{
			get { return "Start/stop world weather and events,1~3 for rain, Blood moon, Solar eclipse,"; }
		}

		public override void Action(CommandCaller caller, string input, string[] args)
		{
            if (args.Length == 1)
            {
                if (int.TryParse(args[0], out int types));
                {
                    ModWorld modWorld = new ModWorld();
                    modWorld.ChooseWaterStyle(ref types);
                }
            }
		}
	}
}