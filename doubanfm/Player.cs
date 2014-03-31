using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;
using System.Timers;


namespace DoubanFM
{
    public class Player
    {
        private WMPLib.WindowsMediaPlayer player;
        CallbackMethodDelegate callbackPlay;
        public Player(CallbackMethodDelegate callbackPlay)
        {
            this.callbackPlay = callbackPlay;
            player = new WMPLib.WindowsMediaPlayer();
            player.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Volume(30);
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                callbackPlay(null);
            }
        }

        #region data
        public double currentPosition()
        {
            return player.controls.currentPosition;
        }

        public string currentPositionString()
        {
            return player.controls.currentPositionString;
        }

        public double duration()
        {
            return player.currentMedia.duration;
        }

        public string durationString()
        {
            return player.currentMedia.durationString;
        }

        #endregion


        #region control
        public void Volume(int volume)
        {
            player.settings.volume = volume;
        }

        public void Play(string path)
        {
            player.controls.stop();
            player.close();

            player = new WMPLib.WindowsMediaPlayer();
            player.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);

            
            player.URL = path;
            player.controls.play();
        }

        public void Stop()
        {
            player.controls.stop();
        }

        public bool Pause()
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
                return true;
            }
            else if (player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                player.controls.play();
                return false;
            }

            return false;
        }


        public void Jump(int value)
        {
            player.controls.currentPosition = value;
        }
        #endregion

    }
}
