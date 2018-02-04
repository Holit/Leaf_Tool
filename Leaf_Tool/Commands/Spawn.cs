using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Leaf_Tool.Commands
{
	public class Spawn: ModCommand
	{
		public override CommandType Type
		{
			get { return CommandType.World; }
		}

		public override string Command
		{
			get { return "spw"; }
		}

		public override string Usage
		{
			get { return "/spw {creature name|creature id} <x> <y> <numCount>"; }
		}

		public override string Description 
		{
			get { return "Spawn some creature at given position"; }
		}

		public override void Action(CommandCaller caller, string input, string[] args)
		{
            if (args.Length == 0)
            {
                ModPlayer player = new ModPlayer();
                player.player.Spawn();
            }
            else if(args.Length == 4)
            {
                if (!int.TryParse(args[0], out int type))
                {
                    var name = args[0].Replace("_", " ");
                    var NPCs = new ModNPC();
                    for (var k = 0; k < ItemLoader.ItemCount; k++)
                    {
                        NPCs.SetDefaults();
                        if (name == Lang.GetNPCNameValue(k))
                        {
                            type = k;
                            break;
                        }
                    }

                    if (type == 0)
                        throw new UsageException("Unknown NPC: " + name);
             
                }
                ModNPC NPCSpw = new ModNPC();
                NPCSpw.npc.SetDefaults(type);
                if(int.TryParse(args[1],out int x)&& int.TryParse(args[2], out int y))
                    NPCSpw.SpawnNPC(x,y);

            }
		}
	}
}