﻿using System;
using CLGameServer.Client;
using CLFramework;
namespace CLGameServer
{
    public partial class PlayerMgr
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Pvp Base
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Pvpsystem()
        {
            try
            {
                byte pvptype = Character.Information.Pvptype;
                if (Character.Information.Pvpstate == pvptype) return;

                if (pvptype > 0)
                {
                    DB.query("UPDATE character SET Pvpstate='" + pvptype + "' WHERE name='" + Character.Information.Name + "'");
                    Character.Information.PvpWait = false;
                    Character.Information.PvP = true;
                    Send(Packet.PvpSystemData(Character.Information.UniqueID, pvptype));
                    StopPvpTimer();
                }
                else
                {
                    DB.query("UPDATE character SET Pvpstate='" + pvptype + "' WHERE name='" + Character.Information.Name + "'");
                    Character.Information.PvpWait = false;
                    Character.Information.PvP = false;
                    Send(Packet.PvpSystemData(Character.Information.UniqueID, 0));
                    StopPvpTimer();
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }
    }
}