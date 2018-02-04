using Terraria;
using Terraria.ModLoader;

namespace Leaf_Tool.Commands
{
	public class Give : ModCommand
	{
		public override CommandType Type
		{
			get { return CommandType.Chat; }
		}

		public override string Command
		{
			get { return "give"; }
		}

		public override string Usage
		{
			get { return "/give <type|name> [stack]"; }
		}

		public override string Description 
		{
			get { return "Give player some items"; }
		}

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if (!int.TryParse(args[0], out  int type))
			{
				var name = args[0].Replace("_", " ");
				var item = new Item();
				for (var k = 0; k < ItemLoader.ItemCount; k++)
				{
					item.SetDefaults(k, true);
					if (name == Lang.GetItemNameValue(k))
					{
						type = k;
						break;
					}
				}

				if (type == 0)
					throw new UsageException("Unknown item: "+ name);
			}

			int stack = 1;
			if (args.Length >= 2)
				stack = int.Parse(args[1]);

			caller.Player.QuickSpawnItem(type, stack);
		}
	}
}