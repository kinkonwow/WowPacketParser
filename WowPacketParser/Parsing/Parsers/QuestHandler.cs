using System;
using System.Collections.Generic;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.SQL;


namespace WowPacketParser.Parsing.Parsers
{
    public static class QuestHandler
    {
        [Parser(Opcode.CMSG_QUEST_QUERY)]
        public static void HandleQuestQuery(Packet packet)
        {
            packet.ReadInt32("Entry");
        }

        [Parser(Opcode.SMSG_QUEST_QUERY_RESPONSE)]
        public static void HandleQuestQueryResponse(Packet packet)
        {
            var id = packet.ReadInt32();
            Console.WriteLine("Entry: " + id);

            var method = (QuestMethod)packet.ReadInt32();
            Console.WriteLine("Method: " + method);

            var level = packet.ReadInt32();
            Console.WriteLine("Level: " + level);

            var minLevel = packet.ReadInt32();
            Console.WriteLine("Min Level: " + minLevel);

            var sort = (QuestSort)packet.ReadInt32();
            Console.WriteLine("Sort: " + sort);

            var type = (QuestType)packet.ReadInt32();
            Console.WriteLine("Type: " + type);

            var players = packet.ReadInt32();
            Console.WriteLine("Suggested Players: " + players);

            var factId = new int[2];
            var factRep = new int[2];
            for (var i = 0; i < 2; i++)
            {
                factId[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Required Faction ID: " + factId[i]);

                factRep[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Required Faction Rep: " + factRep[i]);
            }

            var nextQuest = packet.ReadInt32();
            Console.WriteLine("Next Chain Quest: " + nextQuest);

            var xpId = packet.ReadInt32();
            Console.WriteLine("Quest XP ID: " + xpId);

            var rewReqMoney = packet.ReadInt32();
            Console.WriteLine("Reward/Required Money: " + rewReqMoney);

            var rewMoneyMaxLvl = packet.ReadInt32();
            Console.WriteLine("Reward Money Max Level: " + rewMoneyMaxLvl);

            var rewSpell = packet.ReadInt32();
            Console.WriteLine("Reward Spell: " + Extensions.SpellLine(rewSpell));

            var rewSpellCast = packet.ReadInt32();
            Console.WriteLine("Reward Spell Cast: " + Extensions.SpellLine(rewSpellCast));

            var rewHonor = packet.ReadInt32();
            Console.WriteLine("Reward Honor: " + rewHonor);

            var rewHonorBonus = packet.ReadSingle();
            Console.WriteLine("Reward Honor Multiplier: " + rewHonorBonus);

            var srcItemId = packet.ReadInt32();
            Console.WriteLine("Source Item ID: " + srcItemId);

            var flags = (QuestFlag)(packet.ReadInt32() | 0xFFFF);
            Console.WriteLine("Flags: " + flags);

            var titleId = packet.ReadInt32();
            Console.WriteLine("Title ID: " + titleId);

            var reqPlayerKills = packet.ReadInt32();
            Console.WriteLine("Required Player Kills: " + reqPlayerKills);

            var bonusTalents = packet.ReadInt32();
            Console.WriteLine("Bonus Talents: " + bonusTalents);

            var bonusArenaPoints = packet.ReadInt32();
            Console.WriteLine("Bonus Arena Points: " + bonusArenaPoints);

            var bonusUnk = packet.ReadInt32();
            Console.WriteLine("Unk Int32: " + bonusUnk);

            var rewItemId = new int[4];
            var rewItemCnt = new int[4];
            for (var i = 0; i < 4; i++)
            {
                rewItemId[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Item ID: " + rewItemId[i]);

                rewItemCnt[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Item Count: " + rewItemCnt[i]);
            }

            var rewChoiceItemId = new int[6];
            var rewChoiceItemCnt = new int[6];
            for (var i = 0; i < 6; i++)
            {
                rewChoiceItemId[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Choice Item ID: " + rewChoiceItemId[i]);

                rewChoiceItemCnt[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Choice Item Count: " + rewChoiceItemCnt[i]);
            }

            var rewFactionId = new int[5];
            for (var i = 0; i < 5; i++)
            {
                rewFactionId[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Faction ID: " + rewFactionId[i]);
            }

            var rewRepIdx = new int[5];
            for (var i = 0; i < 5; i++)
            {
                rewRepIdx[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Reputation ID: " + rewRepIdx[i]);
            }

            var rewRepOverride = new int[5];
            for (var i = 0; i < 5; i++)
            {
                rewRepOverride[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Reward Rep Override: " + rewRepOverride[i]);
            }

            var pointMap = packet.ReadInt32();
            Console.WriteLine("Point Map ID: " + pointMap);

            var pointX = packet.ReadSingle();
            Console.WriteLine("Point X: " + pointX);

            var pointY = packet.ReadSingle();
            Console.WriteLine("Point Y: " + pointY);

            var pointOpt = packet.ReadInt32();
            Console.WriteLine("Point Opt: " + pointOpt);

            var title = packet.ReadCString();
            Console.WriteLine("Title: " + title);

            var objectives = packet.ReadCString();
            Console.WriteLine("Objectives: " + objectives);

            var details = packet.ReadCString();
            Console.WriteLine("Details: " + details);

            var endText = packet.ReadCString();
            Console.WriteLine("End Text: " + endText);

            var returnText = packet.ReadCString();
            Console.WriteLine("Return Text: " + returnText);

            var reqId = new KeyValuePair<int, bool>[4];
            var reqCnt = new int[4];
            var srcId = new int[4];
            var srcCnt = new int[4];
            for (var i = 0; i < 4; i++)
            {
                reqId[i] = packet.ReadEntry();
                Console.WriteLine("[" + i + "] Required " + (reqId[i].Value ? "GO" : "NPC") +
                    " ID: " + reqId[i].Key);

                reqCnt[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Required Count: " + reqCnt[i]);

                srcId[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Source ID: " + srcId[i]);

                srcCnt[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Source Count: " + srcCnt[i]);
            }

            var reqItemId = new int[6];
            var reqItemCnt = new int[6];
            for (var i = 0; i < 6; i++)
            {
                reqItemId[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Required Item ID: " + reqItemId[i]);

                reqItemCnt[i] = packet.ReadInt32();
                Console.WriteLine("[" + i + "] Required Item Count: " + reqItemCnt[i]);
            }

            var objectiveText = new string[4];
            for (var i = 0; i < 4; i++)
            {
                objectiveText[i] = packet.ReadCString();
                Console.WriteLine("[" + i + "] Objective Text: " + objectiveText[i]);
            }

            SQLStore.WriteData(SQLStore.Quests.GetCommand(id, method, level, minLevel, sort, type,
                players, factId, factRep, nextQuest, xpId, rewReqMoney, rewMoneyMaxLvl,
                rewSpell, rewSpellCast, rewHonor, rewHonorBonus, srcItemId, flags, titleId,
                reqPlayerKills, bonusTalents, bonusArenaPoints, bonusUnk, rewItemId, rewItemCnt,
                rewChoiceItemId, rewChoiceItemCnt, rewFactionId, rewRepIdx, rewRepOverride,
                pointMap, pointX, pointY, pointOpt, title, objectives, details, endText,
                returnText, reqId, reqCnt, srcId, srcCnt, reqItemId, reqItemCnt, objectiveText));
        }

        [Parser(Opcode.CMSG_QUEST_POI_QUERY)]
        public static void HandleQuestPoiQuery(Packet packet)
        {
            var count = packet.ReadInt32("Count");

            for (var i = 0; i < count; i++)
                packet.ReadInt32("[" + i + "] Quest Id");
        }

        [Parser(Opcode.SMSG_QUEST_POI_QUERY_RESPONSE)]
        public static void HandleQuestPoiQueryResponse(Packet packet)
        {
            var count = packet.ReadInt32("Count");

            for (var i = 0; i < count; i++)
            {
                var questId = packet.ReadInt32("[" + i + "] Quest Id");

                var counter = packet.ReadInt32("[" + i + "] POI Counter");
                for (var j = 0; j < counter; j++)
                {
                    var idx = packet.ReadInt32("[" + i + "][" + j + "] POI Index");
                    var objIndex = packet.ReadInt32("[" + i + "][" + j + "] Objective Index");

                    var mapId = packet.ReadInt32();
                    var mapName = Extensions.MapLine(mapId);
                    Console.WriteLine("[" + i + "][" + j + "] Map Id: " + mapName);
                    var wmaId = packet.ReadInt32("[" + i + "][" + j + "] World Map Area");
                    var floorId = packet.ReadInt32("[" + i + "][" + j + "] Floor Id");
                    var unk2 = packet.ReadInt32("[" + i + "][" + j + "] Unk Int32 2");
                    var unk3 = packet.ReadInt32("[" + i + "][" + j + "] Unk Int32 3");

                    SQLStore.WriteData(SQLStore.QuestPois.GetCommand(questId, idx, objIndex, mapId, wmaId,
                        floorId, unk2, unk3));

                    var pointsSize = packet.ReadInt32("[" + i + "][" + j + "] Points counter");
                    for (var k = 0; k < pointsSize; k++)
                    {
                        var pointX = packet.ReadInt32("[" + i + "][" + j + "][" + k + "] Point X");
                        var pointY = packet.ReadInt32("[" + i + "][" + j + "][" + k + "] Point Y");
                        SQLStore.WriteData(SQLStore.QuestPoiPoints.GetCommand(questId, idx, objIndex, pointX,
                            pointY));
                    }
                }
            }
        }

        [Parser(Opcode.SMSG_QUEST_FORCE_REMOVE)]
        [Parser(Opcode.CMSG_QUEST_CONFIRM_ACCEPT)]
        [Parser(Opcode.SMSG_QUESTUPDATE_FAILED)]
        [Parser(Opcode.SMSG_QUESTUPDATE_FAILEDTIMER)]
        [Parser(Opcode.SMSG_QUESTUPDATE_COMPLETE)]
        public static void HandleQuestForceRemoved(Packet packet)
        {
            packet.ReadInt32("Quest Id");
        }

        [Parser(Opcode.SMSG_QUERY_QUESTS_COMPLETED_RESPONSE)]
        public static void HandleQuestCompletedResponse(Packet packet)
        {
            packet.ReadInt32("Count");
            // Prints ~4k lines of quest IDs, should be DEBUG only or something...
            /*
            for (var i = 0; i < count; i++)
                packet.ReadInt32("[" + i + "] Rewarded Quest");
            */
            Console.WriteLine("Packet is currently not printed");
            packet.ReadBytes((int)packet.GetLength());
        }

        [Parser(Opcode.CMSG_QUESTGIVER_STATUS_QUERY)]
        [Parser(Opcode.CMSG_QUESTGIVER_HELLO)]
        [Parser(Opcode.CMSG_QUESTGIVER_QUEST_AUTOLAUNCH)]
        public static void HandleQuestgiverStatusQuery(Packet packet)
        {
            packet.ReadGuid("GUID");
        }

        [Parser(Opcode.SMSG_QUESTGIVER_STATUS)]
        public static void HandleQuestgiverStatus(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadEnum<QuestGiverStatus>("Status", TypeCode.Byte);
        }

        [Parser(Opcode.SMSG_QUESTGIVER_QUEST_LIST)]
        public static void HandleQuestgiverQuestList(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadCString("Title");
            packet.ReadUInt32("Delay");
            packet.ReadUInt32("Emote");

            var count = packet.ReadByte("Count");
            for (var i = 0; i < count; i++)
            {
                packet.ReadUInt32("[" + i + "] Quest Id");
                packet.ReadUInt32("[" + i + "] Quest Icon");
                packet.ReadInt32("[" + i + "] Quest Level");
                packet.ReadEnum<QuestFlag>("[" + i + "] Quest Flags", TypeCode.UInt32);
                packet.ReadBoolean("Change icon");
                packet.ReadCString("[" + i + "] Title");
            }

        }

        [Parser(Opcode.CMSG_QUESTGIVER_QUERY_QUEST)]
        public static void HandleQuestgiverQueryQuest(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadUInt32("Quest Id");
        }

        [Parser(Opcode.CMSG_QUESTGIVER_ACCEPT_QUEST)]
        public static void HandleQuestgiverAcceptQuest(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadUInt32("Quest Id");
            packet.ReadUInt32("Unk UInt32");
        }

        [Parser(Opcode.SMSG_QUESTGIVER_QUEST_DETAILS)]
        public static void HandleQuestgiverDetails(Packet packet)
        {
            packet.ReadGuid("GUID1");
            packet.ReadGuid("GUID2");
            packet.ReadUInt32("Quest Id");
            packet.ReadCString("Title");
            packet.ReadCString("Details");
            packet.ReadCString("Objectives");
            packet.ReadByte("AutoAccept");
            var flags = packet.ReadEnum<QuestFlag>("Quest Flags", TypeCode.UInt32);
            packet.ReadUInt32("Suggested Players");
            packet.ReadByte("Unk byte");

            if ((flags & QuestFlag.HiddenRewards) > 0)
            {
                packet.ReadUInt32("Hidden Chosen Items");
                packet.ReadUInt32("Hidden Items");
                packet.ReadUInt32("Hidden Money");
                packet.ReadUInt32("Hidden XP");
            }
            else
            {
                var count = packet.ReadUInt32("Choice Item Count");
                for (var i = 0; i < count; i++)
                {
                    packet.ReadUInt32("[" + i + "] Choice Item Id");
                    packet.ReadUInt32("[" + i + "] Choice Item Count");
                    packet.ReadUInt32("[" + i + "] Choice Item Display Id");
                }

                var count2 = packet.ReadUInt32("Reward Item Count");
                for (var i = 0; i < count2; i++)
                {
                    packet.ReadUInt32("[" + i + "] Reward Item Id");
                    packet.ReadUInt32("[" + i + "] Reward Item Count");
                    packet.ReadUInt32("[" + i + "] Reward Item Display Id");
                }
                packet.ReadUInt32("Money");
                packet.ReadUInt32("XP");
            }

            packet.ReadUInt32("Honor Points");
            packet.ReadSingle("Honor Multiplier");
            Console.WriteLine("Spell Id: " + Extensions.SpellLine(packet.ReadInt32()));
            Console.WriteLine("Spell Cast Id: " + Extensions.SpellLine(packet.ReadInt32()));
            packet.ReadUInt32("Title Id");
            packet.ReadUInt32("Bonus Talent");
            packet.ReadUInt32("Arena Points");
            packet.ReadUInt32("Unk Uint32 1");

            for (var i = 0; i < 5; i++)
                packet.ReadUInt32("[" + i + "] Reputation Faction");

            for (var i = 0; i < 5; i++)
                packet.ReadUInt32("[" + i + "] Reputation Value Id");

            for (var i = 0; i < 5; i++)
                packet.ReadInt32("[" + i + "] Reputation Value");

            for (var i = 0; i < 4; i++)
            {
                packet.ReadUInt32("[" + i + "] Emote Id");
                packet.ReadUInt32("[" + i + "] Emote Delay");
            }
            packet.ReadUInt32("Unk Uint32 2");
        }

        [Parser(Opcode.CMSG_QUESTGIVER_COMPLETE_QUEST)]
        [Parser(Opcode.CMSG_QUESTGIVER_REQUEST_REWARD)]
        public static void HandleQuestcompleteQuest(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadUInt32("Quest Id");
        }

        [Parser(Opcode.SMSG_QUESTGIVER_REQUEST_ITEMS)]
        public static void HandleQuestRequestItems(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadUInt32("Quest Id");
            packet.ReadCString("Title");
            packet.ReadCString("Text");
            packet.ReadUInt32("Unk UInt32 1");
            packet.ReadUInt32("Emote");
            packet.ReadUInt32("Close Window on Cancel");
            packet.ReadEnum<QuestFlag>("Quest Flags", TypeCode.UInt32);
            packet.ReadUInt32("Suggested Players");
            packet.ReadUInt32("Money");
            var count = packet.ReadUInt32("Required Item Count");
            for (var i = 0; i < count; i++)
            {
                packet.ReadUInt32("[" + i + "] Required Item Id");
                packet.ReadUInt32("[" + i + "] Required Item Count");
                packet.ReadUInt32("[" + i + "] Required Item Display Id");
            }
            packet.ReadUInt32("Unk UInt32 2");
            packet.ReadUInt32("Unk UInt32 3");
            packet.ReadUInt32("Unk UInt32 4");
            packet.ReadUInt32("Unk UInt32 5");
        }

        [Parser(Opcode.SMSG_QUESTGIVER_OFFER_REWARD)]
        public static void HandleQuestOfferReward(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadUInt32("Quest Id");
            packet.ReadCString("Title");
            packet.ReadCString("Text");
            packet.ReadByte("Auto Finish");
            packet.ReadEnum<QuestFlag>("Quest Flags", TypeCode.UInt32);
            packet.ReadUInt32("Suggested Players");
            var count1 = packet.ReadUInt32("Emote Count");
            for (var i = 0; i < count1; i++)
            {
                packet.ReadUInt32("[" + i + "] Emote Delay");
                packet.ReadUInt32("[" + i + "] Emote Id");
            }

            var count2 = packet.ReadUInt32("Choice Item Count");
            for (var i = 0; i < count2; i++)
            {
                packet.ReadUInt32("[" + i + "] Choice Item Id");
                packet.ReadUInt32("[" + i + "] Choice Item Count");
                packet.ReadUInt32("[" + i + "] Choice Item Display Id");
            }

            var count3 = packet.ReadUInt32("Reward Item Count");
            for (var i = 0; i < count3; i++)
            {
                packet.ReadUInt32("[" + i + "] Reward Item Id");
                packet.ReadUInt32("[" + i + "] Reward Item Count");
                packet.ReadUInt32("[" + i + "] Reward Item Display Id");
            }
            packet.ReadUInt32("Money");
            packet.ReadUInt32("XP");

            packet.ReadUInt32("Honor Points");
            packet.ReadSingle("Honor Multiplier");
            packet.ReadUInt32("Unk UInt32 1");
            Console.WriteLine("Spell Id: " + Extensions.SpellLine(packet.ReadInt32()));
            Console.WriteLine("Spell Cast Id: " + Extensions.SpellLine(packet.ReadInt32()));
            packet.ReadUInt32("Title Id");
            packet.ReadUInt32("Bonus Talent");
            packet.ReadUInt32("Arena Points");
            packet.ReadUInt32("Unk Uint32");

            for (var i = 0; i < 5; i++)
                packet.ReadUInt32("[" + i + "] Reputation Faction");

            for (var i = 0; i < 5; i++)
                packet.ReadUInt32("[" + i + "] Reputation Value Id");

            for (var i = 0; i < 5; i++)
                packet.ReadInt32("[" + i + "] Reputation Value");
        }

        [Parser(Opcode.CMSG_QUESTGIVER_CHOOSE_REWARD)]
        public static void HandleQuestChooseReward(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadUInt32("Quest Id");
            packet.ReadUInt32("Reward");
        }

        [Parser(Opcode.SMSG_QUESTGIVER_QUEST_INVALID)]
        public static void HandleQuestInvalid(Packet packet)
        {
            packet.ReadEnum<QuestReasonType>("Reason", TypeCode.UInt32);
        }

        [Parser(Opcode.SMSG_QUESTGIVER_QUEST_FAILED)]
        public static void HandleQuestFailed(Packet packet)
        {
            packet.ReadUInt32("Quest Id");
            packet.ReadEnum<QuestReasonType>("Reason", TypeCode.UInt32);
        }

        [Parser(Opcode.SMSG_QUESTGIVER_QUEST_COMPLETE)]
        public static void HandleQuestCompleted(Packet packet)
        {
            packet.ReadInt32("Quest Id");
            packet.ReadInt32("Reward");
            packet.ReadInt32("Money");
            var honor = packet.ReadInt32();
            if (honor < 0)
                Console.WriteLine("Honor: " + honor);

            var talentpoints = packet.ReadInt32();
            if (talentpoints < 0)
                Console.WriteLine("Talentpoints: " + talentpoints);

            var arenapoints = packet.ReadInt32();
            if (arenapoints < 0)
                Console.WriteLine("Arenapoints: " + arenapoints);
        }

        [Parser(Opcode.CMSG_QUESTLOG_SWAP_QUEST)]
        public static void HandleQuestSwapQuest(Packet packet)
        {
            packet.ReadByte("Slot 1");
            packet.ReadByte("Slot 2");
        }

        [Parser(Opcode.CMSG_QUESTLOG_REMOVE_QUEST)]
        public static void HandleQuestRemoveQuest(Packet packet)
        {
            packet.ReadByte("Slot");
        }

        [Parser(Opcode.SMSG_QUESTUPDATE_ADD_KILL)]
        [Parser(Opcode.SMSG_QUESTUPDATE_ADD_ITEM)]
        public static void HandleQuestUpdateAdd(Packet packet)
        {
            packet.ReadInt32("Quest Id");
            packet.ReadInt32("Entry");
            packet.ReadInt32("Count");
            packet.ReadInt32("Required Count");
            packet.ReadGuid("GUID");
        }

        [Parser(Opcode.SMSG_QUESTGIVER_STATUS_MULTIPLE)]
        public static void HandleQuestgiverStatusMultiple(Packet packet)
        {
            var count = packet.ReadUInt32("Count");
            for (var i = 0; i < count; i++)
            {
                packet.ReadGuid("[" + i + "] GUID");
                packet.ReadEnum<QuestGiverStatus>("[" + i + "] Status", TypeCode.Byte);
            }
        }

        [Parser(Opcode.SMSG_QUESTUPDATE_ADD_PVP_KILL)]
        public static void HandleQuestupdateAddPvpKill(Packet packet)
        {
            packet.ReadInt32("Quest Id");
            packet.ReadInt32("Count");
            packet.ReadInt32("Required Count");
        }

        [Parser(Opcode.SMSG_QUEST_CONFIRM_ACCEPT)]
        public static void HandleQuestConfirAccept(Packet packet)
        {
            packet.ReadInt32("Quest Id");
            packet.ReadCString("Title");
            packet.ReadGuid("GUID");
        }

        [Parser(Opcode.MSG_QUEST_PUSH_RESULT)]
        public static void HandleQuestPushResult(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadByte("Result: "); // FIXME - Add Enum
        }

        [Parser(Opcode.CMSG_QUERY_QUESTS_COMPLETED)]
        [Parser(Opcode.SMSG_QUESTLOG_FULL)]
        [Parser(Opcode.CMSG_QUESTGIVER_CANCEL)]
        [Parser(Opcode.CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY)]
        public static void HandleQuestZeroLengthPackets(Packet packet)
        {
        }

        //[Parser(Opcode.CMSG_START_QUEST)]
        //[Parser(Opcode.CMSG_FLAG_QUEST)]
        //[Parser(Opcode.CMSG_FLAG_QUEST_FINISH)]
        //[Parser(Opcode.CMSG_CLEAR_QUEST)]
    }
}
