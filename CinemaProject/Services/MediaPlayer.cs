using System;

namespace CinemaProject.Services
{
    public class MediaPlayer
    {
        private AxWMPLib.AxWindowsMediaPlayer _wmp;
        public event Action<int> PositionChanged;
        private System.Windows.Forms.Timer _trackTimer;

        public void Initialize(AxWMPLib.AxWindowsMediaPlayer wmpInstance)
        {
            _wmp = wmpInstance;
            _wmp.uiMode = "none"; 

            _trackTimer = new System.Windows.Forms.Timer();
            _trackTimer.Interval = 1000;
            _trackTimer.Tick += (s, e) =>
            {
                if (_wmp != null && _wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    int currentSec = (int)_wmp.Ctlcontrols.currentPosition;
                    PositionChanged?.Invoke(currentSec);
                }
            };
            _trackTimer.Start();
        }

        public void LoadMovie(string filePath)
        {
            if (_wmp != null)
            {
                _wmp.URL = filePath; 
            }
        }

        public void Play()
        {
            _wmp?.Ctlcontrols.play();
        }

        public void Pause()
        {
            _wmp?.Ctlcontrols.pause();
        }

        public void Stop()
        {
            if (_wmp != null)
            {
                _wmp.Ctlcontrols.stop();
                PositionChanged?.Invoke(0);
            }
        }

        public void Seek(int seconds)
        {
            if (_wmp != null)
            {
                _wmp.Ctlcontrols.currentPosition = seconds;
            }
        }

        public void SetVolume(int volume)
        {
            if (_wmp != null)
            {
                _wmp.settings.volume = volume; 
            }
        }

        public TimeSpan GetCurrentPosition()
        {
            if (_wmp == null) return TimeSpan.Zero;
            return TimeSpan.FromSeconds(_wmp.Ctlcontrols.currentPosition);
        }
    }
}